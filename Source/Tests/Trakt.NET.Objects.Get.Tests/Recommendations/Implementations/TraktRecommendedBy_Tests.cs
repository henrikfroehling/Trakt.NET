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
    public class TraktRecommendedBy_Tests
    {
        [Fact]
        public void Test_TraktRecommendedBy_Default_Constructor()
        {
            var recommendedBy = new TraktRecommendedBy();

            recommendedBy.User.Should().BeNull();
            recommendedBy.Notes.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktRecommendedBy_From_Json()
        {
            var jsonReader = new RecommendedByObjectJsonReader();
            var recommendedBy = await jsonReader.ReadObjectAsync(JSON) as TraktRecommendedBy;

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
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
                ""notes"": ""Recommended because ...""
              }";
    }
}
