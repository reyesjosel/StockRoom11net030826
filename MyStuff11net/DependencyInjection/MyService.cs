namespace MyStuff11net.DependencyInjection
{
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