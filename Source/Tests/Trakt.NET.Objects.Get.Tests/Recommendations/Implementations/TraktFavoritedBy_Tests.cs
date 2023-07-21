namespace TraktNet.Objects.Get.Tests.Recommendations.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.Implementations")]
    public class TraktFavoritedBy_Tests
    {
        [Fact]
        public void Test_TraktFavoritedBy_Default_Constructor()
        {
            var favoritedBy = new TraktFavoritedBy();

            favoritedBy.User.Should().BeNull();
            favoritedBy.Notes.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktFavoritedBy_From_Json()
        {
            var jsonReader = new FavoritedByObjectJsonReader();
            var favoritedBy = await jsonReader.ReadObjectAsync(JSON) as TraktFavoritedBy;

            favoritedBy.Should().NotBeNull();
            favoritedBy.User.Should().NotBeNull();
            favoritedBy.User.Username.Should().Be("sean");
            favoritedBy.User.IsPrivate.Should().BeFalse();
            favoritedBy.User.Name.Should().Be("Sean Rudford");
            favoritedBy.User.IsVIP.Should().BeTrue();
            favoritedBy.User.IsVIP_EP.Should().BeTrue();
            favoritedBy.User.Ids.Should().NotBeNull();
            favoritedBy.User.Ids.Slug.Should().Be("sean");
            favoritedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            favoritedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            favoritedBy.User.Location.Should().Be("SF");
            favoritedBy.User.About.Should().Be("I have all your cassette tapes.");
            favoritedBy.User.Gender.Should().Be("male");
            favoritedBy.User.Age.Should().Be(35);
            favoritedBy.User.Images.Should().NotBeNull();
            favoritedBy.User.Images.Avatar.Should().NotBeNull();
            favoritedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            favoritedBy.User.IsVIP_OG.Should().BeTrue();
            favoritedBy.User.VIP_Years.Should().Be(5);
            favoritedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            favoritedBy.Notes.Should().Be("Favorited because ...");
        }

        private const string JSON =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  },
                  ""vip_og"": true,
                  ""vip_years"": 5,
                  ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                },
                ""notes"": ""Favorited because ...""
              }";
    }
}
