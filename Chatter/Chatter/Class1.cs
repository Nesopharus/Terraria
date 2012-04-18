using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using TShockAPI;
using System.ComponentModel;

namespace Chatter
{
    class Main : TerrariaPlugin
    {
        public Main(Terraria.Main game)
            : base(game)
        {
            Order = -1;
        }
        #region Information
        public override Version Version
        {
            get
            {
                return new Version("0.1");
            }
        }
        public override string Author
        {
            get
            {
                return "Neso";
            }
        }
        public override string Description
        {
            get
            {
                return "Multicolor and personal Chatting System";
            }
        }
        public override string Name
        {
            get
            {
                return "Chatter";
            }
        }
        #endregion

        public override void Initialize()
        {
            Hooks.ServerHooks.Chat += OnChat;

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Hooks.ServerHooks.Chat -= OnChat;
            base.Dispose(disposing);
        }
        private void OnChat(messageBuffer msgb, int pid, string msg, HandledEventArgs args)
        {
            if (args.Handled)
                return;

            TSPlayer sender = TShock.Players[msgb.whoAmI];
            if (sender == null)
            {
                args.Handled = true;
                return;
            }

            if (msg.StartsWith("!"))
            {
                args.Handled = true;
                string[] Messagearr = msg.Split(' ');
                string cmd = Messagearr[0].Substring(1);
                Messagearr[0] = sender.Name;
                switch (cmd)
                {
                    case "red":
                        Chat(Color.Red, Messagearr);
                        break;
                    case "green":
                        Chat(Color.Green, Messagearr);
                        break;
                    default:
                        sender.SendMessage("Erdbeerkäse =)");
                        break;

                }
            }
        }
        private void Chat(Color color, string[] words)
        {

            String message = String.Join(" ", words);
            TSPlayer.All.SendMessage(message, color);
        }
    }
}
