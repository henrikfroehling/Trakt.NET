namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendedMovieObjectJsonWriter_Tests
    {
        private readonly DateTime RELEASED_AT = DateTime.UtcNow.Date;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Title_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Title = "Star Wars: The Force Awakens"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""title"":""Star Wars: The Force Awakens""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Year_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Year = 2015
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""year"":2015}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Ids = new TraktMovieIds
                {
                    Trakt = 94024,
                    Slug = "star-wars-the-force-awakens-2015",
                    Imdb = "tt2488496",
                    Tmdb = 140607
                }
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Tagline_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Tagline = "Every generation has a story."
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""tagline"":""Every generation has a story.""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Overview_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Overview = "Thirty years after defeating the Galactic Empire,..."
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""overview"":""Thirty years after defeating the Galactic Empire,...""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Released_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Released = RELEASED_AT
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be($"{{\"released\":\"{RELEASED_AT.ToTraktDateString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Runtime_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Runtime = 136
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""runtime"":136}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_UpdatedAt_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Trailer_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Trailer = "http://youtube.com/watch?v=uwa7N0ShN2U"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""trailer"":""http://youtube.com/watch?v=uwa7N0ShN2U""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Homepage_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Homepage = "http://www.starwars.com/films/star-wars-episode-vii"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""homepage"":""http://www.starwars.com/films/star-wars-episode-vii""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Rating_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Rating = 8.31988f
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""rating"":8.31988}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Votes_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Votes = 9338
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""votes"":9338}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_LanguageCode_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                LanguageCode = "en"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""language"":""en""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_AvailableTranslationLanguageCodes_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en", "de", "es", "it"
                }
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""available_translations"":[""en"",""de"",""es"",""it""]}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Genres_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Genres = new List<string>
                {
                    "action", "adventure", "fantasy", "science-fiction"
                }
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""genres"":[""action"",""adventure"",""fantasy"",""science-fiction""]}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Certification_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Certification = "PG-13"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""certification"":""PG-13""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_CountryCode_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_Status_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Status = TraktMovieStatus.Released
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""status"":""released""}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Only_FavoritedBy_Property()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                FavoritedBy = new List<ITraktFavoritedBy>
                {
                    new TraktFavoritedBy
                    {
                        User = new TraktUser
                        {
                            Username = "sean",
                            IsPrivate = false,
                            Name = "Sean Rudford",
                            IsVIP = true,
                            IsVIP_EP = true,
                            Ids = new TraktUserIds
                            {
                                Slug = "sean",
                                UUID = "3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070"
                            },
                            Location = "SF",
                            About = "I have all your cassette tapes.",
                            Age = 35,
                            Gender = "male"
                        },
                        Notes = "Favorited because ..."
                    }
                }
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""favorited_by"":[{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}," +
                             @"""notes"":""Favorited because ...""}]}");
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonWriter_WriteObject_Complete()
        {
            ITraktRecommendedMovie traktRecommendedMovie = new TraktRecommendedMovie
            {
                Title = "Star Wars: The Force Awakens",
                Year = 2015,
                Ids = new TraktMovieIds
                {
                    Trakt = 94024,
                    Slug = "star-wars-the-force-awakens-2015",
                    Imdb = "tt2488496",
                    Tmdb = 140607
                },
                Tagline = "Every generation has a story.",
                Overview = "Thirty years after defeating the Galactic Empire,...",
                Released = RELEASED_AT,
                Runtime = 136,
                UpdatedAt = UPDATED_AT,
                Trailer = "http://youtube.com/watch?v=uwa7N0ShN2U",
                Homepage = "http://www.starwars.com/films/star-wars-episode-vii",
                Rating = 8.31988f,
                Votes = 9338,
                LanguageCode = "en",
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en", "de", "es", "it"
                },
                Genres = new List<string>
                {
                    "action", "adventure", "fantasy", "science-fiction"
                },
                Certification = "PG-13",
                CountryCode = "us",
                Status = TraktMovieStatus.Released,
                FavoritedBy = new List<ITraktFavoritedBy>
                {
                    new TraktFavoritedBy
                    {
                        User = new TraktUser
                        {
                            Username = "sean",
                            IsPrivate = false,
                            Name = "Sean Rudford",
                            IsVIP = true,
                            IsVIP_EP = true,
                            Ids = new TraktUserIds
                            {
                                Slug = "sean",
                                UUID = "3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070"
                            },
                            Location = "SF",
                            About = "I have all your cassette tapes.",
                            Age = 35,
                            Gender = "male"
                        },
                        Notes = "Favorited because ..."
                    }
                }
            };

            var traktJsonWriter = new RecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedMovie);
            json.Should().Be(@"{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}," +
                             @"""tagline"":""Every generation has a story.""," +
                             @"""overview"":""Thirty years after defeating the Galactic Empire,...""," +
                             $"\"released\":\"{RELEASED_AT.ToTraktDateString()}\"," +
                             @"""runtime"":136,""trailer"":""http://youtube.com/watch?v=uwa7N0ShN2U""," +
                             @"""homepage"":""http://www.starwars.com/films/star-wars-episode-vii""," +
                             @"""rating"":8.31988,""votes"":9338," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""language"":""en""," +
                             @"""available_translations"":[""en"",""de"",""es"",""it""]," +
                             @"""genres"":[""action"",""adventure"",""fantasy"",""science-fiction""]," +
                             @"""certification"":""PG-13"",""country"":""us"",""status"":""released""," +
                             @"""favorited_by"":[{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}," +
                             @"""notes"":""Favorited because ...""}]}");
        }
    }
}
