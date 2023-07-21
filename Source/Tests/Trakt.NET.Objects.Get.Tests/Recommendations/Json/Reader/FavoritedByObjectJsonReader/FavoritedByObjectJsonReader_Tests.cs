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
    public partial class FavoritedByObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktFavoritedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavoritedBy.Should().NotBeNull();
            traktFavoritedBy.User.Should().NotBeNull();
            traktFavoritedBy.User.Username.Should().Be("sean");
            traktFavoritedBy.User.IsPrivate.Should().BeFalse();
            traktFavoritedBy.User.Name.Should().Be("Sean Rudford");
            traktFavoritedBy.User.IsVIP.Should().BeTrue();
            traktFavoritedBy.User.IsVIP_EP.Should().BeTrue();
            traktFavoritedBy.User.Ids.Should().NotBeNull();
            traktFavoritedBy.User.Ids.Slug.Should().Be("sean");
            traktFavoritedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            traktFavoritedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            traktFavoritedBy.User.Location.Should().Be("SF");
            traktFavoritedBy.User.About.Should().Be("I have all your cassette tapes.");
            traktFavoritedBy.User.Gender.Should().Be("male");
            traktFavoritedBy.User.Age.Should().Be(35);
            traktFavoritedBy.User.Images.Should().NotBeNull();
            traktFavoritedBy.User.Images.Avatar.Should().NotBeNull();
            traktFavoritedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            traktFavoritedBy.User.IsVIP_OG.Should().BeTrue();
            traktFavoritedBy.User.VIP_Years.Should().Be(5);
            traktFavoritedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            traktFavoritedBy.Notes.Should().Be("Favorited because ...");
        }

        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktFavoritedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavoritedBy.Should().NotBeNull();
            traktFavoritedBy.User.Should().BeNull();
            traktFavoritedBy.Notes.Should().Be("Favorited because ...");
        }

        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktFavoritedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavoritedBy.Should().NotBeNull();
            traktFavoritedBy.User.Should().NotBeNull();
            traktFavoritedBy.User.Username.Should().Be("sean");
            traktFavoritedBy.User.IsPrivate.Should().BeFalse();
            traktFavoritedBy.User.Name.Should().Be("Sean Rudford");
            traktFavoritedBy.User.IsVIP.Should().BeTrue();
            traktFavoritedBy.User.IsVIP_EP.Should().BeTrue();
            traktFavoritedBy.User.Ids.Should().NotBeNull();
            traktFavoritedBy.User.Ids.Slug.Should().Be("sean");
            traktFavoritedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            traktFavoritedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            traktFavoritedBy.User.Location.Should().Be("SF");
            traktFavoritedBy.User.About.Should().Be("I have all your cassette tapes.");
            traktFavoritedBy.User.Gender.Should().Be("male");
            traktFavoritedBy.User.Age.Should().Be(35);
            traktFavoritedBy.User.Images.Should().NotBeNull();
            traktFavoritedBy.User.Images.Avatar.Should().NotBeNull();
            traktFavoritedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            traktFavoritedBy.User.IsVIP_OG.Should().BeTrue();
            traktFavoritedBy.User.VIP_Years.Should().Be(5);
            traktFavoritedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            traktFavoritedBy.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Not_Valid()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var traktFavoritedBy = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavoritedBy.Should().NotBeNull();
            traktFavoritedBy.User.Should().BeNull();
            traktFavoritedBy.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Null()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();
            Func<Task<ITraktFavoritedBy>> traktFavoritedBy = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktFavoritedBy.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_FavoritedByObjectJsonReader_ReadObject_Empty()
        {
            var traktJsonReader = new FavoritedByObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktFavoritedBy = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktFavoritedBy.Should().BeNull();
        }
    }
}
