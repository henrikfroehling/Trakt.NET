namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using Get.Users.Lists;

    public interface ITraktCommentItem
    {
        TraktObjectType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }

        ITraktList List { get; set; }
    }
}
