﻿namespace TraktNet.Objects.Tests.Post.Users.CustomListItems.Responses.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.CustomListItems.Responses;
    using TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Implementations")]
    public class TraktUserCustomListItemsPostResponse_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsPostResponse_Default_Constructor()
        {
            var customListItemsPostResponse = new TraktUserCustomListItemsPostResponse();

            customListItemsPostResponse.Added.Should().BeNull();
            customListItemsPostResponse.Existing.Should().BeNull();
            customListItemsPostResponse.NotFound.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponse_From_Json()
        {
            var jsonReader = new UserCustomListItemsPostResponseObjectJsonReader();
            var customListItemsPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktUserCustomListItemsPostResponse;

            customListItemsPostResponse.Should().NotBeNull();

            customListItemsPostResponse.Added.Should().NotBeNull();
            customListItemsPostResponse.Added.Movies.Should().Be(1);
            customListItemsPostResponse.Added.Shows.Should().Be(2);
            customListItemsPostResponse.Added.Seasons.Should().Be(3);
            customListItemsPostResponse.Added.Episodes.Should().Be(4);
            customListItemsPostResponse.Added.People.Should().Be(5);

            customListItemsPostResponse.Existing.Should().NotBeNull();
            customListItemsPostResponse.Existing.Movies.Should().Be(1);
            customListItemsPostResponse.Existing.Shows.Should().Be(2);
            customListItemsPostResponse.Existing.Seasons.Should().Be(3);
            customListItemsPostResponse.Existing.Episodes.Should().Be(4);
            customListItemsPostResponse.Existing.People.Should().Be(5);

            customListItemsPostResponse.NotFound.Should().NotBeNull();

            var notFound = customListItemsPostResponse.NotFound;
            notFound.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var movies = notFound.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(94024U);
            movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movies[0].Ids.Imdb.Should().Be("tt2488496");
            movies[0].Ids.Tmdb.Should().Be(140607U);

            movies[1].Should().NotBeNull();
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(172687U);
            movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
            movies[1].Ids.Imdb.Should().Be("tt1972591");
            movies[1].Ids.Tmdb.Should().Be(274857U);

            // --------------------------------------------------

            notFound.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var shows = notFound.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1390U);
            shows[0].Ids.Slug.Should().Be("game-of-thrones");
            shows[0].Ids.Tvdb.Should().Be(121361U);
            shows[0].Ids.Imdb.Should().Be("tt0944947");
            shows[0].Ids.Tmdb.Should().Be(1399U);
            shows[0].Ids.TvRage.Should().Be(24493U);

            shows[1].Should().NotBeNull();
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(60300U);
            shows[1].Ids.Slug.Should().Be("the-flash-2014");
            shows[1].Ids.Tvdb.Should().Be(279121U);
            shows[1].Ids.Imdb.Should().Be("tt3107288");
            shows[1].Ids.Tmdb.Should().Be(60735U);
            shows[1].Ids.TvRage.Should().Be(36939U);

            // --------------------------------------------------

            notFound.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var seasons = notFound.Seasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Ids.Should().NotBeNull();
            seasons[0].Ids.Trakt.Should().Be(61430U);
            seasons[0].Ids.Tvdb.Should().Be(279121U);
            seasons[0].Ids.Tmdb.Should().Be(60523U);
            seasons[0].Ids.TvRage.Should().Be(36939U);

            seasons[1].Should().NotBeNull();
            seasons[1].Ids.Should().NotBeNull();
            seasons[1].Ids.Trakt.Should().Be(61431U);
            seasons[1].Ids.Tvdb.Should().Be(578373U);
            seasons[1].Ids.Tmdb.Should().Be(60524U);
            seasons[1].Ids.TvRage.Should().Be(36940U);

            // --------------------------------------------------

            notFound.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodes = notFound.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);

            episodes[1].Should().NotBeNull();
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(73641U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63057U);
            episodes[1].Ids.TvRage.Should().Be(1065023912U);

            // --------------------------------------------------

            notFound.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var people = notFound.People.ToArray();

            people[0].Should().NotBeNull();
            people[0].Ids.Should().NotBeNull();
            people[0].Ids.Trakt.Should().Be(297737U);
            people[0].Ids.Slug.Should().Be("bryan-cranston");
            people[0].Ids.Imdb.Should().Be("nm0186505");
            people[0].Ids.Tmdb.Should().Be(17419U);
            people[0].Ids.TvRage.Should().Be(1797U);

            people[1].Should().NotBeNull();
            people[1].Ids.Should().NotBeNull();
            people[1].Ids.Trakt.Should().Be(9486U);
            people[1].Ids.Slug.Should().Be("samuel-l-jackson");
            people[1].Ids.Imdb.Should().Be("nm0000168");
            people[1].Ids.Tmdb.Should().Be(2231U);
            people[1].Ids.TvRage.Should().Be(55720U);
        }

        private const string JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""existing"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4,
                  ""people"": 5
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      }
                    },
                    {
                      ""ids"": {
                        ""trakt"": 172687,
                        ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                        ""imdb"": ""tt1972591"",
                        ""tmdb"": 274857
                      }
                    }
                  ],
                  ""shows"": [
                    {
                      ""ids"": {
                        ""trakt"": 1390,
                        ""slug"": ""game-of-thrones"",
                        ""tvdb"": 121361,
                        ""imdb"": ""tt0944947"",
                        ""tmdb"": 1399,
                        ""tvrage"": 24493
                      }
                    },
                    {
                      ""ids"": {
                        ""trakt"": 60300,
                        ""slug"": ""the-flash-2014"",
                        ""tvdb"": 279121,
                        ""imdb"": ""tt3107288"",
                        ""tmdb"": 60735,
                        ""tvrage"": 36939
                      }
                    }
                  ],
                  ""seasons"": [
                    {
                      ""ids"": {
                        ""trakt"": 61430,
                        ""tvdb"": 279121,
                        ""tmdb"": 60523,
                        ""tvrage"": 36939
                      }
                    },
                    {
                      ""ids"": {
                        ""trakt"": 61431,
                        ""tvdb"": 578373,
                        ""tmdb"": 60524,
                        ""tvrage"": 36940
                      }
                    }
                  ],
                  ""episodes"": [
                    {
                      ""ids"": {
                        ""trakt"": 73640,
                        ""tvdb"": 3254641,
                        ""imdb"": ""tt1480055"",
                        ""tmdb"": 63056,
                        ""tvrage"": 1065008299
                      }
                    },
                    {
                      ""ids"": {
                        ""trakt"": 73641,
                        ""tvdb"": 3436411,
                        ""imdb"": ""tt1668746"",
                        ""tmdb"": 63057,
                        ""tvrage"": 1065023912
                      }
                    }
                  ],
                  ""people"": [
                    {
                      ""ids"": {
                        ""trakt"": 297737,
                        ""slug"": ""bryan-cranston"",
                        ""imdb"": ""nm0186505"",
                        ""tmdb"": 17419,
                        ""tvrage"": 1797
                      }
                    },
                    {
                      ""ids"": {
                        ""trakt"": 9486,
                        ""slug"": ""samuel-l-jackson"",
                        ""imdb"": ""nm0000168"",
                        ""tmdb"": 2231,
                        ""tvrage"": 55720
                      }
                    }
                  ]
                }
              }";
    }
}
