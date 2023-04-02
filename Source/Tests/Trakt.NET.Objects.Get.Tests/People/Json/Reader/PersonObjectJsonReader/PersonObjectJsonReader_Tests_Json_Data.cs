namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    public partial class PersonObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""Bryan Cranston"",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
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
                ""homepage"": ""http://www.bryancranston.com/"",
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
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
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
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
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
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
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nm"": ""Bryan Cranston"",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""i"": {
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""bio"": ""Bryan Lee Cranston(born March 7, 1956)..."",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                ""brth"": ""1956-03-07"",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
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
                ""de"": ""2016-04-06"",
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
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
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
                ""bp"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/"",
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
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
                ""hp"": ""http://www.bryancranston.com/"",
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
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
                ""gd"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
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
                ""kfd"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
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
                ""social"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""ua"": ""2022-11-03T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""nm"": ""Bryan Cranston"",
                ""i"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""bio"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                ""brth"": ""1956-03-07"",
                ""de"": ""2016-04-06"",
                ""bp"": ""San Fernando Valley, California, USA"",
                ""hp"": ""http://www.bryancranston.com/"",
                ""gd"": ""male"",
                ""kfd"": ""acting"",
                ""social"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""ua"": ""2022-11-03T17:00:54.000Z""
              }";
    }
}
