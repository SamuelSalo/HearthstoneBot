using System;

namespace HearthstoneBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
