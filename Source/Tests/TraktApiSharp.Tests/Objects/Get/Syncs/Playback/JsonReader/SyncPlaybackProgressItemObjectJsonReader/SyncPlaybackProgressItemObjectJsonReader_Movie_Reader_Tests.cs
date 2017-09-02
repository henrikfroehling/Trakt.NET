namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktPlaybackProgressItem.Movie.Year.Should().Be(2015);
                traktPlaybackProgressItem.Movie.Ids.Should().NotBeNull();
                traktPlaybackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktPlaybackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktPlaybackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktPlaybackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(37U);
                traktPlaybackProgressItem.Progress.Should().Be(65.5f);
                traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
                traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Movie);
                traktPlaybackProgressItem.Movie.Should().BeNull();

                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPlaybackProgressItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPlaybackProgressItem.Should().NotBeNull();
                traktPlaybackProgressItem.Id.Should().Be(0U);
                traktPlaybackProgressItem.Progress.Should().BeNull();
                traktPlaybackProgressItem.PausedAt.Should().BeNull();
                traktPlaybackProgressItem.Type.Should().BeNull();
                traktPlaybackProgressItem.Movie.Should().BeNull();
                traktPlaybackProgressItem.Show.Should().BeNull();
                traktPlaybackProgressItem.Episode.Should().BeNull();
            }
        }
    }
}
