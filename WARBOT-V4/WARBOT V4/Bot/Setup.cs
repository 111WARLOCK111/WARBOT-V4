using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meebey.SmartIrc4net;
using System.Threading;
using WARBOT_V4.Bot.Actions;
using F = System.IO.File;
using WARBOT_V4.Data;
using SW = System.IO.StreamWriter;

namespace WARBOT_V4.Bot
{
    class Setup
    {
        public static IrcClient irc;
        public static void Init()
        {
            irc = new IrcClient();
            Thread IRCStart = new Thread(new ThreadStart(delegate
            {
                irc.OnChannelMessage += new IrcEventHandler(Message.Answer);
                irc.OnConnected += new EventHandler(Connect.Answer);
                irc.OnConnecting += new EventHandler(Connect.Try);
                irc.OnNames += new NamesEventHandler(Nick.Answer);
                irc.OnJoin += new JoinEventHandler(OnJoin);
                irc.OnPart += new PartEventHandler(OnPart);
                irc.OnQuit += new QuitEventHandler(OnQuit);
                irc.OnNickChange += new NickChangeEventHandler(OnNickChange);
                irc.OnDisconnected += new EventHandler(OnDisconnected);
                irc.OnQueryMessage += new IrcEventHandler(Query.Answer);
                irc.Connect(Bot.Config.Server, Config.Port);
            }));
            IRCStart.Start();
            RunMSG();
        }

        public static void RunMSG()
        {
            string read = Console.ReadLine();
            if (read != null)
            {
                string[] getread = read.Split(' ');
                if (getread.Length > 1)
                {
                    string chan = getread[0];
                    string getmsg = read.Substring(getread[0].Length + 1);
                    irc.SendMessage(SendType.Message, chan, getmsg);
                }
                else
                {
                    if (getread[0] != null && getread[0] == "save")
                    {
                        Console.BackgroundColor = WARBOT_V4.Config.Warning;
                        Classic.Write("Saving the bot...");
                        Classic.Write("NOTE: This might lag the bot for a while!");
                        Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
                        if (F.Exists("data/save.txt"))
                            F.Delete("data/save.txt");
                        SW sw = new SW("data/save.txt");
                        foreach (string str in Saver.TempList)
                        {
                            sw.WriteLine(str);
                        }
                        sw.Close();
                        Console.BackgroundColor = WARBOT_V4.Config.Warning;
                        Classic.Write("Saved the bot!");
                        Console.BackgroundColor = WARBOT_V4.Config.DefaultB;
                    }
                }
                RunMSG();
            }
        }

        public static void OnJoin(object sender, JoinEventArgs e)
        {
            Classic.Write("(" + e.Data.Channel + ") " + e.Data.Nick + " Joined!");
            irc.RfcNames(e.Data.Channel);
        }


        public static void OnPart(object sender, PartEventArgs e)
        {
            Classic.Write("(" + e.Data.Channel + ") " + e.Data.Nick + " Left!");
            irc.RfcNames(e.Data.Channel);
        }

        public static void OnQuit(object sender, QuitEventArgs e)
        {
            Classic.Write("(IRC) " + e.Data.Nick + " Disconnected!");
            irc.RfcNames(e.Data.Channel);
        }

        public static void OnNickChange(object sender, NickChangeEventArgs e)
        {
            irc.RfcNames(e.Data.Channel);
        }

        public static void OnDisconnected(object sender, EventArgs e)
        {
            try { irc.Connect(Config.Server, 6667); }
            catch { Console.WriteLine("Lost connection to " + Config.Server + ":" + Config.Port); }
        }
    }
}
