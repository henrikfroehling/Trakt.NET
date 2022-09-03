namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Lists.JsonReader")]
    public partial class ListLikeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListLike.User.Should().NotBeNull();
                traktListLike.User.Username.Should().Be("justin");
                traktListLike.User.IsPrivate.Should().BeFalse();
                traktListLike.User.Name.Should().Be("Justin Nemeth");
                traktListLike.User.IsVIP.Should().BeTrue();
                traktListLike.User.IsVIP_EP.Should().BeTrue();
                traktListLike.User.Ids.Should().NotBeNull();
                traktListLike.User.Ids.Slug.Should().Be("justin");
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().BeNull();
                traktListLike.User.Should().NotBeNull();
                traktListLike.User.Username.Should().Be("justin");
                traktListLike.User.IsPrivate.Should().BeFalse();
                traktListLike.User.Name.Should().Be("Justin Nemeth");
                traktListLike.User.IsVIP.Should().BeTrue();
                traktListLike.User.IsVIP_EP.Should().BeTrue();
                traktListLike.User.Ids.Should().NotBeNull();
                traktListLike.User.Ids.Slug.Should().Be("justin");
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().BeNull();
                traktListLike.User.Should().NotBeNull();
                traktListLike.User.Username.Should().Be("justin");
                traktListLike.User.IsPrivate.Should().BeFalse();
                traktListLike.User.Name.Should().Be("Justin Nemeth");
                traktListLike.User.IsVIP.Should().BeTrue();
                traktListLike.User.IsVIP_EP.Should().BeTrue();
                traktListLike.User.Ids.Should().NotBeNull();
                traktListLike.User.Ids.Slug.Should().Be("justin");
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().BeNull();
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();
            Func<Task<ITraktListLike>> traktListLike = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktListLike.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListLikeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListLike = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktListLike.Should().BeNull();
            }
        }
    }
}
