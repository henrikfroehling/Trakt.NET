namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Basic;
    using Objects.Get.Shows;
    using System.Collections.Generic;

    public class Show : TraktShow
    {
        public IEnumerable<TraktShowAlias> Aliases { get; set; }

        public IEnumerable<TraktShowTranslation> Translations { get; set; }

        public TraktRating ShowRating { get; set; }

        public TraktStatistics Statistics { get; set; }
    }
}
