namespace TraktApiSharp.Tests.Objects.Get.Collections.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.Implementations;
    using TraktApiSharp.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionShow_Tests
    {
        [Fact]
        public void Test_TraktCollectionShow_Default_Constructor()
        {
            var collectionShow = new TraktCollectionShow();

            collectionShow.LastCollectedAt.Should().NotHaveValue();
            collectionShow.Show.Should().BeNull();
            collectionShow.CollectionSeasons.Should().BeNull();

            collectionShow.Title.Should().BeNullOrEmpty();
            collectionShow.Year.Should().NotHaveValue();
            collectionShow.Airs.Should().BeNull();
            collectionShow.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionShow.Ids.Should().BeNull();
            collectionShow.Genres.Should().BeNull();
            collectionShow.Seasons.Should().BeNull();
            collectionShow.Overview.Should().BeNullOrEmpty();
            collectionShow.FirstAired.Should().NotHaveValue();
            collectionShow.Runtime.Should().NotHaveValue();
            collectionShow.Certification.Should().BeNullOrEmpty();
            collectionShow.Network.Should().BeNullOrEmpty();
            collectionShow.CountryCode.Should().BeNullOrEmpty();
            collectionShow.UpdatedAt.Should().NotHaveValue();
            collectionShow.Trailer.Should().BeNullOrEmpty();
            collectionShow.Homepage.Should().BeNullOrEmpty();
            collectionShow.Status.Should().BeNull();
            collectionShow.Rating.Should().NotHaveValue();
            collectionShow.Votes.Should().NotHaveValue();
            collectionShow.LanguageCode.Should().BeNullOrEmpty();
            collectionShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktCollectionShow_From_Minimal_Json()
        {
            var jsonReader = new CollectionShowObjectJsonReader();
            var collectionShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktCollectionShow;

            collectionShow.Should().NotBeNull();
            collectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            collectionShow.Show.Should().NotBeNull();
            collectionShow.Show.Title.Should().Be("Game of Thrones");
            collectionShow.Show.Year.Should().Be(2011);
            collectionShow.Show.Airs.Should().BeNull();
            collectionShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionShow.Show.Ids.Should().NotBeNull();
            collectionShow.Show.Ids.Trakt.Should().Be(1390U);
            collectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            collectionShow.Show.Ids.Tvdb.Should().Be(121361U);
            collectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
            collectionShow.Show.Ids.Tmdb.Should().Be(1399U);
            collectionShow.Show.Ids.TvRage.Should().Be(24493U);
            collectionShow.Show.Genres.Should().BeNull();
            collectionShow.Show.Seasons.Should().BeNull();
            collectionShow.Show.Overview.Should().BeNullOrEmpty();
            collectionShow.Show.FirstAired.Should().NotHaveValue();
            collectionShow.Show.Runtime.Should().NotHaveValue();
            collectionShow.Show.Certification.Should().BeNullOrEmpty();
            collectionShow.Show.Network.Should().BeNullOrEmpty();
            collectionShow.Show.CountryCode.Should().BeNullOrEmpty();
            collectionShow.Show.UpdatedAt.Should().NotHaveValue();
            collectionShow.Show.Trailer.Should().BeNullOrEmpty();
            collectionShow.Show.Homepage.Should().BeNullOrEmpty();
            collectionShow.Show.Status.Should().BeNull();
            collectionShow.Show.Rating.Should().NotHaveValue();
            collectionShow.Show.Votes.Should().NotHaveValue();
            collectionShow.Show.LanguageCode.Should().BeNullOrEmpty();
            collectionShow.Show.AiredEpisodes.Should().NotHaveValue();

            collectionShow.Title.Should().Be("Game of Thrones");
            collectionShow.Year.Should().Be(2011);
            collectionShow.Airs.Should().BeNull();
            collectionShow.AvailableTranslationLanguageCodes.Should().BeNull();
            collectionShow.Ids.Should().NotBeNull();
            collectionShow.Ids.Trakt.Should().Be(1390U);
            collectionShow.Ids.Slug.Should().Be("game-of-thrones");
            collectionShow.Ids.Tvdb.Should().Be(121361U);
            collectionShow.Ids.Imdb.Should().Be("tt0944947");
            collectionShow.Ids.Tmdb.Should().Be(1399U);
            collectionShow.Ids.TvRage.Should().Be(24493U);
            collectionShow.Genres.Should().BeNull();
            collectionShow.Seasons.Should().BeNull();
            collectionShow.Overview.Should().BeNullOrEmpty();
            collectionShow.FirstAired.Should().NotHaveValue();
            collectionShow.Runtime.Should().NotHaveValue();
            collectionShow.Certification.Should().BeNullOrEmpty();
            collectionShow.Network.Should().BeNullOrEmpty();
            collectionShow.CountryCode.Should().BeNullOrEmpty();
            collectionShow.UpdatedAt.Should().NotHaveValue();
            collectionShow.Trailer.Should().BeNullOrEmpty();
            collectionShow.Homepage.Should().BeNullOrEmpty();
            collectionShow.Status.Should().BeNull();
            collectionShow.Rating.Should().NotHaveValue();
            collectionShow.Votes.Should().NotHaveValue();
            collectionShow.LanguageCode.Should().BeNullOrEmpty();
            collectionShow.AiredEpisodes.Should().NotHaveValue();

            collectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = collectionShow.CollectionSeasons.ToArray();

            // Season 1
            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes.ToArray();

            episodesSeason1[0].Should().NotBeNull();
            episodesSeason1[0].Number.Should().Be(1);
            episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[0].Metadata.Should().NotBeNull();
            episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[0].Metadata.ThreeDimensional.Should().BeTrue();

            episodesSeason1[1].Should().NotBeNull();
            episodesSeason1[1].Number.Should().Be(2);
            episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[1].Metadata.Should().NotBeNull();
            episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[1].Metadata.ThreeDimensional.Should().BeTrue();

            // Season 2
            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull();
            seasons[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes.ToArray();

            episodesSeason2[0].Should().NotBeNull();
            episodesSeason2[0].Number.Should().Be(1);
            episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[0].Metadata.Should().NotBeNull();
            episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[0].Metadata.ThreeDimensional.Should().BeTrue();

            episodesSeason2[1].Should().NotBeNull();
            episodesSeason2[1].Number.Should().Be(2);
            episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[1].Metadata.Should().NotBeNull();
            episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[1].Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCollectionShow_From_Full_Json()
        {
            var jsonReader = new CollectionShowObjectJsonReader();
            var collectionShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktCollectionShow;

            collectionShow.Should().NotBeNull();
            collectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            collectionShow.Show.Should().NotBeNull();
            collectionShow.Show.Title.Should().Be("Game of Thrones");
            collectionShow.Show.Year.Should().Be(2011);
            collectionShow.Show.Airs.Should().NotBeNull();
            collectionShow.Show.Airs.Day.Should().Be("Sunday");
            collectionShow.Show.Airs.Time.Should().Be("21:00");
            collectionShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            collectionShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            collectionShow.Show.Ids.Should().NotBeNull();
            collectionShow.Show.Ids.Trakt.Should().Be(1390U);
            collectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            collectionShow.Show.Ids.Tvdb.Should().Be(121361U);
            collectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
            collectionShow.Show.Ids.Tmdb.Should().Be(1399U);
            collectionShow.Show.Ids.TvRage.Should().Be(24493U);
            collectionShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            collectionShow.Show.Seasons.Should().BeNull();
            collectionShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            collectionShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            collectionShow.Show.Runtime.Should().Be(60);
            collectionShow.Show.Certification.Should().Be("TV-MA");
            collectionShow.Show.Network.Should().Be("HBO");
            collectionShow.Show.CountryCode.Should().Be("us");
            collectionShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            collectionShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            collectionShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            collectionShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            collectionShow.Show.Rating.Should().Be(9.38327f);
            collectionShow.Show.Votes.Should().Be(44773);
            collectionShow.Show.LanguageCode.Should().Be("en");
            collectionShow.Show.AiredEpisodes.Should().Be(50);

            collectionShow.Title.Should().Be("Game of Thrones");
            collectionShow.Year.Should().Be(2011);
            collectionShow.Airs.Should().NotBeNull();
            collectionShow.Airs.Day.Should().Be("Sunday");
            collectionShow.Airs.Time.Should().Be("21:00");
            collectionShow.Airs.TimeZoneId.Should().Be("America/New_York");
            collectionShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            collectionShow.Ids.Should().NotBeNull();
            collectionShow.Ids.Trakt.Should().Be(1390U);
            collectionShow.Ids.Slug.Should().Be("game-of-thrones");
            collectionShow.Ids.Tvdb.Should().Be(121361U);
            collectionShow.Ids.Imdb.Should().Be("tt0944947");
            collectionShow.Ids.Tmdb.Should().Be(1399U);
            collectionShow.Ids.TvRage.Should().Be(24493U);
            collectionShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            collectionShow.Seasons.Should().BeNull();
            collectionShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            collectionShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            collectionShow.Runtime.Should().Be(60);
            collectionShow.Certification.Should().Be("TV-MA");
            collectionShow.Network.Should().Be("HBO");
            collectionShow.CountryCode.Should().Be("us");
            collectionShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            collectionShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            collectionShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            collectionShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            collectionShow.Rating.Should().Be(9.38327f);
            collectionShow.Votes.Should().Be(44773);
            collectionShow.LanguageCode.Should().Be("en");
            collectionShow.AiredEpisodes.Should().Be(50);

            collectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = collectionShow.CollectionSeasons.ToArray();

            // Season 1
            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes.ToArray();

            episodesSeason1[0].Should().NotBeNull();
            episodesSeason1[0].Number.Should().Be(1);
            episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[0].Metadata.Should().NotBeNull();
            episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[0].Metadata.ThreeDimensional.Should().BeTrue();

            episodesSeason1[1].Should().NotBeNull();
            episodesSeason1[1].Number.Should().Be(2);
            episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[1].Metadata.Should().NotBeNull();
            episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[1].Metadata.ThreeDimensional.Should().BeTrue();

            // Season 2
            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull();
            seasons[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes.ToArray();

            episodesSeason2[0].Should().NotBeNull();
            episodesSeason2[0].Number.Should().Be(1);
            episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[0].Metadata.Should().NotBeNull();
            episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[0].Metadata.ThreeDimensional.Should().BeTrue();

            episodesSeason2[1].Should().NotBeNull();
            episodesSeason2[1].Number.Should().Be(2);
            episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodesSeason1[1].Metadata.Should().NotBeNull();
            episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodesSeason1[1].Metadata.ThreeDimensional.Should().BeTrue();
        }

        private const string MINIMAL_JSON =
            @"{
                ""last_collected_at"": ""2014-07-14T01:00:00.000Z"",
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
                },
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      },
                      {
                        ""number"": 2,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      },
                      {
                        ""number"": 2,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      }
                    ]
                  }
                ]
              }";

        private const string FULL_JSON =
            @"{
                ""last_collected_at"": ""2014-07-14T01:00:00.000Z"",
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
                  },
                  ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                  ""first_aired"": ""2011-04-17T07:00:00Z"",
                  ""airs"": {
                    ""day"": ""Sunday"",
                    ""time"": ""21:00"",
                    ""timezone"": ""America/New_York""
                  },
                  ""runtime"": 60,
                  ""certification"": ""TV-MA"",
                  ""network"": ""HBO"",
                  ""country"": ""us"",
                  ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                  ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                  ""status"": ""returning series"",
                  ""rating"": 9.38327,
                  ""votes"": 44773,
                  ""updated_at"": ""2016-04-06T10:39:11Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""fr"",
                    ""it"",
                    ""de""
                  ],
                  ""genres"": [
                    ""drama"",
                    ""fantasy"",
                    ""science-fiction"",
                    ""action"",
                    ""adventure""
                  ],
                  ""aired_episodes"": 50
                },
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      },
                      {
                        ""number"": 2,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      },
                      {
                        ""number"": 2,
                        ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                        ""metadata"": {
                          ""media_type"": ""digital"",
                          ""resolution"": ""hd_720p"",
                          ""audio"": ""aac"",
                          ""audio_channels"": ""5.1"",
                          ""3d"": true
                        }
                      }
                    ]
                  }
                ]
              }";
    }
}
