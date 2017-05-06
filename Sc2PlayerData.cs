namespace Sc2StreamChatAssistant
{
    sealed class Sc2PlayerData
    {
        public long Id { get; set; }
        public int Realm { get; set; }
        public string DisplayName { get; set; }
        public string ClanName { get; set; }
        public string ClanTag { get; set; }
        public string ProfilePath { get; set; }
        public string RegionCode { get; set; }

        public override string ToString()
        {
            return $"[{RegionCode}] <{ClanTag}> {DisplayName}";
        }
    }
}
