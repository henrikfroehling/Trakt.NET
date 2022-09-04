namespace TraktNet.Modules.Tests.TraktListsModule
{
    public partial class TraktListsModule_Tests
    {
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int ITEM_COUNT = 2;
        private const int SINGLE_LIST_ID = 55;

        private const string SINGLE_LIST_JSON =
            @"{
                ""like_count"": 1004,
                ""comment_count"": 71,
                ""list"": {
                  ""name"": ""Best Mindfucks"",
                  ""description"": ""What’s a mindfuck? A movie that plays with your mind, confuses you, and leads you on. It’s not just a movie with a twist ending. Mindfucks are borderline-incoherent, dreamlike, and surreal."",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2012-06-30T23:29:30.000Z"",
                  ""updated_at"": ""2018-05-28T10:01:41.000Z"",
                  ""item_count"": 116,
                  ""comment_count"": 71,
                  ""likes"": 1004,
                  ""ids"": {
                    ""trakt"": 800238,
                    ""slug"": ""best-mindfucks""
                  },
                  ""user"": {
                    ""username"": ""BenFranklin"",
                    ""private"": false,
                    ""name"": ""Ben"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""benfranklin""
                    }
                  }
                }
              }";

        private const string LISTS_JSON =
            @"[
                {
                  ""like_count"": 1004,
                  ""comment_count"": 71,
                  ""list"": {
                    ""name"": ""Best Mindfucks"",
                    ""description"": ""What’s a mindfuck? A movie that plays with your mind, confuses you, and leads you on. It’s not just a movie with a twist ending. Mindfucks are borderline-incoherent, dreamlike, and surreal."",
                    ""privacy"": ""public"",
                    ""display_numbers"": false,
                    ""allow_comments"": true,
                    ""sort_by"": ""rank"",
                    ""sort_how"": ""asc"",
                    ""created_at"": ""2012-06-30T23:29:30.000Z"",
                    ""updated_at"": ""2018-05-28T10:01:41.000Z"",
                    ""item_count"": 116,
                    ""comment_count"": 71,
                    ""likes"": 1004,
                    ""ids"": {
                      ""trakt"": 800238,
                      ""slug"": ""best-mindfucks""
                    },
                    ""user"": {
                      ""username"": ""BenFranklin"",
                      ""private"": false,
                      ""name"": ""Ben"",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""benfranklin""
                      }
                    }
                  }
                },
                {
                  ""like_count"": 639,
                  ""comment_count"": 20,
                  ""list"": {
                    ""name"": ""Marvel Cinematic Universe Timeline"",
                    ""description"": ""This is the entire canon Marvel Cinematic Universe in it's chronological order. Includes:All Movies,Marvel One-Shots, andMarvel's Agents of S.H.I.E.L.D."",
                    ""privacy"": ""public"",
                    ""display_numbers"": true,
                    ""allow_comments"": true,
                    ""sort_by"": ""rank"",
                    ""sort_how"": ""asc"",
                    ""created_at"": ""2013-11-14T05:20:39.000Z"",
                    ""updated_at"": ""2018-05-28T10:01:46.000Z"",
                    ""item_count"": 42,
                    ""comment_count"": 20,
                    ""likes"": 639,
                    ""ids"": {
                      ""trakt"": 828103,
                      ""slug"": ""marvel-cinematic-universe-timeline""
                    },
                    ""user"": {
                      ""username"": ""Geekritique"",
                      ""private"": false,
                      ""name"": ""Dakota Ritique"",
                      ""vip"": false,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""geekritique""
                      }
                    }
                  }
                }
              ]";
    }
}
