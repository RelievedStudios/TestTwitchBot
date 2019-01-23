using System;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace TestTwitchBot
{
    internal class TwitchChatBot
    {
        readonly ConnectionCredentials credentials = new ConnectionCredentials(TwitchInfo.BotUsername, TwitchInfo.BotToken);
        TwitchClient client;

        public TwitchChatBot()
        {
        }

        internal void Connect()
        {
            Console.WriteLine("Connecting...");

            client = new TwitchClient();

            client.Initialize(credentials, TwitchInfo.ChannelName);


            client.OnLog += Client_OnLog;
            client.OnConnectionError += Cliebt_OnConnectionError;
            client.OnMessageReceived += Client_OnMEssageReceived;

            client.Connect();
        }

        private void Client_OnMEssageReceived(object sender, OnMessageReceivedArgs e)
        {
            if(e.ChatMessage.Message.StartsWith("hi", StringComparison.InvariantCultureIgnoreCase))
            {
                client.SendMessage("RelievedStudios", $"Hey there {e.ChatMessage.DisplayName}");
            }
        }

        private void Cliebt_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Error!! {e.Error}");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        internal void Disconnect()
        {
            Console.WriteLine("Disconnecting...");
        }
    }
}