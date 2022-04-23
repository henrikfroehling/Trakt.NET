﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class SearchResultObjectJsonWriter_Tests
    {
        private readonly DateTime CREATED_UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SearchResultObjectJsonWriter();
            ITraktSearchResult traktSearchResult = new TraktSearchResult();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSearchResult);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Type_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Type = TraktSearchResultType.Movie
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""type"":""movie""}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Score_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Score = 7.3f
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""score"":7.3}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Movie_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                                                    @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Show_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Show = new TraktShow
                {
                    Title = "Game of Thrones",
                    Year = 2011,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1390,
                        Slug = "game-of-thrones",
                        Tvdb = 121361,
                        Imdb = "tt0944947",
                        Tmdb = 1399,
                        TvRage = 24493
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                                                    @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Episode_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Episode = new TraktEpisode
                {
                    SeasonNumber = 1,
                    Number = 1,
                    Title = "Winter Is Coming",
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 73640,
                        Tvdb = 3254641,
                        Imdb = "tt1480055",
                        Tmdb = 63056,
                        TvRage = 1065008299
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""episode"":{""season"":1,""number"":1," +
                                                    @"""title"":""Winter Is Coming"",""ids"":{" +
                                                    @"""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                                                    @"""tmdb"":63056,""tvrage"":1065008299}}}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_Person_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737U,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419U,
                        TvRage = 1797U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Only_List_Property()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                List = new TraktList
                {
                    Name = "Star Wars in machete order",
                    Description = "Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.",
                    Privacy = TraktAccessScope.Public,
                    DisplayNumbers = true,
                    AllowComments = true,
                    SortBy = "rank",
                    SortHow = "asc",
                    CreatedAt = CREATED_UPDATED_AT,
                    UpdatedAt = CREATED_UPDATED_AT,
                    ItemCount = 5,
                    CommentCount = 1,
                    Likes = 2,
                    Ids = new TraktListIds
                    {
                        Trakt = 55,
                        Slug = "star-wars-in-machete-order"
                    },
                    User = new TraktUser
                    {
                        Username = "sean",
                        IsPrivate = false,
                        Name = "Sean Rudford",
                        IsVIP = true,
                        IsVIP_EP = true,
                        Ids = new TraktUserIds
                        {
                            Slug = "sean"
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""list"":{""name"":""Star Wars in machete order""," +
                                                    @"""description"":""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.""," +
                                                    @"""privacy"":""public"",""display_numbers"":true,""allow_comments"":true," +
                                                    @"""sort_by"":""rank"",""sort_how"":""asc""," +
                                                    $"\"created_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""item_count"":5,""comment_count"":1,""likes"":2," +
                                                    @"""ids"":{""trakt"":55,""slug"":""star-wars-in-machete-order""}," +
                                                    @"""user"":{""username"":""sean"",""private"":false," +
                                                    @"""ids"":{""slug"":""sean""},""name"":""Sean Rudford""," +
                                                    @"""vip"":true,""vip_ep"":true}}}");
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSearchResult traktSearchResult = new TraktSearchResult
            {
                Type = TraktSearchResultType.Movie,
                Score = 7.3f,
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607
                    }
                },
                Show = new TraktShow
                {
                    Title = "Game of Thrones",
                    Year = 2011,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1390,
                        Slug = "game-of-thrones",
                        Tvdb = 121361,
                        Imdb = "tt0944947",
                        Tmdb = 1399,
                        TvRage = 24493
                    }
                },
                Episode = new TraktEpisode
                {
                    SeasonNumber = 1,
                    Number = 1,
                    Title = "Winter Is Coming",
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 73640,
                        Tvdb = 3254641,
                        Imdb = "tt1480055",
                        Tmdb = 63056,
                        TvRage = 1065008299
                    }
                },
                Person = new TraktPerson
                {
                    Name = "Bryan Cranston",
                    Ids = new TraktPersonIds
                    {
                        Trakt = 297737U,
                        Slug = "bryan-cranston",
                        Imdb = "nm0186505",
                        Tmdb = 17419U,
                        TvRage = 1797U
                    }
                },
                List = new TraktList
                {
                    Name = "Star Wars in machete order",
                    Description = "Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.",
                    Privacy = TraktAccessScope.Public,
                    DisplayNumbers = true,
                    AllowComments = true,
                    SortBy = "rank",
                    SortHow = "asc",
                    CreatedAt = CREATED_UPDATED_AT,
                    UpdatedAt = CREATED_UPDATED_AT,
                    ItemCount = 5,
                    CommentCount = 1,
                    Likes = 2,
                    Ids = new TraktListIds
                    {
                        Trakt = 55,
                        Slug = "star-wars-in-machete-order"
                    },
                    User = new TraktUser
                    {
                        Username = "sean",
                        IsPrivate = false,
                        Name = "Sean Rudford",
                        IsVIP = true,
                        IsVIP_EP = true,
                        Ids = new TraktUserIds
                        {
                            Slug = "sean"
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SearchResultObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSearchResult);
                stringWriter.ToString().Should().Be(@"{""type"":""movie"",""score"":7.3," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                                                    @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                                                    @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                                                    @"""episode"":{""season"":1,""number"":1," +
                                                    @"""title"":""Winter Is Coming"",""ids"":{" +
                                                    @"""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                                                    @"""tmdb"":63056,""tvrage"":1065008299}}," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}," +
                                                    @"""list"":{""name"":""Star Wars in machete order""," +
                                                    @"""description"":""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.""," +
                                                    @"""privacy"":""public"",""display_numbers"":true,""allow_comments"":true," +
                                                    @"""sort_by"":""rank"",""sort_how"":""asc""," +
                                                    $"\"created_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""item_count"":5,""comment_count"":1,""likes"":2," +
                                                    @"""ids"":{""trakt"":55,""slug"":""star-wars-in-machete-order""}," +
                                                    @"""user"":{""username"":""sean"",""private"":false," +
                                                    @"""ids"":{""slug"":""sean""},""name"":""Sean Rudford""," +
                                                    @"""vip"":true,""vip_ep"":true}}}");
            }
        }
    }
}
