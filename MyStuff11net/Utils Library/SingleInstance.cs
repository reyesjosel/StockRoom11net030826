namespace MyStuff11net
{
    internal enum SingleInstanceMode : int
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        NotInited = 0,

        /// <summary>
        /// Every user can have own single instance.
        /// </summary>
        ForEveryUser
    }

    internal sealed class SingleInstance
    {
        static Action<object> SecondInstanceCallback;

        private SingleInstance() { }

        /// <summary>
        /// Processing single instance with <see cref="SingleInstanceMode.ForEveryUser"/> mode.
        /// </summary>
        internal static void Make(Action<object> callback)
        {
            Make(SingleInstanceMode.ForEveryUser, callback);
        }

        /// <summary>
        /// Processing single instance.
        /// </summary>
        internal static void Make(SingleInstanceMode mode, Action<object> callback)
        {
            SecondInstanceCallback = callback;

#if DEBUG
            var appName = string.Format("{0}DEBUG", typeof(SingleInstance).Assembly.ManifestModule.ScopeName);
#else
            var appName = typeof(SingleInstance).Assembly.ManifestModule.ScopeName;
#endif

            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var keyUserName = ((windowsIdentity != null) ? windowsIdentity.User.ToString() : string.Empty);

            // Be careful! Max 260 chars!
            var eventWaitHandleName = string.Format("{0}{1}", appName, ((mode == SingleInstanceMode.ForEveryUser) ? keyUserName : string.Empty));

            try
            {
                using (var waitHandle = EventWaitHandle.OpenExisting(eventWaitHandleName))
                {
                    // It informs first instance about other startup attempting.
                    waitHandle.Set();
                }

                // Let's terminate this posterior startup.
                // For that exit no interception.
                Environment.Exit(0);
            }
            catch
            {
                // It's first instance.
                // Register EventWaitHandle.
                using (var eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, eventWaitHandleName))
                {
                    ThreadPool.RegisterWaitForSingleObject(eventWaitHandle, OtherInstanceAttemptedToStart, null, Timeout.Infinite, false);
                }
            }
        }

        private static void OtherInstanceAttemptedToStart(object state, bool timedOut)
        {
            if (SecondInstanceCallback != null)
                SecondInstanceCallback.Invoke(state);
        }
    }
}
