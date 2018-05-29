namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users.Lists;

    public partial class TraktCommentsModule_Tests
    {
        private const uint COMMENT_ID = 190U;
        private const uint GET_COMMENT_ID = 76957U;
        private const uint GET_COMMENT_REPLIES_ID = 190U;
        private const int COMMENT_REPLIES_ITEM_COUNT = 2;
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const string COMMENT_TEXT = "one two three four five reply";
        private const bool SPOILER = false;

        private readonly ITraktSharing SHARING = new TraktSharing
        {
            Facebook = true,
            Google = false,
            Twitter = true
        };

        private ITraktMovie Movie { get; }
        private ITraktShow Show { get; }
        private ITraktSeason Season { get; }
        private ITraktEpisode Episode { get; }
        private ITraktList List { get; }

        public TraktCommentsModule_Tests()
        {
            Movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            Show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            Season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            Episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            List = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };
        }

        private const string COMMENT_JSON =
            @"{
                ""id"": 76957,
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""parent_id"": 0,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""replies"": 1,
                ""likes"": 2,
                ""user_rating"": 7.3,
                ""user"": {
                  ""username"": ""WalterBishopj"",
                  ""private"": false,
                  ""name"": ""Walter"",
                  ""vip"": false,
                  ""vip_ep"": false
                }
              }";

        private const string COMMENT_REPLIES_JSON =
            @"[
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string COMMENT_POST_RESPONSE_JSON =
            @"{
                ""id"": 190,
                ""parent_id"": 0,
                ""created_at"": ""2014-08-04T06:46:01.996Z"",
                ""comment"": ""Oh, I wasn't really listening."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 0,
                ""likes"": 0,
                ""user_rating"": null,
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false
                },
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""tumblr"": false,
                  ""medium"": true
                }
              }";
    }
}
