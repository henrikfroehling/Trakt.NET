namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public class UserSavedFilterObjectJsonWriter_Tests
    {
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktUserSavedFilter);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_Id_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Id = 1
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":1}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_Section_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Section = TraktFilterSection.Movies
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":0,""section"":""movies""}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_Name_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Name = "Movies: IMDB + TMDB ratings"
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":0,""name"":""Movies: IMDB + TMDB ratings""}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_Path_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Path = "/movies/recommended/weekly"
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":0,""path"":""/movies/recommended/weekly""}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_Query_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Query = "imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":0,""query"":""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0""}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Only_UpdatedAt_Property()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                UpdatedAt = UPDATED_AT
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be($"{{\"id\":0,\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter
            {
                Id = 1,
                Section = TraktFilterSection.Movies,
                Name = "Movies: IMDB + TMDB ratings",
                Path = "/movies/recommended/weekly",
                Query = "imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0",
                UpdatedAt = UPDATED_AT
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new UserSavedFilterObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserSavedFilter);
            stringWriter.ToString().Should().Be(@"{""id"":1," +
                                                @"""section"":""movies""," +
                                                @"""name"":""Movies: IMDB + TMDB ratings""," +
                                                @"""path"":""/movies/recommended/weekly""," +
                                                @"""query"":""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0""," +
                                                $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
