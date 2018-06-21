namespace TraktNet.Tests.Objects.Get.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_COMPLETE.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_1.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_2.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_3.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_4.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_5.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_6.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_7.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_8.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_1.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_2.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_3.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().NotBeNull();
                traktListItem.Person.Name.Should().Be("Bryan Cranston");
                traktListItem.Person.Ids.Should().NotBeNull();
                traktListItem.Person.Ids.Trakt.Should().Be(297737U);
                traktListItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktListItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktListItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktListItem.Person.Ids.TvRage.Should().Be(1797U);

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_4.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Person);
                traktListItem.Person.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_5.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
                traktListItem.Person.Should().BeNull();
                traktListItem.Movie.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
            }
        }
    }
}
