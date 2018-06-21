namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using Get.Users.Lists;

    public class TraktCommentItem : ITraktCommentItem
    {
        public TraktObjectType Type { get; set; }

        public ITraktMovie Movie { get; set; }

        public ITraktShow Show { get; set; }

        public ITraktSeason Season { get; set; }

        public ITraktEpisode Episode { get; set; }

        public ITraktList List { get; set; }
    }
}
