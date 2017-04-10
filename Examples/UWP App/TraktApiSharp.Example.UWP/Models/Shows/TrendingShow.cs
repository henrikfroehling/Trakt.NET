namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    public class TrendingShow : TraktShow
    {
        public int? Watchers { get; set; }
    }
}
