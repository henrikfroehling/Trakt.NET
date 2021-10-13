namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListLikeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);

                traktListLike.Should().NotBeNull();
                traktListLike.LikedAt.Should().BeNull();
                traktListLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ListLikeObjectJsonReader();
            Func<Task<ITraktListLike>> traktListLike = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktListLike.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListLikeObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ListLikeObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktListLike = await jsonReader.ReadObjectAsync(stream);
                traktListLike.Should().BeNull();
            }
        }
    }
}
