namespace TraktNet.Objects.Get.Users
{
    using Basic;
    using Enums;
    using Episodes;
    using Lists;
    using Movies;
    using Seasons;
    using Shows;

    public interface ITraktUserComment
    {
        TraktObjectType Type { get; set; }

        ITraktComment Comment { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }

        ITraktList List { get; set; }
    }
}
