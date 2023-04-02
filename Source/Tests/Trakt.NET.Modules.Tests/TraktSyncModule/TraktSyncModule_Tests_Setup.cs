namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;
    using TraktNet.Objects.Post.Syncs.History;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Watchlist;

    public partial class TraktSyncModule_Tests
    {
        private ITraktSyncCollectionPost AddCollectionItemsPost { get; }
        private ITraktSyncRatingsPost AddRatingsPost { get; }
        private ITraktSyncRecommendationsPost RecommendationsPost { get; }
        private ITraktSyncHistoryPost AddHistoryPost { get; }
        private ITraktSyncWatchlistPost AddWatchlistPost { get; }
        private ITraktSyncCollectionRemovePost RemoveCollectionItemsPost { get; }
        private ITraktSyncRatingsPost RemoveRatingsPost { get; }
        private ITraktSyncHistoryRemovePost RemoveHistoryPost { get; }
        private ITraktSyncWatchlistPost RemoveWatchlistPost { get; }

        public TraktSyncModule_Tests()
        {
            AddCollectionItemsPost = SetupAddCollectionItemsPost();
            AddRatingsPost = SetupAddRatingsPost();
            RecommendationsPost = SetupAddRecommendationsPost();
            AddHistoryPost = SetupAddHistoryPost();
            AddWatchlistPost = SetupAddWatchlistPost();
            RemoveCollectionItemsPost = SetupRemoveCollectionItemsPost();
            RemoveRatingsPost = SetupRemoveRatingsPost();
            RemoveHistoryPost = SetupRemoveHistoryPost();
            RemoveWatchlistPost = SetupRemoveWatchlistPost();
        }

        private ITraktSyncCollectionPost SetupAddCollectionItemsPost()
        {
            return new TraktSyncCollectionPost
            {
                Movies = new List<ITraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncCollectionPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncCollectionPostShowEpisode>()
                                {
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncRatingsPost SetupAddRatingsPost()
        {
            return new TraktSyncRatingsPost
            {
                Movies = new List<ITraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        RatedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Rating = 5,
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncRatingsPostMovie
                    {
                        Rating = 10,
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Rating = 9,
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Rating = 8,
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncRatingsPostShowEpisode>()
                                {
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Rating = 7,
                                        Number = 1
                                    },
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Rating = 8,
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Rating = 7,
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncRecommendationsPost SetupAddRecommendationsPost()
        {
            return new TraktSyncRecommendationsPost
            {
                Movies = new List<ITraktSyncRecommendationsPostMovie>
                {
                    new TraktSyncRecommendationsPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        },
                        Notes = "One of Chritian Bale's most iconic roles."
                    },
                    new TraktSyncRecommendationsPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncRecommendationsPostShow>
                {
                    new TraktSyncRecommendationsPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396
                        },
                        Notes = "I AM THE DANGER!"
                    },
                    new TraktSyncRecommendationsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402
                        }
                    }
                }
            };
        }

        private ITraktSyncHistoryPost SetupAddHistoryPost()
        {
            return new TraktSyncHistoryPost
            {
                Movies = new List<ITraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncHistoryPostShowEpisode>()
                                {
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncWatchlistPost SetupAddWatchlistPost()
        {
            return new TraktSyncWatchlistPost
            {
                Movies = new List<ITraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncWatchlistPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncWatchlistPostShowEpisode>()
                                {
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncCollectionRemovePost SetupRemoveCollectionItemsPost()
        {
            return new TraktSyncCollectionRemovePost
            {
                Movies = new List<ITraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncCollectionPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncCollectionPostShowEpisode>()
                                {
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncRatingsPost SetupRemoveRatingsPost()
        {
            return new TraktSyncRatingsPost
            {
                Movies = new List<ITraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncRatingsPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncRatingsPostShowEpisode>()
                                {
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncHistoryRemovePost SetupRemoveHistoryPost()
        {
            return new TraktSyncHistoryRemovePost
            {
                Movies = new List<ITraktSyncHistoryRemovePostMovie>()
                {
                    new TraktSyncHistoryRemovePostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryRemovePostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncHistoryRemovePostShow>()
                {
                    new TraktSyncHistoryRemovePostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryRemovePostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncHistoryRemovePostShowSeason>()
                        {
                            new TraktSyncHistoryRemovePostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryRemovePostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncHistoryRemovePostShowSeason>()
                        {
                            new TraktSyncHistoryRemovePostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncHistoryRemovePostShowEpisode>()
                                {
                                    new TraktSyncHistoryRemovePostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncHistoryRemovePostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<ITraktSyncHistoryRemovePostEpisode>()
                {
                    new TraktSyncHistoryRemovePostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }

        private ITraktSyncWatchlistPost SetupRemoveWatchlistPost()
        {
            return new TraktSyncWatchlistPost
            {
                Movies = new List<ITraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncWatchlistPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<ITraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<ITraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<ITraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktSyncWatchlistPostShowEpisode>()
                                {
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };
        }
    }
}
