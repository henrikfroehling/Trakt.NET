namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982346UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982346UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982346UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982346UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(1982346UL);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(1982346UL);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_Movie_Read_Array_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var historyItems = traktHistoryItems.ToArray();

                historyItems[0].Should().NotBeNull();
                historyItems[0].Id.Should().Be(0);
                historyItems[0].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[0].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[0].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[0].Movie.Should().NotBeNull();
                historyItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[0].Movie.Year.Should().Be(2015);
                historyItems[0].Movie.Ids.Should().NotBeNull();
                historyItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[0].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[0].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[0].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[0].Movie.Released.Should().NotHaveValue();
                historyItems[0].Movie.Runtime.Should().NotHaveValue();
                historyItems[0].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[0].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[0].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[0].Movie.Rating.Should().NotHaveValue();
                historyItems[0].Movie.Votes.Should().NotHaveValue();
                historyItems[0].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[0].Movie.Genres.Should().BeNull();
                historyItems[0].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[0].Show.Should().BeNull();
                historyItems[0].Season.Should().BeNull();
                historyItems[0].Episode.Should().BeNull();

                historyItems[1].Should().NotBeNull();
                historyItems[1].Id.Should().Be(0);
                historyItems[1].WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                historyItems[1].Action.Should().Be(TraktHistoryActionType.Scrobble);
                historyItems[1].Type.Should().Be(TraktSyncItemType.Movie);
                historyItems[1].Movie.Should().NotBeNull();
                historyItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                historyItems[1].Movie.Year.Should().Be(2015);
                historyItems[1].Movie.Ids.Should().NotBeNull();
                historyItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                historyItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                historyItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                historyItems[1].Movie.Ids.Tmdb.Should().Be(140607U);
                historyItems[1].Movie.Tagline.Should().BeNullOrEmpty();
                historyItems[1].Movie.Overview.Should().BeNullOrEmpty();
                historyItems[1].Movie.Released.Should().NotHaveValue();
                historyItems[1].Movie.Runtime.Should().NotHaveValue();
                historyItems[1].Movie.UpdatedAt.Should().NotHaveValue();
                historyItems[1].Movie.Trailer.Should().BeNullOrEmpty();
                historyItems[1].Movie.Homepage.Should().BeNullOrEmpty();
                historyItems[1].Movie.Rating.Should().NotHaveValue();
                historyItems[1].Movie.Votes.Should().NotHaveValue();
                historyItems[1].Movie.LanguageCode.Should().BeNullOrEmpty();
                historyItems[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
                historyItems[1].Movie.Genres.Should().BeNull();
                historyItems[1].Movie.Certification.Should().BeNullOrEmpty();
                historyItems[1].Show.Should().BeNull();
                historyItems[1].Season.Should().BeNull();
                historyItems[1].Episode.Should().BeNull();
            }
        }
    }
}
