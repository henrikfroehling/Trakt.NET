namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Basic;
    using Objects.Get.Shows;
    using System.Collections.ObjectModel;

    public class Show : TraktShow
    {
        public ObservableCollection<TraktShowAlias> Aliases { get; set; }

        public ObservableCollection<TraktShowTranslation> Translations { get; set; }

        public TraktRating ShowRating { get; set; }

        public TraktStatistics Statistics { get; set; }
    }
}
