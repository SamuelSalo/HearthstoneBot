using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    public static class Bot
    {
        public static DiscordClient Client { get; private set; }

        public static CommandsNextExtension Commands { get; private set; }

        public static Config config;

        public static async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            config = JsonConvert.DeserializeObject<Config>(json);
            Console.WriteLine(json);
            
            var dConfig = new DiscordConfiguration
            {
                Token = config.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };
            
            
            Client = new DiscordClient(dConfig);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] {config.Prefix},
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<Commands.Misc>();
            Commands.RegisterCommands<Commands.Main>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private static Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
