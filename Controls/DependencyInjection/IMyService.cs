namespace StockRoom11net.Controls.DependencyInjection
{
    public interface IMyService
    {
        void DoSomething(String name);
        void Execute(); // Example method to demonstrate service functionality

        string GetMessage();
    }

}