namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Person_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Person);
            traktListItem.Person.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
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

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Person);
            traktListItem.Person.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Person.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
        }
    }
}
