namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    public partial class RecentlyUpdatedPersonObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2022-11-03T18:58:09.000Z"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/"",
                  ""gender"": ""male"",
                  ""known_for_department"": ""acting"",
                  ""social_ids"": {
                    ""twitter"": ""BryanCranston"",
                    ""facebook"": ""thebryancranston"",
                    ""instagram"": ""bryancranston"",
                    ""wikipedia"": ""Bryan_Cranston""
                  },
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/"",
                  ""gender"": ""male"",
                  ""known_for_department"": ""acting"",
                  ""social_ids"": {
                    ""twitter"": ""BryanCranston"",
                    ""facebook"": ""thebryancranston"",
                    ""instagram"": ""bryancranston"",
                    ""wikipedia"": ""Bryan_Cranston""
                  },
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""updated_at"": ""2022-11-03T18:58:09.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ua"": ""2022-11-03T18:58:09.000Z"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/"",
                  ""gender"": ""male"",
                  ""known_for_department"": ""acting"",
                  ""social_ids"": {
                    ""twitter"": ""BryanCranston"",
                    ""facebook"": ""thebryancranston"",
                    ""instagram"": ""bryancranston"",
                    ""wikipedia"": ""Bryan_Cranston""
                  },
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""updated_at"": ""2022-11-03T18:58:09.000Z"",
                ""pers"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/"",
                  ""gender"": ""male"",
                  ""known_for_department"": ""acting"",
                  ""social_ids"": {
                    ""twitter"": ""BryanCranston"",
                    ""facebook"": ""thebryancranston"",
                    ""instagram"": ""bryancranston"",
                    ""wikipedia"": ""Bryan_Cranston""
                  },
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ua"": ""2022-11-03T18:58:09.000Z"",
                ""pers"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/"",
                  ""gender"": ""male"",
                  ""known_for_department"": ""acting"",
                  ""social_ids"": {
                    ""twitter"": ""BryanCranston"",
                    ""facebook"": ""thebryancranston"",
                    ""instagram"": ""bryancranston"",
                    ""wikipedia"": ""Bryan_Cranston""
                  },
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";
    }
}
