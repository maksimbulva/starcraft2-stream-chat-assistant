using System.Collections.Generic;

namespace Sc2StreamChatAssistant
{
    abstract class BNetRegions
    {
        public class RegionData
        {
            public string Url { get; private set; }
            public string Code { get; private set; }

            public RegionData(string url, string code)
            {
                Url = url;
                Code = code;
            }
        }

        private static readonly List<RegionData> servers_ = new List<RegionData>()
        {
            new RegionData("eu.battle.net", "eu"),
            new RegionData("us.battle.net", "us"),
            new RegionData("sea.battle.net", "sea"),
            new RegionData("kr.battle.net", "kr"),
            new RegionData("battlenet.com.cn", "cn")
        };

        public static RegionData ExtractServerFromUrl(string url)
        {
            return servers_.Find(x => url.Contains(x.Url));
        }
    }
}
