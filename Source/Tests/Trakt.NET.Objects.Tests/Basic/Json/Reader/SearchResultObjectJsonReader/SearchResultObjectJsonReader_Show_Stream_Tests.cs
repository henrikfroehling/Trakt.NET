namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_3.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_4.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_5.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_6.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_4.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }
    }
}
