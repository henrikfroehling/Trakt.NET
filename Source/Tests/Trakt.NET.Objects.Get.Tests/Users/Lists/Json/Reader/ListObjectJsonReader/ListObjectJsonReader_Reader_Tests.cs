namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().BeNull();

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().BeNull();

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_15()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_16()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_17()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_18()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_19()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_20()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_21()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_22()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_23()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_24()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_25()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_26()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().Be(2);
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_27()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_27))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_28()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_28))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().BeNull();

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_13()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().BeNull();

                traktList.User.Should().NotBeNull();
                traktList.User.Username.Should().Be("sean");
                traktList.User.IsPrivate.Should().BeFalse();
                traktList.User.Name.Should().Be("Sean Rudford");
                traktList.User.IsVIP.Should().BeTrue();
                traktList.User.IsVIP_EP.Should().BeFalse();
                traktList.User.Ids.Should().NotBeNull();
                traktList.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_14()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().Be("Star Wars in machete order");
                traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktList.Privacy.Should().Be(TraktAccessScope.Public);
                traktList.DisplayNumbers.Should().BeTrue();
                traktList.AllowComments.Should().BeFalse();
                traktList.SortBy.Should().Be("rank");
                traktList.SortHow.Should().Be("asc");
                traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktList.ItemCount.Should().Be(5);
                traktList.CommentCount.Should().Be(1);
                traktList.Likes.Should().Be(2);

                traktList.Ids.Should().NotBeNull();
                traktList.Ids.Trakt.Should().Be(55);
                traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_15()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktList.Should().NotBeNull();
                traktList.Name.Should().BeNull();
                traktList.Description.Should().BeNull();
                traktList.Privacy.Should().BeNull();
                traktList.DisplayNumbers.Should().BeNull();
                traktList.AllowComments.Should().BeNull();
                traktList.SortBy.Should().BeNull();
                traktList.SortHow.Should().BeNull();
                traktList.CreatedAt.Should().BeNull();
                traktList.UpdatedAt.Should().BeNull();
                traktList.ItemCount.Should().BeNull();
                traktList.CommentCount.Should().BeNull();
                traktList.Likes.Should().BeNull();
                traktList.Ids.Should().BeNull();
                traktList.User.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ListObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListObjectJsonReader();
            Func<Task<ITraktList>> traktList = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktList.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktList = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktList.Should().BeNull();
            }
        }
    }
}
