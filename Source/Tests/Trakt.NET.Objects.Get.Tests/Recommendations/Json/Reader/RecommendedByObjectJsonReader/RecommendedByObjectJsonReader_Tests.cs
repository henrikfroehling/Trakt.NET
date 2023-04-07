namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendedByObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedBy.Should().NotBeNull();
            traktRecommendedBy.User.Should().NotBeNull();
            traktRecommendedBy.User.Username.Should().Be("sean");
            traktRecommendedBy.User.IsPrivate.Should().BeFalse();
            traktRecommendedBy.User.Name.Should().Be("Sean Rudford");
            traktRecommendedBy.User.IsVIP.Should().BeTrue();
            traktRecommendedBy.User.IsVIP_EP.Should().BeTrue();
            traktRecommendedBy.User.Ids.Should().NotBeNull();
            traktRecommendedBy.User.Ids.Slug.Should().Be("sean");
            traktRecommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            traktRecommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            traktRecommendedBy.User.Location.Should().Be("SF");
            traktRecommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            traktRecommendedBy.User.Gender.Should().Be("male");
            traktRecommendedBy.User.Age.Should().Be(35);
            traktRecommendedBy.User.Images.Should().NotBeNull();
            traktRecommendedBy.User.Images.Avatar.Should().NotBeNull();
            traktRecommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            traktRecommendedBy.User.IsVIP_OG.Should().BeTrue();
            traktRecommendedBy.User.VIP_Years.Should().Be(5);
            traktRecommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            traktRecommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedBy.Should().NotBeNull();
            traktRecommendedBy.User.Should().BeNull();
            traktRecommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedBy.Should().NotBeNull();
            traktRecommendedBy.User.Should().NotBeNull();
            traktRecommendedBy.User.Username.Should().Be("sean");
            traktRecommendedBy.User.IsPrivate.Should().BeFalse();
            traktRecommendedBy.User.Name.Should().Be("Sean Rudford");
            traktRecommendedBy.User.IsVIP.Should().BeTrue();
            traktRecommendedBy.User.IsVIP_EP.Should().BeTrue();
            traktRecommendedBy.User.Ids.Should().NotBeNull();
            traktRecommendedBy.User.Ids.Slug.Should().Be("sean");
            traktRecommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            traktRecommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            traktRecommendedBy.User.Location.Should().Be("SF");
            traktRecommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            traktRecommendedBy.User.Gender.Should().Be("male");
            traktRecommendedBy.User.Age.Should().Be(35);
            traktRecommendedBy.User.Images.Should().NotBeNull();
            traktRecommendedBy.User.Images.Avatar.Should().NotBeNull();
            traktRecommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            traktRecommendedBy.User.IsVIP_OG.Should().BeTrue();
            traktRecommendedBy.User.VIP_Years.Should().Be(5);
            traktRecommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            traktRecommendedBy.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Not_Valid()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedBy.Should().NotBeNull();
            traktRecommendedBy.User.Should().BeNull();
            traktRecommendedBy.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Null()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();
            Func<Task<ITraktRecommendedBy>> traktRecommendedBy = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktRecommendedBy.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonReader_ReadObject_Empty()
        {
            var traktJsonReader = new RecommendedByObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedBy = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendedBy.Should().BeNull();
        }
    }
}
