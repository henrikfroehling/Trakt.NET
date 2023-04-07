namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendedShowObjectJsonWriter_Tests
    {
        private readonly DateTime FIRST_AIRED_AT = DateTime.UtcNow;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Title_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Title = "Game of Thrones"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""title"":""Game of Thrones""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Year_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Year = 2011
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""year"":2011}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 1390,
                    Slug = "game-of-thrones",
                    Tvdb = 121361,
                    Imdb = "tt0944947",
                    Tmdb = 1399,
                    TvRage = 24493
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                             @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Airs_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Airs = new TraktShowAirs
                {
                    Day = "Sunday",
                    Time = "21:00",
                    TimeZoneId = "America/New_York"
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""airs"":{""day"":""Sunday"",""time"":""21:00"",""timezone"":""America/New_York""}}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Overview_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Overview = "Seven noble families fight for control of the mythical land of Westeros."
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""overview"":""Seven noble families fight for control of the mythical land of Westeros.""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_FirstAired_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                FirstAired = FIRST_AIRED_AT
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be($"{{\"first_aired\":\"{FIRST_AIRED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Runtime_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Runtime = 60
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""runtime"":60}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_UpdatedAt_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Trailer_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Trailer = "http://youtube.com/watch?v=F9Bo89m2f6g"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""trailer"":""http://youtube.com/watch?v=F9Bo89m2f6g""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Homepage_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Homepage = "http://www.hbo.com/game-of-thrones"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""homepage"":""http://www.hbo.com/game-of-thrones""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Rating_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Rating = 9.38327f
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""rating"":9.38327}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Votes_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Votes = 44773
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""votes"":44773}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_LanguageCode_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                LanguageCode = "en"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""language"":""en""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_AvailableTranslationLanguageCodes_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en", "fr", "it", "de"
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""available_translations"":[""en"",""fr"",""it"",""de""]}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Genres_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Genres = new List<string>
                {
                    "drama", "fantasy", "science-fiction", "action", "adventure"
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""genres"":[""drama"",""fantasy"",""science-fiction"",""action"",""adventure""]}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Certification_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Certification = "TV-MA"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""certification"":""TV-MA""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Network_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Network = "HBO"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""network"":""HBO""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_CountryCode_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_Status_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                Status = TraktShowStatus.Ended
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""status"":""ended""}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_AiredEpisodes_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                AiredEpisodes = 50
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""aired_episodes"":50}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Only_RecommendedBy_Property()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
            {
                RecommendedBy = new List<ITraktRecommendedBy>
                {
                    new TraktRecommendedBy
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
                        Notes = "Recommended because ..."
                    }
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""recommended_by"":[{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}," +
                             @"""notes"":""Recommended because ...""}]}");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonWriter_WriteObject_Complete()
        {
            ITraktRecommendedShow traktRecommendedShow = new TraktRecommendedShow
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
                },
                Airs = new TraktShowAirs
                {
                    Day = "Sunday",
                    Time = "21:00",
                    TimeZoneId = "America/New_York"
                },
                Overview = "Seven noble families fight for control of the mythical land of Westeros.",
                FirstAired = FIRST_AIRED_AT,
                Runtime = 60,
                UpdatedAt = UPDATED_AT,
                Trailer = "http://youtube.com/watch?v=F9Bo89m2f6g",
                Homepage = "http://www.hbo.com/game-of-thrones",
                Rating = 9.38327f,
                Votes = 44773,
                LanguageCode = "en",
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en", "fr", "it", "de"
                },
                Genres = new List<string>
                {
                    "drama", "fantasy", "science-fiction", "action", "adventure"
                },
                Certification = "TV-MA",
                Network = "HBO",
                CountryCode = "us",
                Status = TraktShowStatus.Ended,
                AiredEpisodes = 50,
                RecommendedBy = new List<ITraktRecommendedBy>
                {
                    new TraktRecommendedBy
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
                        Notes = "Recommended because ..."
                    }
                }
            };

            var traktJsonWriter = new RecommendedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedShow);
            json.Should().Be(@"{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                             @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}," +
                             @"""overview"":""Seven noble families fight for control of the mythical land of Westeros.""," +
                             $"\"first_aired\":\"{FIRST_AIRED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""airs"":{""day"":""Sunday"",""time"":""21:00"",""timezone"":""America/New_York""}," +
                             @"""runtime"":60,""certification"":""TV-MA"",""network"":""HBO"",""country"":""us""," +
                             @"""trailer"":""http://youtube.com/watch?v=F9Bo89m2f6g"",""homepage"":""http://www.hbo.com/game-of-thrones""," +
                             @"""status"":""ended"",""rating"":9.38327,""votes"":44773," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""language"":""en"",""available_translations"":[""en"",""fr"",""it"",""de""]," +
                             @"""genres"":[""drama"",""fantasy"",""science-fiction"",""action"",""adventure""]," +
                             @"""aired_episodes"":50," +
                             @"""recommended_by"":[{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}," +
                             @"""notes"":""Recommended because ...""}]}");
        }
    }
}
