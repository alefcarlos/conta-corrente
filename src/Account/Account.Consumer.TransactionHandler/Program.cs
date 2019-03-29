using System;

namespace Account.Consumer.TransactionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var startUp = new Startup();

            startUp.Run();
        }
    }
}
