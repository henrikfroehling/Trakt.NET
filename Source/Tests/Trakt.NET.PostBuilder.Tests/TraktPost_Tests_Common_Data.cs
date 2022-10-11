namespace TraktNet.PostBuilder.Tests
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.PostBuilder;

    internal static class TraktPost_Tests_Common_Data
    {
        internal static readonly DateTime COLLECTED_AT = DateTime.UtcNow;
        internal static readonly DateTime WATCHED_AT = DateTime.UtcNow;
        internal static readonly DateTime RATED_AT = DateTime.UtcNow;
        internal static readonly TraktPostRating RATING = TraktPostRating.Rating_5;
        internal static readonly string NOTES = new('n', 255);
        internal static readonly string NOTES_TOO_LONG = new('n', 256);

        internal static readonly ITraktMetadata METADATA = new TraktMetadata
        {
            Audio = TraktMediaAudio.DolbyAtmos,
            AudioChannels = TraktMediaAudioChannel.Channels_7_1,
            MediaResolution = TraktMediaResolution.UHD_4k,
            MediaType = TraktMediaType.Digital,
            HDR = TraktMediaHDR.DolbyVision,
            ThreeDimensional = true
        };

        internal static readonly ITraktMovie MOVIE_1 = new TraktMovie
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

        internal static readonly ITraktMovie MOVIE_2 = new TraktMovie
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

        internal static readonly List<ITraktMovie> MOVIES;

        internal static readonly ITraktMovieIds MOVIE_IDS_1 = new TraktMovieIds
        {
            Trakt = 1,
            Slug = "movie-title-1",
            Imdb = "ttmovietitle1",
            Tmdb = 1
        };

        internal static readonly ITraktMovieIds MOVIE_IDS_2 = new TraktMovieIds
        {
            Trakt = 2,
            Slug = "movie-title-2",
            Imdb = "ttmovietitle2",
            Tmdb = 2
        };

        internal static readonly List<ITraktMovieIds> MOVIE_IDS;

        internal static readonly ITraktShow SHOW_1 = new TraktShow
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

        internal static readonly ITraktShow SHOW_2 = new TraktShow
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

        internal static readonly List<ITraktShow> SHOWS;

        internal static readonly ITraktShowIds SHOW_IDS_1 = new TraktShowIds
        {
            Trakt = 1,
            Slug = "show-title-1",
            Imdb = "ttshowtitle1",
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        internal static readonly ITraktShowIds SHOW_IDS_2 = new TraktShowIds
        {
            Trakt = 2,
            Slug = "show-title-2",
            Imdb = "ttshowtitle2",
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        internal static readonly List<ITraktShowIds> SHOW_IDS;

        internal static readonly List<int> SEASON_NUMBERS_1;

        internal static readonly List<int> SEASON_NUMBERS_2;

        internal static readonly PostCollectionSeasons COLLECTION_SHOW_SEASONS_1;

        internal static readonly PostCollectionSeasons COLLECTION_SHOW_SEASONS_2;

        internal static readonly PostHistorySeasons HISTORY_SHOW_SEASONS_1;

        internal static readonly PostHistorySeasons HISTORY_SHOW_SEASONS_2;

        internal static readonly PostSeasons SHOW_SEASONS_1;

        internal static readonly PostSeasons SHOW_SEASONS_2;

        internal static readonly PostRatingsSeasons RATINGS_SHOW_SEASONS_1;

        internal static readonly PostRatingsSeasons RATINGS_SHOW_SEASONS_2;

        internal static readonly ITraktSeason SEASON_1 = new TraktSeason
        {
            Ids = new TraktSeasonIds
            {
                Trakt = 1,
                Tmdb = 1,
                Tvdb = 1,
                TvRage = 1
            }
        };

        internal static readonly ITraktSeason SEASON_2 = new TraktSeason
        {
            Ids = new TraktSeasonIds
            {
                Trakt = 2,
                Tmdb = 2,
                Tvdb = 2,
                TvRage = 2
            }
        };

        internal static readonly List<ITraktSeason> SEASONS;

        internal static readonly ITraktSeasonIds SEASON_IDS_1 = new TraktSeasonIds
        {
            Trakt = 1,
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        internal static readonly ITraktSeasonIds SEASON_IDS_2 = new TraktSeasonIds
        {
            Trakt = 2,
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        internal static readonly List<ITraktSeasonIds> SEASON_IDS;

        internal static readonly ITraktEpisode EPISODE_1 = new TraktEpisode
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

        internal static readonly ITraktEpisode EPISODE_2 = new TraktEpisode
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

        internal static readonly List<ITraktEpisode> EPISODES;

        internal static readonly ITraktEpisodeIds EPISODE_IDS_1 = new TraktEpisodeIds
        {
            Trakt = 1,
            Imdb = "ttepisode1title",
            Tmdb = 1,
            Tvdb = 1,
            TvRage = 1
        };

        internal static readonly ITraktEpisodeIds EPISODE_IDS_2 = new TraktEpisodeIds
        {
            Trakt = 2,
            Imdb = "ttepisode2title",
            Tmdb = 2,
            Tvdb = 2,
            TvRage = 2
        };

        internal static readonly List<ITraktEpisodeIds> EPISODE_IDS;

        internal static readonly ITraktUser USER_1 = new TraktUser
        {
            Ids = new TraktUserIds
            {
                Slug = "user-1",
                UUID = "user-1-abcdef"
            }
        };

        internal static readonly ITraktUser USER_2 = new TraktUser
        {
            Ids = new TraktUserIds
            {
                Slug = "user-2",
                UUID = "user-2-abcdef"
            }
        };

        internal static readonly List<ITraktUser> USERS;

        internal static readonly ITraktUserIds USER_IDS_1 = new TraktUserIds
        {
            Slug = "user-1",
            UUID = "user-1-abcdef"
        };

        internal static readonly ITraktUserIds USER_IDS_2 = new TraktUserIds
        {
            Slug = "user-2",
            UUID = "user-2-abcdef"
        };

        internal static readonly List<ITraktUserIds> USER_IDS;

        static TraktPost_Tests_Common_Data()
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

            SEASON_NUMBERS_1 = new List<int>
            {
                1,
                2,
                3
            };

            SEASON_NUMBERS_2 = new List<int>
            {
                1,
                2
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

            USERS = new List<ITraktUser>
            {
                USER_1,
                USER_2
            };

            USER_IDS = new List<ITraktUserIds>
            {
                USER_IDS_1,
                USER_IDS_2
            };

            COLLECTION_SHOW_SEASONS_1 = new PostCollectionSeasons
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

            COLLECTION_SHOW_SEASONS_2 = new PostCollectionSeasons
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

            HISTORY_SHOW_SEASONS_1 = new PostHistorySeasons
            {
                { 1 },
                { 2, WATCHED_AT },
                { 3, new PostHistoryEpisodes
                    {
                        { 1 },
                        { 2, WATCHED_AT }
                    }
                },
                { 4, WATCHED_AT, new PostHistoryEpisodes
                    {
                        { 1 },
                        { 2, WATCHED_AT }
                    }
                }
            };

            HISTORY_SHOW_SEASONS_2 = new PostHistorySeasons
            {
                { 1 },
                { 2 },
                { 3, new PostHistoryEpisodes
                    {
                        { 1 },
                        { 2 }
                    }
                },
                { 4, new PostHistoryEpisodes
                    {
                        { 1 }
                    }
                }
            };

            SHOW_SEASONS_1 = new PostSeasons
            {
                { 1 },
                { 2, new PostEpisodes
                    {
                        { 1 }
                    }
                }
            };

            SHOW_SEASONS_2 = new PostSeasons
            {
                { 1 },
                { 2, new PostEpisodes
                    {
                        { 1 }
                    }
                }
            };

            RATINGS_SHOW_SEASONS_1 = new PostRatingsSeasons
            {
                { 1, RATING },
                { 2, new PostRatingsEpisodes
                    {
                        { 1, RATING },
                        { 2, RATING, RATED_AT }
                    }
                },
                { 3, RATING, RATED_AT },
                { 4, new PostRatingsEpisodes
                    {
                        { 1, RATING },
                        { 2, RATING, RATED_AT }
                    }
                }
            };

            RATINGS_SHOW_SEASONS_2 = new PostRatingsSeasons
            {
                { 1, RATING },
                { 2, new PostRatingsEpisodes
                    {
                        { 1, RATING },
                        { 2, RATING, RATED_AT }
                    }
                }
            };
        }
    }
}
