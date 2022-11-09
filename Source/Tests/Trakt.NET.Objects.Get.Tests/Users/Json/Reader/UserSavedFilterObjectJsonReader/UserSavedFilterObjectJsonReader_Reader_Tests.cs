namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserSavedFilterObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(0);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().BeNull();
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().BeNullOrEmpty();
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().BeNullOrEmpty();
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().BeNullOrEmpty();
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(0);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().BeNull();
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().BeNullOrEmpty();
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Should().NotBeNull();

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().BeNullOrEmpty();
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().BeNullOrEmpty();
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);

            userSavedFilter.Id.Should().Be(0);
            userSavedFilter.Section.Should().BeNull();
            userSavedFilter.Name.Should().BeNullOrEmpty();
            userSavedFilter.Path.Should().BeNullOrEmpty();
            userSavedFilter.Query.Should().BeNullOrEmpty();
            userSavedFilter.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();
            Func<Task<ITraktUserSavedFilter>> userSavedFilter = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await userSavedFilter.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserSavedFilterObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserSavedFilterObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var userSavedFilter = await traktJsonReader.ReadObjectAsync(jsonReader);
            userSavedFilter.Should().BeNull();
        }
    }
}
