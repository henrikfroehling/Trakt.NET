namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktUserComment_Tests
    {
        [Fact]
        public void Test_TraktUserComment_Default_Constructor()
        {
            var userComment = new TraktUserComment();

            userComment.Type.Should().BeNull();
            userComment.Comment.Should().BeNull();
            userComment.Movie.Should().BeNull();
            userComment.Show.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.Episode.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserComment_With_Type_Movie_From_Json()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            var userComment = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON) as TraktUserComment;

            userComment.Should().NotBeNull();
            userComment.Type.Should().Be(TraktObjectType.Movie);
            userComment.Comment.Should().NotBeNull();
            userComment.Comment.Id.Should().Be(76957U);
            userComment.Comment.ParentId.Should().Be(1234U);
            userComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            userComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            userComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.Spoiler.Should().BeFalse();
            userComment.Comment.Review.Should().BeFalse();
            userComment.Comment.Replies.Should().Be(1);
            userComment.Comment.Likes.Should().Be(2);
            userComment.Comment.UserStats.Should().NotBeNull();
            userComment.Comment.UserStats.Rating.Should().Be(8);
            userComment.Comment.UserStats.PlayCount.Should().Be(1);
            userComment.Comment.UserStats.CompletedCount.Should().Be(1);
            userComment.Comment.User.Should().NotBeNull();
            userComment.Comment.User.Username.Should().Be("sean");
            userComment.Comment.User.IsPrivate.Should().BeFalse();
            userComment.Comment.User.Name.Should().Be("Sean Rudford");
            userComment.Comment.User.IsVIP.Should().BeTrue();
            userComment.Comment.User.IsVIP_EP.Should().BeTrue();
            userComment.Comment.User.Ids.Should().NotBeNull();
            userComment.Comment.User.Ids.Slug.Should().Be("sean");
            userComment.Movie.Should().NotBeNull();
            userComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            userComment.Movie.Year.Should().Be(2015);
            userComment.Movie.Ids.Should().NotBeNull();
            userComment.Movie.Ids.Trakt.Should().Be(94024U);
            userComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            userComment.Movie.Ids.Imdb.Should().Be("tt2488496");
            userComment.Movie.Ids.Tmdb.Should().Be(140607U);
            userComment.Show.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.Episode.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserComment_With_Type_Show_From_Json()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            var userComment = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON) as TraktUserComment;

            userComment.Should().NotBeNull();
            userComment.Type.Should().Be(TraktObjectType.Show);
            userComment.Comment.Should().NotBeNull();
            userComment.Comment.Id.Should().Be(76957U);
            userComment.Comment.ParentId.Should().Be(1234U);
            userComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            userComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            userComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.Spoiler.Should().BeFalse();
            userComment.Comment.Review.Should().BeFalse();
            userComment.Comment.Replies.Should().Be(1);
            userComment.Comment.Likes.Should().Be(2);
            userComment.Comment.UserStats.Should().NotBeNull();
            userComment.Comment.UserStats.Rating.Should().Be(8);
            userComment.Comment.UserStats.PlayCount.Should().Be(1);
            userComment.Comment.UserStats.CompletedCount.Should().Be(1);
            userComment.Comment.User.Should().NotBeNull();
            userComment.Comment.User.Username.Should().Be("sean");
            userComment.Comment.User.IsPrivate.Should().BeFalse();
            userComment.Comment.User.Name.Should().Be("Sean Rudford");
            userComment.Comment.User.IsVIP.Should().BeTrue();
            userComment.Comment.User.IsVIP_EP.Should().BeTrue();
            userComment.Comment.User.Ids.Should().NotBeNull();
            userComment.Comment.User.Ids.Slug.Should().Be("sean");
            userComment.Show.Should().NotBeNull();
            userComment.Show.Title.Should().Be("Game of Thrones");
            userComment.Show.Year.Should().Be(2011);
            userComment.Show.Ids.Should().NotBeNull();
            userComment.Show.Ids.Trakt.Should().Be(1390U);
            userComment.Show.Ids.Slug.Should().Be("game-of-thrones");
            userComment.Show.Ids.Tvdb.Should().Be(121361U);
            userComment.Show.Ids.Imdb.Should().Be("tt0944947");
            userComment.Show.Ids.Tmdb.Should().Be(1399U);
            userComment.Show.Ids.TvRage.Should().Be(24493U);
            userComment.Movie.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.Episode.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserComment_With_Type_Season_From_Json()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            var userComment = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON) as TraktUserComment;

            userComment.Should().NotBeNull();
            userComment.Type.Should().Be(TraktObjectType.Season);
            userComment.Comment.Should().NotBeNull();
            userComment.Comment.Id.Should().Be(76957U);
            userComment.Comment.ParentId.Should().Be(1234U);
            userComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            userComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            userComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.Spoiler.Should().BeFalse();
            userComment.Comment.Review.Should().BeFalse();
            userComment.Comment.Replies.Should().Be(1);
            userComment.Comment.Likes.Should().Be(2);
            userComment.Comment.UserStats.Should().NotBeNull();
            userComment.Comment.UserStats.Rating.Should().Be(8);
            userComment.Comment.UserStats.PlayCount.Should().Be(1);
            userComment.Comment.UserStats.CompletedCount.Should().Be(1);
            userComment.Comment.User.Should().NotBeNull();
            userComment.Comment.User.Username.Should().Be("sean");
            userComment.Comment.User.IsPrivate.Should().BeFalse();
            userComment.Comment.User.Name.Should().Be("Sean Rudford");
            userComment.Comment.User.IsVIP.Should().BeTrue();
            userComment.Comment.User.IsVIP_EP.Should().BeTrue();
            userComment.Comment.User.Ids.Should().NotBeNull();
            userComment.Comment.User.Ids.Slug.Should().Be("sean");
            userComment.Season.Should().NotBeNull();
            userComment.Season.Number.Should().Be(1);
            userComment.Season.Title.Should().BeNullOrEmpty();
            userComment.Season.Ids.Should().NotBeNull();
            userComment.Season.Ids.Trakt.Should().Be(61430U);
            userComment.Season.Ids.Tvdb.Should().Be(279121U);
            userComment.Season.Ids.Tmdb.Should().Be(60523U);
            userComment.Season.Ids.TvRage.Should().Be(36939U);
            userComment.Movie.Should().BeNull();
            userComment.Show.Should().BeNull();
            userComment.Episode.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserComment_With_Type_Episode_From_Json()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            var userComment = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON) as TraktUserComment;

            userComment.Should().NotBeNull();
            userComment.Type.Should().Be(TraktObjectType.Episode);
            userComment.Comment.Should().NotBeNull();
            userComment.Comment.Id.Should().Be(76957U);
            userComment.Comment.ParentId.Should().Be(1234U);
            userComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            userComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            userComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.Spoiler.Should().BeFalse();
            userComment.Comment.Review.Should().BeFalse();
            userComment.Comment.Replies.Should().Be(1);
            userComment.Comment.Likes.Should().Be(2);
            userComment.Comment.UserStats.Should().NotBeNull();
            userComment.Comment.UserStats.Rating.Should().Be(8);
            userComment.Comment.UserStats.PlayCount.Should().Be(1);
            userComment.Comment.UserStats.CompletedCount.Should().Be(1);
            userComment.Comment.User.Should().NotBeNull();
            userComment.Comment.User.Username.Should().Be("sean");
            userComment.Comment.User.IsPrivate.Should().BeFalse();
            userComment.Comment.User.Name.Should().Be("Sean Rudford");
            userComment.Comment.User.IsVIP.Should().BeTrue();
            userComment.Comment.User.IsVIP_EP.Should().BeTrue();
            userComment.Comment.User.Ids.Should().NotBeNull();
            userComment.Comment.User.Ids.Slug.Should().Be("sean");
            userComment.Episode.Should().NotBeNull();
            userComment.Episode.SeasonNumber.Should().Be(1);
            userComment.Episode.Number.Should().Be(1);
            userComment.Episode.Title.Should().Be("Winter Is Coming");
            userComment.Episode.Ids.Should().NotBeNull();
            userComment.Episode.Ids.Trakt.Should().Be(73640U);
            userComment.Episode.Ids.Tvdb.Should().Be(3254641U);
            userComment.Episode.Ids.Imdb.Should().Be("tt1480055");
            userComment.Episode.Ids.Tmdb.Should().Be(63056U);
            userComment.Episode.Ids.TvRage.Should().Be(1065008299U);
            userComment.Show.Should().NotBeNull();
            userComment.Show.Title.Should().Be("Game of Thrones");
            userComment.Show.Year.Should().Be(2011);
            userComment.Show.Ids.Should().NotBeNull();
            userComment.Show.Ids.Trakt.Should().Be(1390U);
            userComment.Show.Ids.Slug.Should().Be("game-of-thrones");
            userComment.Show.Ids.Tvdb.Should().Be(121361U);
            userComment.Show.Ids.Imdb.Should().Be("tt0944947");
            userComment.Show.Ids.Tmdb.Should().Be(1399U);
            userComment.Show.Ids.TvRage.Should().Be(24493U);
            userComment.Movie.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserComment_With_Type_List_From_Json()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            var userComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON) as TraktUserComment;

            userComment.Should().NotBeNull();
            userComment.Type.Should().Be(TraktObjectType.List);
            userComment.Comment.Should().NotBeNull();
            userComment.Comment.Id.Should().Be(76957U);
            userComment.Comment.ParentId.Should().Be(1234U);
            userComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            userComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            userComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            userComment.Comment.Spoiler.Should().BeFalse();
            userComment.Comment.Review.Should().BeFalse();
            userComment.Comment.Replies.Should().Be(1);
            userComment.Comment.Likes.Should().Be(2);
            userComment.Comment.UserStats.Should().NotBeNull();
            userComment.Comment.UserStats.Rating.Should().Be(8);
            userComment.Comment.UserStats.PlayCount.Should().Be(1);
            userComment.Comment.UserStats.CompletedCount.Should().Be(1);
            userComment.Comment.User.Should().NotBeNull();
            userComment.Comment.User.Username.Should().Be("sean");
            userComment.Comment.User.IsPrivate.Should().BeFalse();
            userComment.Comment.User.Name.Should().Be("Sean Rudford");
            userComment.Comment.User.IsVIP.Should().BeTrue();
            userComment.Comment.User.IsVIP_EP.Should().BeTrue();
            userComment.Comment.User.Ids.Should().NotBeNull();
            userComment.Comment.User.Ids.Slug.Should().Be("sean");
            userComment.List.Should().NotBeNull();
            userComment.List.Name.Should().Be("Star Wars in machete order");
            userComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            userComment.List.Privacy.Should().Be(TraktListPrivacy.Public);
            userComment.List.DisplayNumbers.Should().BeTrue();
            userComment.List.AllowComments.Should().BeFalse();
            userComment.List.SortBy.Should().Be(TraktSortBy.Rank);
            userComment.List.SortHow.Should().Be(TraktSortHow.Ascending);
            userComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            userComment.List.ItemCount.Should().Be(5);
            userComment.List.CommentCount.Should().Be(1);
            userComment.List.Likes.Should().Be(2);
            userComment.List.Ids.Should().NotBeNull();
            userComment.List.Ids.Trakt.Should().Be(55);
            userComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            userComment.List.User.Should().NotBeNull();
            userComment.List.User.Username.Should().Be("sean");
            userComment.List.User.IsPrivate.Should().BeFalse();
            userComment.List.User.Name.Should().Be("Sean Rudford");
            userComment.List.User.IsVIP.Should().BeTrue();
            userComment.List.User.IsVIP_EP.Should().BeFalse();
            userComment.List.User.Ids.Should().NotBeNull();
            userComment.List.User.Ids.Slug.Should().Be("sean");
            userComment.Movie.Should().BeNull();
            userComment.Show.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.Episode.Should().BeNull();
        }

        private const string TYPE_MOVIE_JSON =
            @"{
                ""type"": ""movie"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
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

        private const string TYPE_SEASON_JSON =
            @"{
                ""type"": ""season"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_EPISODE_JSON =
            @"{
                ""type"": ""episode"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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

        private const string TYPE_LIST_JSON =
            @"{
                ""type"": ""list"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
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
