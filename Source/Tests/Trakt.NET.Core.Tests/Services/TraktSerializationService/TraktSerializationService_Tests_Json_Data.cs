namespace TraktNet.Core.Tests.Services.TraktSerializationService
{
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility;
    using TraktNet.Extensions;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Get.Episodes;

    public partial class TraktSerializationService_Tests
    {
        private const uint EXPIRES_IN_SECONDS = 3600;
        private static readonly DateTime s_createdAt = DateTime.UtcNow;
        private static readonly ulong s_createdAtTimestamp = TestUtility.CalculateTimestamp(s_createdAt);
        private static readonly DateTime FIRST_AIRED = DateTime.UtcNow.AddMonths(-1);
        private static readonly DateTime UPDATED_AT = DateTime.UtcNow;

        private ITraktAuthorization Authorization1 { get; }
        private ITraktAuthorization Authorization2 { get; }
        private ITraktAuthorization Authorization3 { get; }
        private ITraktAuthorization Authorization4 { get; }
        private ITraktAuthorization Authorization5 { get; }
        private ITraktAuthorization Authorization6 { get; }
        private ITraktAuthorization Authorization7 { get; }
        private ITraktAuthorization Authorization8 { get; }

        private ITraktEpisode Episode { get; }

        private string Authorization1Json { get; }
        private string Authorization1JsonIntended { get; }
        private string Authorization2Json { get; }
        private string Authorization3Json { get; }
        private string Authorization4Json { get; }
        private string Authorization5Json { get; }
        private string Authorization6Json { get; }
        private string Authorization7Json { get; }
        private string Authorization8Json { get; }
        private string EpisodeJsonIntended { get; }

        public TraktSerializationService_Tests()
        {
            Authorization1 = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN);
            Authorization2 = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization3 = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization4 = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization5 = TraktAuthorization.CreateWith(s_createdAt, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization6 = TraktAuthorization.CreateWith(s_createdAt, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization7 = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization8 = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);

            Authorization1Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization1.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization1JsonIntended =
                "{\n" +
                   $"    \"access_token\": \"{TestConstants.MOCK_ACCESS_TOKEN}\",\n" +
                   "    \"scope\": \"public\",\n" +
                   "    \"expires_in\": 7776000,\n" +
                   "    \"token_type\": \"bearer\",\n" +
                   $"    \"created_at\": {Authorization1.CreatedAtTimestamp},\n" +
                   "    \"ignore_expiration\": true\n" +
                 "}";

            Authorization2Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization2.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization3Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization3.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization4Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization4.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization5Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization6Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization7Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization8Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Title = "title",
                Ids = new TraktEpisodeIds
                {
                    Trakt = 123456,
                    Tvdb = 234567,
                    Imdb = "345678",
                    Tmdb = 456789,
                    TvRage = 567890
                },
                NumberAbsolute = 1,
                Overview = "overview",
                Runtime = 60,
                Rating = 8.45672f,
                Votes = 8925,
                FirstAired = FIRST_AIRED,
                UpdatedAt = UPDATED_AT,
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en",
                    "de"
                },
                Translations = new List<ITraktEpisodeTranslation>
                {
                    new TraktEpisodeTranslation
                    {
                        Title = "german title",
                        Overview = "german overview",
                        LanguageCode = "de"
                    },
                    new TraktEpisodeTranslation
                    {
                        Title = "english title",
                        Overview = "english overview",
                        LanguageCode = "en"
                    }
                }
            };

            EpisodeJsonIntended =
                "{\n" +
                  "    \"season\": 1,\n" +
                  "    \"number\": 1,\n" +
                  "    \"title\": \"title\",\n" +
                  "    \"ids\": {\n" +
                  "        \"trakt\": 123456,\n" +
                  "        \"tvdb\": 234567,\n" +
                  "        \"imdb\": \"345678\",\n" +
                  "        \"tmdb\": 456789,\n" +
                  "        \"tvrage\": 567890\n" +
                  "    },\n" +
                  "    \"number_abs\": 1,\n" +
                  "    \"overview\": \"overview\",\n" +
                  "    \"runtime\": 60,\n" +
                  "    \"rating\": 8.45672,\n" +
                  "    \"votes\": 8925,\n" +
                  $"    \"first_aired\": \"{FIRST_AIRED.ToTraktLongDateTimeString()}\",\n" +
                  $"    \"updated_at\": \"{UPDATED_AT.ToTraktLongDateTimeString()}\",\n" +
                  "    \"available_translations\": [\n" +
                  "        \"en\",\n" +
                  "        \"de\"\n" +
                  "    ],\n" +
                  "    \"translations\": [\n" +
                  "        {\n" +
                  "            \"title\": \"german title\",\n" +
                  "            \"overview\": \"german overview\",\n" +
                  "            \"language\": \"de\"\n" +
                  "        },\n" +
                  "        {\n" +
                  "            \"title\": \"english title\",\n" +
                  "            \"overview\": \"english overview\",\n" +
                  "            \"language\": \"en\"\n" +
                  "        }\n" +
                  "    ]\n" +
                "}";
        }
    }
}
