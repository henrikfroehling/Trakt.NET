namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Person.Should().NotBeNull();
                traktSearchResultItem.Person.Name.Should().Be("Bryan Cranston");
                traktSearchResultItem.Person.Ids.Should().NotBeNull();
                traktSearchResultItem.Person.Ids.Trakt.Should().Be(297737U);
                traktSearchResultItem.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktSearchResultItem.Person.Ids.Imdb.Should().Be("nm0186505");
                traktSearchResultItem.Person.Ids.Tmdb.Should().Be(17419U);
                traktSearchResultItem.Person.Ids.TvRage.Should().Be(1797U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Person);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Person.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Person_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_PERSON_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }
    }
}
