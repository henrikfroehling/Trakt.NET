namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktSearchResult_Tests
    {
        [Fact]
        public void Test_TraktSearchResult_Implements_ITraktSearchResult_Interface()
        {
            typeof(TraktSearchResult).GetInterfaces().Should().Contain(typeof(ITraktSearchResult));
        }

        [Fact]
        public void Test_TraktSearchResult_Default_Constructor()
        {
            var traktSearchResultItem = new TraktSearchResult();

            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().NotHaveValue();
            traktSearchResultItem.Movie.Should().BeNull();
            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResult_With_Type_Movie_From_Json()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();
            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON) as TraktSearchResult;

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResult_With_Type_Show_From_Json()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();
            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON) as TraktSearchResult;

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

        [Fact]
        public async Task Test_TraktSearchResult_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();
            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON) as TraktSearchResult;

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Episode);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Episode.Should().NotBeNull();
            traktSearchResultItem.Episode.SeasonNumber.Should().Be(1);
            traktSearchResultItem.Episode.Number.Should().Be(1);
            traktSearchResultItem.Episode.Title.Should().Be("Winter Is Coming");
            traktSearchResultItem.Episode.Ids.Should().NotBeNull();
            traktSearchResultItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktSearchResultItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktSearchResultItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktSearchResultItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktSearchResultItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            traktSearchResultItem.Person.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResult_With_Type_Person_From_Json()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();
            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_PERSON_JSON) as TraktSearchResult;

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

        [Fact]
        public async Task Test_TraktSearchResult_With_Type_List_From_Json()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();
            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON) as TraktSearchResult;

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.List.Should().NotBeNull();
            traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
            traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
            traktSearchResultItem.List.AllowComments.Should().BeFalse();
            traktSearchResultItem.List.SortBy.Should().Be("rank");
            traktSearchResultItem.List.SortHow.Should().Be("asc");
            traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktSearchResultItem.List.ItemCount.Should().Be(5);
            traktSearchResultItem.List.CommentCount.Should().Be(1);
            traktSearchResultItem.List.Likes.Should().Be(2);
            traktSearchResultItem.List.Ids.Should().NotBeNull();
            traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
            traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktSearchResultItem.List.User.Should().NotBeNull();
            traktSearchResultItem.List.User.Username.Should().Be("sean");
            traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
            traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
            traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
            traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
            traktSearchResultItem.List.User.Ids.Should().NotBeNull();
            traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

            traktSearchResultItem.Movie.Should().BeNull();
            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        private const string TYPE_MOVIE_JSON =
            @"{
                ""type"": ""movie"",
                ""score"": 46.29501,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_SHOW_JSON =
            @"{
                ""type"": ""show"",
                ""score"": 46.29501,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_EPISODE_JSON =
            @"{
                ""type"": ""episode"",
                ""score"": 46.29501,
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_PERSON_JSON =
            @"{
                ""type"": ""person"",
                ""score"": 46.29501,
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_LIST_JSON =
            @"{
                ""type"": ""list"",
                ""score"": 46.29501,
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";
    }
}
