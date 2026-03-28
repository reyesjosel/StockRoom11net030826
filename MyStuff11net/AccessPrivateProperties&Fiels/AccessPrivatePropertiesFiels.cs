using System.Reflection;

namespace MyStuff11net
{
    public static class AccessPrivatePropertiesFiels
    {
        public static string GetPrivateField(this object obj, string name)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            FieldInfo? field = type.GetField(name, flags);

            if (field != null)
            {
                object? value = field.GetValue(obj);
                return value?.ToString() ?? "ColumnType";
            }
            else
                return "ColumnType";
        }

        public static T GetPrivateField<T>(this object obj, string name)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            FieldInfo? field = type.GetField(name, flags) ?? throw new ArgumentException($"Field '{name}' not found.", nameof(name));
            object? value = field.GetValue(obj);
            return (T)value!;
        }

        public static T GetPrivateProperty<T>(this object obj, string name)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            PropertyInfo? field = type.GetProperty(name, flags) ?? throw new ArgumentException($"Property '{name}' not found.", nameof(name));
            object? value = field.GetValue(obj, null);
            return (T)value!;
        }


        public static void SetPrivateField(this object obj, string name, object value)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            FieldInfo? field = type.GetField(name, flags) ?? throw new ArgumentException($"Field '{name}' not found.", nameof(name));
            field.SetValue(obj, value);
        }

        public static void SetPrivateProperty(this object obj, string name, object value)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            PropertyInfo? field = type.GetProperty(name, flags) ?? throw new ArgumentException($"Property '{name}' not found.", nameof(name));
            field.SetValue(obj, value, null);
        }

        public static T CallPrivateMethod<T>(this object obj, string name, params object[] param)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(name, flags) ?? throw new ArgumentException($"Method '{name}' not found.", nameof(name));
            object? result = method.Invoke(obj, param);
            return (T)result!;
        }


    }
}
