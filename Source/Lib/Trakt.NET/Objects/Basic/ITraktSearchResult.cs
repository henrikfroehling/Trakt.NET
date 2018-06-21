namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Users.Lists;

    public interface ITraktSearchResult
    {
        TraktSearchResultType Type { get; set; }

        float? Score { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktEpisode Episode { get; set; }

        ITraktPerson Person { get; set; }

        ITraktList List { get; set; }
    }
}
