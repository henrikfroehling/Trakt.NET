﻿namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class EpisodeCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().NotBeNull();
                checkinEpisodeResponse.Show.Title.Should().Be("Game of Thrones");
                checkinEpisodeResponse.Show.Year.Should().Be(2011);
                checkinEpisodeResponse.Show.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Show.Ids.Trakt.Should().Be(1390U);
                checkinEpisodeResponse.Show.Ids.Slug.Should().Be("game-of-thrones");
                checkinEpisodeResponse.Show.Ids.Tvdb.Should().Be(121361U);
                checkinEpisodeResponse.Show.Ids.Imdb.Should().Be("tt0944947");
                checkinEpisodeResponse.Show.Ids.Tmdb.Should().Be(1399U);
                checkinEpisodeResponse.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(3373536620UL);
                checkinEpisodeResponse.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
                checkinEpisodeResponse.Sharing.Should().NotBeNull();
                checkinEpisodeResponse.Sharing.Twitter.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Google.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Tumblr.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Medium.Should().BeTrue();
                checkinEpisodeResponse.Sharing.Slack.Should().BeTrue();
                checkinEpisodeResponse.Episode.Should().NotBeNull();
                checkinEpisodeResponse.Episode.SeasonNumber.Should().Be(1);
                checkinEpisodeResponse.Episode.Number.Should().Be(1);
                checkinEpisodeResponse.Episode.Title.Should().Be("Winter Is Coming");
                checkinEpisodeResponse.Episode.Ids.Should().NotBeNull();
                checkinEpisodeResponse.Episode.Ids.Trakt.Should().Be(73640U);
                checkinEpisodeResponse.Episode.Ids.Tvdb.Should().Be(3254641U);
                checkinEpisodeResponse.Episode.Ids.Imdb.Should().Be("tt1480055");
                checkinEpisodeResponse.Episode.Ids.Tmdb.Should().Be(63056U);
                checkinEpisodeResponse.Episode.Ids.TvRage.Should().Be(1065008299U);
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);

                checkinEpisodeResponse.Should().NotBeNull();
                checkinEpisodeResponse.Id.Should().Be(0UL);
                checkinEpisodeResponse.WatchedAt.Should().BeNull();
                checkinEpisodeResponse.Sharing.Should().BeNull();
                checkinEpisodeResponse.Episode.Should().BeNull();
                checkinEpisodeResponse.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();
            Func<Task<ITraktEpisodeCheckinPostResponse>> checkinEpisodeResponse = () => jsonReader.ReadObjectAsync(default(Stream));
            await checkinEpisodeResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCheckinPostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new EpisodeCheckinPostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var checkinEpisodeResponse = await jsonReader.ReadObjectAsync(stream);
                checkinEpisodeResponse.Should().BeNull();
            }
        }
    }
}
