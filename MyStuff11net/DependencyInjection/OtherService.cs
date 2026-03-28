namespace MyStuff11net.DependencyInjection
{
    public class OtherService : IOtherService
    {
        public void PerformAction(string actionName)
        {
            Console.WriteLine($"OtherService is performing action: {actionName}");
        }
    }
}