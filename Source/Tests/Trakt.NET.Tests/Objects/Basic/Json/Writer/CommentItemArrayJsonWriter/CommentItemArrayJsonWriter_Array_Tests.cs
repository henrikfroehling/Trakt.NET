namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CommentItemArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CommentItemArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentItem>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCommentItem> traktCommentItems = new List<TraktCommentItem>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentItem>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentItems);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCommentItem> traktCommentItems = new List<ITraktCommentItem>
            {
                new TraktCommentItem
                {
                    Type = TraktObjectType.Movie,
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
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430,
                            Tvdb = 279121,
                            Tmdb = 60523,
                            TvRage = 36939
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentItem>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentItems);
            json.Should().Be(@"[{""type"":""movie""," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                             @"""season"":{""number"":1,""ids"":{" +
                             @"""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}," +
                             @"""episode"":{""season"":1,""number"":1," +
                             @"""title"":""Winter Is Coming"",""ids"":{" +
                             @"""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                             @"""tmdb"":63056,""tvrage"":1065008299}}," +
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
                             @"""vip"":true,""vip_ep"":true}}}]");
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCommentItem> traktCommentItems = new List<ITraktCommentItem>
            {
                new TraktCommentItem
                {
                    Type = TraktObjectType.Movie,
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
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430,
                            Tvdb = 279121,
                            Tmdb = 60523,
                            TvRage = 36939
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
                },
                new TraktCommentItem
                {
                    Type = TraktObjectType.Movie,
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
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430,
                            Tvdb = 279121,
                            Tmdb = 60523,
                            TvRage = 36939
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentItem>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentItems);
            json.Should().Be(@"[{""type"":""movie""," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                             @"""season"":{""number"":1,""ids"":{" +
                             @"""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}," +
                             @"""episode"":{""season"":1,""number"":1," +
                             @"""title"":""Winter Is Coming"",""ids"":{" +
                             @"""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                             @"""tmdb"":63056,""tvrage"":1065008299}}," +
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
                             @"""vip"":true,""vip_ep"":true}}}," +
                             @"{""type"":""movie""," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                             @"""season"":{""number"":1,""ids"":{" +
                             @"""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}," +
                             @"""episode"":{""season"":1,""number"":1," +
                             @"""title"":""Winter Is Coming"",""ids"":{" +
                             @"""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                             @"""tmdb"":63056,""tvrage"":1065008299}}," +
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
                             @"""vip"":true,""vip_ep"":true}}}]");
        }
    }
}
