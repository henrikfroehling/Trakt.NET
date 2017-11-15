namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Json
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists.Json;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_23()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_23.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_24()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_24.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_25()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_25.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_26()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_26.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_27()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_27.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Incomplete_28()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_28.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_13()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_13.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_14()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_14.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Not_Valid_15()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = JSON_NOT_VALID_15.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(default(Stream));
            traktList.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ListObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktList = await jsonReader.ReadObjectAsync(stream);
                traktList.Should().BeNull();
            }
        }
    }
}
