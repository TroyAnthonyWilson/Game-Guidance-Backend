namespace GameGuidanceAPI.Helpers
{
    public static class IgdbTokens
    {
        private readonly static string ClientID = "n9kcwb4ynvskjy7bd147jk94tdt6yw";
        private readonly static string Bearer = "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf";
        private readonly static string baseUrl = "https://api.igdb.com/v4/games";

        public static string GetClientID() { return ClientID; }

        public static string GetBearer() { return Bearer; }

        public static string GetBaseUrl() { return baseUrl; }
    }
}
