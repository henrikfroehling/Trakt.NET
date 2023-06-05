namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            traktUserHiddenItem.User.Should().NotBeNull();
            traktUserHiddenItem.User.Username.Should().Be("sean");
            traktUserHiddenItem.User.IsPrivate.Should().BeFalse();
            traktUserHiddenItem.User.Name.Should().Be("Sean Rudford");
            traktUserHiddenItem.User.IsVIP.Should().BeTrue();
            traktUserHiddenItem.User.IsVIP_EP.Should().BeTrue();
            traktUserHiddenItem.User.Ids.Should().NotBeNull();
            traktUserHiddenItem.User.Ids.Slug.Should().Be("sean");
            traktUserHiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            traktUserHiddenItem.User.Should().NotBeNull();
            traktUserHiddenItem.User.Username.Should().Be("sean");
            traktUserHiddenItem.User.IsPrivate.Should().BeFalse();
            traktUserHiddenItem.User.Name.Should().Be("Sean Rudford");
            traktUserHiddenItem.User.IsVIP.Should().BeTrue();
            traktUserHiddenItem.User.IsVIP_EP.Should().BeTrue();
            traktUserHiddenItem.User.Ids.Should().NotBeNull();
            traktUserHiddenItem.User.Ids.Slug.Should().Be("sean");
            traktUserHiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.User.Should().NotBeNull();
            traktUserHiddenItem.User.Username.Should().Be("sean");
            traktUserHiddenItem.User.IsPrivate.Should().BeFalse();
            traktUserHiddenItem.User.Name.Should().Be("Sean Rudford");
            traktUserHiddenItem.User.IsVIP.Should().BeTrue();
            traktUserHiddenItem.User.IsVIP_EP.Should().BeTrue();
            traktUserHiddenItem.User.Ids.Should().NotBeNull();
            traktUserHiddenItem.User.Ids.Slug.Should().Be("sean");
            traktUserHiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            traktUserHiddenItem.User.Should().BeNull();

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            traktUserHiddenItem.User.Should().NotBeNull();
            traktUserHiddenItem.User.Username.Should().Be("sean");
            traktUserHiddenItem.User.IsPrivate.Should().BeFalse();
            traktUserHiddenItem.User.Name.Should().Be("Sean Rudford");
            traktUserHiddenItem.User.IsVIP.Should().BeTrue();
            traktUserHiddenItem.User.IsVIP_EP.Should().BeTrue();
            traktUserHiddenItem.User.Ids.Should().NotBeNull();
            traktUserHiddenItem.User.Ids.Slug.Should().Be("sean");
            traktUserHiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.User.Should().NotBeNull();
            traktUserHiddenItem.User.Username.Should().Be("sean");
            traktUserHiddenItem.User.IsPrivate.Should().BeFalse();
            traktUserHiddenItem.User.Name.Should().Be("Sean Rudford");
            traktUserHiddenItem.User.IsVIP.Should().BeTrue();
            traktUserHiddenItem.User.IsVIP_EP.Should().BeTrue();
            traktUserHiddenItem.User.Ids.Should().NotBeNull();
            traktUserHiddenItem.User.Ids.Slug.Should().Be("sean");
            traktUserHiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            traktUserHiddenItem.User.Should().BeNull();

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_User_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using var reader = new StringReader(HIDDEN_ITEM_USER_JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.User.Should().BeNull();

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }
    }
}
