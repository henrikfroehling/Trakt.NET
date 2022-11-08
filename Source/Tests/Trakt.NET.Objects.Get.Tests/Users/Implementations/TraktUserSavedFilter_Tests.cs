namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktUserSavedFilter_Tests
    {
        [Fact]
        public void Test_TraktUserSavedFilter_Default_Constructor()
        {
            var userSavedFilter = new TraktUserSavedFilter();

            userSavedFilter.Id.Should().Be(0);
            userSavedFilter.Section.Should().BeNull();
            userSavedFilter.Name.Should().BeNullOrEmpty();
            userSavedFilter.Path.Should().BeNullOrEmpty();
            userSavedFilter.Query.Should().BeNullOrEmpty();
            userSavedFilter.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserSavedFilter_From_Json()
        {
            var jsonReader = new UserSavedFilterObjectJsonReader();
            var userSavedFilter = await jsonReader.ReadObjectAsync(JSON) as TraktUserSavedFilter;

            userSavedFilter.Should().NotBeNull();
            userSavedFilter.Id.Should().Be(1);
            userSavedFilter.Section.Should().Be(TraktFilterSection.Movies);
            userSavedFilter.Name.Should().Be("Movies: IMDB + TMDB ratings");
            userSavedFilter.Path.Should().Be("/movies/recommended/weekly");
            userSavedFilter.Query.Should().Be("imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0");
            userSavedFilter.UpdatedAt.Should().HaveValue().And.Be(DateTime.Parse("2022-06-15T11:15:06.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";
    }
}
