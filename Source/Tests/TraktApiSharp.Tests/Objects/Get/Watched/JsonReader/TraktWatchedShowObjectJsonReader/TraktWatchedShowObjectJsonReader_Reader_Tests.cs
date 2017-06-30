namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class TraktWatchedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().BeNull();

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().BeNull();

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().BeNull();
                traktWatchedShow.Show.Should().BeNull();
                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().BeNull();
                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().BeNull();

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().BeNull();
                traktWatchedShow.Show.Should().BeNull();

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().BeNull();

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().BeNull();

                traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktWatchedShow.WatchedSeasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = seasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = seasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().Be(1);
                traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktWatchedShow.Show.Should().NotBeNull();
                traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
                traktWatchedShow.Show.Year.Should().Be(2011);
                traktWatchedShow.Show.Ids.Should().NotBeNull();
                traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShow.Should().NotBeNull();
                traktWatchedShow.Plays.Should().BeNull();
                traktWatchedShow.LastWatchedAt.Should().BeNull();
                traktWatchedShow.Show.Should().BeNull();
                traktWatchedShow.WatchedSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            var traktWatchedShow = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktWatchedShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchedShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktWatchedShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchedShow.Should().BeNull();
            }
        }
    }
}
