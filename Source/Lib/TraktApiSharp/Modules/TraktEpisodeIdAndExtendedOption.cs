namespace TraktApiSharp.Modules
{
    using Requests.Params;

    public class TraktEpisodeIdAndExtendedOption
    {
        public string ShowId { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public TraktExtendedOption ExtendedOption { get; set; }
    }
}
