using TraktNet.Objects.Get.Episodes;

namespace TraktNet.Objects.Post.Tests.Builder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        private readonly ITraktMetadata METADATA = new TraktMetadata
        {
            Audio = TraktMediaAudio.DolbyAtmos,
            AudioChannels = TraktMediaAudioChannel.Channels_7_1,
            MediaResolution = TraktMediaResolution.UHD_4k,
            MediaType = TraktMediaType.Digital,
            HDR = TraktMediaHDR.DolbyVision,
            ThreeDimensional = true
        };

        private readonly ITraktMovie MOVIE_1 = new TraktMovie
        {
            Title = "movie title 1",
            Year = 2022,
            Ids = new TraktMovieIds
            {
                Trakt = 1,
                Slug = "movie-title-1",
                Imdb = "ttmovietitle1",
                Tmdb = 1
            }
        };

        private readonly ITraktMovie MOVIE_2 = new TraktMovie
        {
            Title = "movie title 2",
            Year = 2022,
            Ids = new TraktMovieIds
            {
                Trakt = 2,
                Slug = "movie-title-2",
                Imdb = "ttmovietitle2",
                Tmdb = 2
            }
        };

        private readonly List<ITraktMovie> MOVIES;

        private readonly ITraktMovieIds MOVIE_IDS_1 = new TraktMovieIds
        {
            Trakt = 1,
            Slug = "movie-title-1",
            Imdb = "ttmovietitle1",
            Tmdb = 1
        };

        private readonly ITraktMovieIds MOVIE_IDS_2 = new TraktMovieIds
        {
            Trakt = 2,
            Slug = "movie-title-2",
            Imdb = "ttmovietitle2",
            Tmdb = 2
        };

        private readonly List<ITraktMovieIds> MOVIE_IDS;

        private readonly ITraktShow SHOW_1 = new TraktShow
        {
            Title = "show title 1",
            Year = 2022,
            Ids = new TraktShowIds
            {
                Trakt = 1,
                Slug = "show-title-1",
                Imdb = "ttshowtitle1",
                Tmdb = 1,
                Tvdb = 1,
                TvRage = 1
            }
        };

        private readonly ITraktShow SHOW_2 = new TraktShow
        {
            Title = "show title 2",
            Year = 2022,
            Ids = new TraktShowIds
            {
                Trakt = 2,
                Slug = "show-title-2",
                Imdb = "ttshowtitle2",
                Tmdb = 2,
                Tvdb = 2,
                TvRage = 2
            }
        };

        private readonly List<ITraktShow> SHOWS;

        private readonly ITraktShowIds SHOW_IDS_1 = new TraktShowIds
        {
            Trakt = 1,
            Slug = "show-title-1",
            Imdb = "ttshowtitle1",
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        private readonly ITraktShowIds SHOW_IDS_2 = new TraktShowIds
        {
            Trakt = 2,
            Slug = "show-title-2",
            Imdb = "ttshowtitle2",
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        private readonly List<ITraktShowIds> SHOW_IDS;

        private readonly PostCollectionSeasons SHOW_SEASONS_1;

        private readonly PostCollectionSeasons SHOW_SEASONS_2;

        private readonly List<PostCollectionSeasons> SHOW_SEASONS;

        private readonly ITraktSeason SEASON_1 = new TraktSeason
        {
            Ids = new TraktSeasonIds
            {
                Trakt = 1,
                Tmdb = 1,
                Tvdb = 1,
                TvRage = 1
            }
        };

        private readonly ITraktSeason SEASON_2 = new TraktSeason
        {
            Ids = new TraktSeasonIds
            {
                Trakt = 2,
                Tmdb = 2,
                Tvdb = 2,
                TvRage = 2
            }
        };

        private readonly List<ITraktSeason> SEASONS;

        private readonly ITraktSeasonIds SEASON_IDS_1 = new TraktSeasonIds
        {
            Trakt = 1,
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        private readonly ITraktSeasonIds SEASON_IDS_2 = new TraktSeasonIds
        {
            Trakt = 2,
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        private readonly List<ITraktSeasonIds> SEASON_IDS;

        private readonly ITraktEpisode EPISODE_1 = new TraktEpisode
        {
            Ids = new TraktEpisodeIds
            {
                Trakt = 1,
                Imdb = "ttepisode1title",
                Tmdb = 1,
                Tvdb = 1,
                TvRage = 1
            }
        };

        private readonly ITraktEpisode EPISODE_2 = new TraktEpisode
        {
            Ids = new TraktEpisodeIds
            {
                Trakt = 2,
                Imdb = "ttepisode2title",
                Tmdb = 2,
                Tvdb = 2,
                TvRage = 2
            }
        };

        private readonly List<ITraktEpisode> EPISODES;

        private readonly ITraktEpisodeIds EPISODE_IDS_1 = new TraktEpisodeIds
        {
            Trakt = 1,
            Imdb = "ttepisode1title",
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        private readonly ITraktEpisodeIds EPISODE_IDS_2 = new TraktEpisodeIds
        {
            Trakt = 2,
            Imdb = "ttepisode2title",
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        private readonly List<ITraktEpisodeIds> EPISODE_IDS;

        public TraktPost_SyncCollectionPostBuilder_Tests()
        {
            MOVIES = new List<ITraktMovie>
            {
                MOVIE_1,
                MOVIE_2
            };

            MOVIE_IDS = new List<ITraktMovieIds>
            {
                MOVIE_IDS_1,
                MOVIE_IDS_2
            };

            SHOWS = new List<ITraktShow>
            {
                SHOW_1,
                SHOW_2
            };

            SHOW_IDS = new List<ITraktShowIds>
            {
                SHOW_IDS_1,
                SHOW_IDS_2
            };

            SEASONS = new List<ITraktSeason>
            {
                SEASON_1,
                SEASON_2
            };

            SEASON_IDS = new List<ITraktSeasonIds>
            {
                SEASON_IDS_1,
                SEASON_IDS_2
            };

            EPISODES = new List<ITraktEpisode>
            {
                EPISODE_1,
                EPISODE_2
            };

            EPISODE_IDS = new List<ITraktEpisodeIds>
            {
                EPISODE_IDS_1,
                EPISODE_IDS_2
            };

            SHOW_SEASONS_1 = new PostCollectionSeasons
            {
                { 1 },
                { 2, METADATA },
                { 3, COLLECTED_AT },
                { 4, METADATA, COLLECTED_AT },
                { 5, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2, METADATA },
                        { 3, COLLECTED_AT },
                        { 4, METADATA, COLLECTED_AT }
                    }
                },
                { 6, METADATA, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2, METADATA },
                        { 3, COLLECTED_AT },
                        { 4, METADATA, COLLECTED_AT }
                    }
                },
                { 7, COLLECTED_AT, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2, METADATA },
                        { 3, COLLECTED_AT },
                        { 4, METADATA, COLLECTED_AT }
                    }
                },
                { 8, METADATA, COLLECTED_AT, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2, METADATA },
                        { 3, COLLECTED_AT },
                        { 4, METADATA, COLLECTED_AT }
                    }
                }
            };

            SHOW_SEASONS_2 = new PostCollectionSeasons
            {
                { 1 },
                { 2 },
                { 3 },
                { 4 },
                { 5, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2 }
                    }
                },
                { 6, new PostCollectionEpisodes
                    {
                        { 1 }
                    }
                },
                { 7, new PostCollectionEpisodes
                    {
                        { 1 },
                        { 2 }
                    }
                },
                { 8, new PostCollectionEpisodes
                    {
                        { 1 }
                    }
                }
            };

            SHOW_SEASONS = new List<PostCollectionSeasons>
            {
                SHOW_SEASONS_1,
                SHOW_SEASONS_2
            };
        }
    }
}
