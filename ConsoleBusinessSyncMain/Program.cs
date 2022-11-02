using Business.Sync.Main;

namespace ConsoleBusinessSyncMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, MainSync!");
            var mainSync = new MainSync();
            var test1 = mainSync.TestSql();
        }
    }

}