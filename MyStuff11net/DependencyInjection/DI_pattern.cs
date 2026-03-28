using Microsoft.Extensions.DependencyInjection;
using static MyStuff11net.UsingKernel32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MyStuff11net.DependencyInjection
{
    internal class DI_pattern
    {
        private readonly IMyService _myService;

        // This constructor is used to inject the IMyService dependency into the DI_pattern class.
        // It ensures that the service is available for use within this class.
        public DI_pattern(IMyService myServices)
        {
            // Constructor logic can be added here if needed.
            _myService = myServices ?? throw new ArgumentNullException(nameof(myServices), "MyService cannot be null.");
        }

        public void UseService(string name)
        {
            // This method demonstrates how to use the injected service.
            // It calls a method on the IMyService instance, which is expected to be provided by the DI container.
            _myService.DoSomething(name);
        }

        // This class is a placeholder for Dependency Injection patterns.
        // It can be used to implement various DI techniques such as constructor injection, property injection, etc.
        // The actual implementation will depend on the specific requirements of the application.
        public DI_pattern()
        {
            /*
            | Lifetime  | When to use                        |
            | --------- | ---------------------------------- |
            | Singleton | Logging, config, cache             |
            | Scoped    | ❌ Usually avoid(no request scope).|
            | Transient | Forms, dialogs                     |
            */

            // Code to register services with a DI container
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IMyService, MyService>();
            serviceCollection.AddSingleton<IOtherService, OtherService>();
            serviceCollection.AddSingleton<DI_pattern>(); // Registering the DI_pattern class itself
            // Add more services as needed

            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Now you can use the service provider to resolve services
            var program = serviceProvider.GetRequiredService<DI_pattern>();
            program.UseService("ExampleName"); // Example usage of the service
        }

        public void ResolveServices()
        {
            // Code to resolve services from the DI container
            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var myService = serviceProvider.GetService<IMyService>();
            var otherService = serviceProvider.GetService<IOtherService>();

        }

        public void DI_patternExample()
        {
            // Example of using the DI pattern in an application
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMyService, MyService>()
                .AddSingleton<IOtherService, OtherService>()
                .BuildServiceProvider();
            var myService = serviceProvider.GetRequiredService<IMyService>();
            myService.Execute(); // Call a method on the resolved service
            var otherService = serviceProvider.GetRequiredService<IOtherService>();
            otherService.PerformAction("SampleAction"); // Call a method on another resolved service
        }

    }
}
