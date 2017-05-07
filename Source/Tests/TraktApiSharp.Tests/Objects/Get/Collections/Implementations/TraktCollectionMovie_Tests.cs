namespace TraktApiSharp.Tests.Objects.Get.Collections.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Collections.Implementations;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionMovie_Tests
    {
        [Fact]
        public void Test_TraktCollectionMovie_Implements_ITraktCollectionMovie_Interface()
        {
            typeof(TraktCollectionMovie).GetInterfaces().Should().Contain(typeof(ITraktCollectionMovie));
        }

        [Fact]
        public void Test_TraktCollectionMovie_Default_Constructor()
        {
            var collectionMovie = new TraktCollectionMovie();

            collectionMovie.CollectedAt.Should().NotHaveValue();
            collectionMovie.Metadata.Should().BeNull();

            collectionMovie.Movie.Should().BeNull();
            collectionMovie.Title.Should().BeNullOrEmpty();
            collectionMovie.Year.Should().NotHaveValue();
            collectionMovie.Ids.Should().BeNull();
            collectionMovie.Tagline.Should().BeNullOrEmpty();
            collectionMovie.Overview.Should().BeNullOrEmpty();
            collectionMovie.Released.Should().NotHaveValue();
            collectionMovie.Runtime.Should().NotHaveValue();
            collectionMovie.UpdatedAt.Should().NotHaveValue();
            collectionMovie.Trailer.Should().BeNullOrEmpty();
            collectionMovie.Homepage.Should().BeNullOrEmpty();
            collectionMovie.Rating.Should().NotHaveValue();
            collectionMovie.Votes.Should().NotHaveValue();
            collectionMovie.LanguageCode.Should().BeNullOrEmpty();
            collectionMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionMovie.Genres.Should().BeNull();
            collectionMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktCollectionMovie_From_Minimal_Json()
        {
            var jsonReader = new ITraktCollectionMovieObjectJsonReader();
            var collectionMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktCollectionMovie;

            collectionMovie.Should().NotBeNull();
            collectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            collectionMovie.Metadata.Should().NotBeNull();
            collectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            collectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            collectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            collectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            collectionMovie.Metadata.ThreeDimensional.Should().BeFalse();

            collectionMovie.Movie.Should().NotBeNull();
            collectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            collectionMovie.Movie.Year.Should().Be(2015);
            collectionMovie.Movie.Ids.Should().NotBeNull();
            collectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            collectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            collectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            collectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            collectionMovie.Movie.Tagline.Should().BeNullOrEmpty();
            collectionMovie.Movie.Overview.Should().BeNullOrEmpty();
            collectionMovie.Movie.Released.Should().NotHaveValue();
            collectionMovie.Movie.Runtime.Should().NotHaveValue();
            collectionMovie.Movie.UpdatedAt.Should().NotHaveValue();
            collectionMovie.Movie.Trailer.Should().BeNullOrEmpty();
            collectionMovie.Movie.Homepage.Should().BeNullOrEmpty();
            collectionMovie.Movie.Rating.Should().NotHaveValue();
            collectionMovie.Movie.Votes.Should().NotHaveValue();
            collectionMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            collectionMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionMovie.Movie.Genres.Should().BeNull();
            collectionMovie.Movie.Certification.Should().BeNullOrEmpty();

            collectionMovie.Title.Should().Be("Star Wars: The Force Awakens");
            collectionMovie.Year.Should().Be(2015);
            collectionMovie.Ids.Should().NotBeNull();
            collectionMovie.Ids.Trakt.Should().Be(94024U);
            collectionMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            collectionMovie.Ids.Imdb.Should().Be("tt2488496");
            collectionMovie.Ids.Tmdb.Should().Be(140607U);
            collectionMovie.Tagline.Should().BeNullOrEmpty();
            collectionMovie.Overview.Should().BeNullOrEmpty();
            collectionMovie.Released.Should().NotHaveValue();
            collectionMovie.Runtime.Should().NotHaveValue();
            collectionMovie.UpdatedAt.Should().NotHaveValue();
            collectionMovie.Trailer.Should().BeNullOrEmpty();
            collectionMovie.Homepage.Should().BeNullOrEmpty();
            collectionMovie.Rating.Should().NotHaveValue();
            collectionMovie.Votes.Should().NotHaveValue();
            collectionMovie.LanguageCode.Should().BeNullOrEmpty();
            collectionMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionMovie.Genres.Should().BeNull();
            collectionMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktCollectionMovie_From_Full_Json()
        {
            var jsonReader = new ITraktCollectionMovieObjectJsonReader();
            var collectionMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktCollectionMovie;

            collectionMovie.Should().NotBeNull();
            collectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            collectionMovie.Metadata.Should().NotBeNull();
            collectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            collectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            collectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            collectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            collectionMovie.Metadata.ThreeDimensional.Should().BeFalse();

            collectionMovie.Movie.Should().NotBeNull();
            collectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            collectionMovie.Movie.Year.Should().Be(2015);
            collectionMovie.Movie.Ids.Should().NotBeNull();
            collectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            collectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            collectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            collectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            collectionMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            collectionMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            collectionMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            collectionMovie.Movie.Runtime.Should().Be(136);
            collectionMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            collectionMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            collectionMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            collectionMovie.Movie.Rating.Should().Be(8.31988f);
            collectionMovie.Movie.Votes.Should().Be(9338);
            collectionMovie.Movie.LanguageCode.Should().Be("en");
            collectionMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            collectionMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            collectionMovie.Movie.Certification.Should().Be("PG-13");

            collectionMovie.Title.Should().Be("Star Wars: The Force Awakens");
            collectionMovie.Year.Should().Be(2015);
            collectionMovie.Ids.Should().NotBeNull();
            collectionMovie.Ids.Trakt.Should().Be(94024U);
            collectionMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            collectionMovie.Ids.Imdb.Should().Be("tt2488496");
            collectionMovie.Ids.Tmdb.Should().Be(140607U);
            collectionMovie.Tagline.Should().Be("Every generation has a story.");
            collectionMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            collectionMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            collectionMovie.Runtime.Should().Be(136);
            collectionMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            collectionMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            collectionMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            collectionMovie.Rating.Should().Be(8.31988f);
            collectionMovie.Votes.Should().Be(9338);
            collectionMovie.LanguageCode.Should().Be("en");
            collectionMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            collectionMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            collectionMovie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                },
                ""metadata"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";

        private const string FULL_JSON =
            @"{
                ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  },
                  ""tagline"": ""Every generation has a story."",
                  ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                  ""released"": ""2015-12-18"",
                  ""runtime"": 136,
                  ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                  ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                  ""rating"": 8.31988,
                  ""votes"": 9338,
                  ""updated_at"": ""2016-03-31T09:01:59Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""de"",
                    ""en"",
                    ""it""
                  ],
                  ""genres"": [
                    ""action"",
                    ""adventure"",
                    ""fantasy"",
                    ""science-fiction""
                  ],
                  ""certification"": ""PG-13""
                },
                ""metadata"": {
                  ""media_type"": ""bluray"",
                  ""resolution"": ""hd_1080p"",
                  ""audio"": ""dts"",
                  ""audio_channels"": ""6.1"",
                  ""3d"": false
                }
              }";
    }
}
