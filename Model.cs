using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    class Model
    {
        public const string playersCollectionName = "players";

        public class Players
        {
            [BsonIndex]
            public ulong Id { get; set; }

            [BsonIndex]
            public string DisplayName { get; set; }

            public string ProfilePath { get; set; }
        }
    }
}
