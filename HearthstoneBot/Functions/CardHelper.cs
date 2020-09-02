using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace HearthstoneBot.Functions
{
    public static class CardHelper
    {
        public static CardInfo GetCardInfo(string cardName)
        {
            string json = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(Bot.config.Url + Uri.EscapeUriString(cardName));
            
            request.Method = WebRequestMethods.Http.Get;

            request.Headers["x-rapidapi-host"] = Bot.config.Host;
            request.Headers["x-rapidapi-key"] = Bot.config.Key;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            

            var cards = JsonConvert.DeserializeObject<CardInfo[]>(json);
            var card = new CardInfo();

            foreach (CardInfo c in cards)
            {
                if (!c.cardId.Contains("BOSS") || !c.cardId.Contains("HERO"))
                    card = c;
            }
            
            return card;
        }
        public static string GetCardImage(CardInfo card, bool gold)
        {
            string redirUrl = String.Empty;

            var request = (HttpWebRequest)HttpWebRequest.Create(gold ? card.imgGold : card.img);
            
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                redirUrl = response.ResponseUri.ToString();
            }
            catch (WebException e)
            {
                var response = (HttpWebResponse)e.Response;
                redirUrl = response.GetResponseHeader("Location");
                Console.WriteLine(response.GetResponseHeader("Location"));
            }
            
            return redirUrl;
        }
        public static bool IsMinion (string cardName)
        {
            return GetCardInfo(cardName).type == "Minion";
        }
        public static string GetId(string cardName)
        {
            return GetCardInfo(cardName).cardId;
        }
        public static string GetAtk(string cardName)
        {
            return $"{cardName} has {GetCardInfo(cardName).attack} attack.";
        }
        public static string GetHp(string cardName)
        {
            return $"{cardName} has {GetCardInfo(cardName).health} health.";
        }
        public static string GetCost(string cardName)
        {
            return $"{cardName} costs {GetCardInfo(cardName).cost} mana.";
        }
        public static string GetRarity(string cardName)
        {
            return $"{cardName} is a {GetCardInfo(cardName).rarity} card.";
        }
        public static string GetRace(string cardName)
        {
            return $"{cardName} is a {GetCardInfo(cardName).race}.";
        }
        public static string GetFaction(string cardName)
        {
            return $"{cardName} is in the {GetCardInfo(cardName).faction} faction.";
        }
        public static string GetType(string cardName)
        {
            return $"{cardName} is of type {GetCardInfo(cardName).type}.";
        }

    }
}
