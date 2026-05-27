namespace StockRoom11net.Controls.DependencyInjection
{
    /// <summary>
    /// Service class that implements the IMyService interface. This class can be registered with a
    /// dependency injection container and used throughout the application wherever IMyService is required.
    /// Used in the DI_pattern class to demonstrate how to implement and use a service in a dependency injection context.
    /// </summary>
    public class MyService : IMyService
    {
        public void DoSomething(String name)
        {
            // Implementation of the service method
            // This could involve business logic, data access, etc.
            Console.WriteLine($"MyService is doing something., {name}");
        }
        public void Execute()
        {
            // Example method to demonstrate service functionality
            Console.WriteLine("Executing MyService logic.");
        }

        public string GetMessage() => "Hello from DI";
    }
}