namespace TraktApiSharp.Modules
{
    using Requests;

    public class TraktSeasonIdAndExtendedOption
    {
        public string ShowId { get; set; }

        public int Season { get; set; }

        public TraktExtendedOption ExtendedOption { get; set; }
    }
}
