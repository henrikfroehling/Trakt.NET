namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktListItemObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
