namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using System.Collections.Generic;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using TraktNet.Objects.Post.Users.PersonalListItems;

    public partial class TraktUsersModule_Tests
    {
        private ITraktUserPersonalListItemsPost AddPersonalListItemsPost { get; }
        private ITraktUserPersonalListItemsPost RemovePersonalListItemsPost { get; }
        private string GetHiddenItemsUri { get; }
        private string HistoryStartAt { get; }
        private string HistoryEndAt { get; }
        private string[] MulitpleListItemTypesUriNames { get; }
        private string AddHiddenItemsUri { get; }
        private string RemoveHiddenItemsUri { get; }
        private ITraktUserHiddenItemsPost HiddenItemsPost { get; }
        private ITraktUserHiddenItemsRemovePost HiddenItemsRemovePost { get; }

        public TraktUsersModule_Tests()
        {
            AddPersonalListItemsPost = SetupAddPersonalListItemsPost();
            RemovePersonalListItemsPost = SetupRemovePersonalListItemsPost();
            GetHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}";
            HistoryStartAt = START_AT.ToTraktLongDateTimeString();
            HistoryEndAt = END_AT.ToTraktLongDateTimeString();
            MulitpleListItemTypesUriNames = new string[] { LIST_ITEM_TYPE_MOVIE.UriName, LIST_ITEM_TYPE_SHOW.UriName };
            AddHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}";
            RemoveHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}/remove";
            HiddenItemsPost = SetupHiddenItemsPost();
            HiddenItemsRemovePost = SetupHiddenItemsRemovePost();
        }

        private ITraktUserPersonalListItemsPost SetupAddPersonalListItemsPost()
        {
            return new TraktUserPersonalListItemsPost
            {
                Movies = new List<ITraktUserPersonalListItemsPostMovie>()
                {
                    new TraktUserPersonalListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserPersonalListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserPersonalListItemsPostShow>()
                {
                    new TraktUserPersonalListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserPersonalListItemsPostShow
                    {
                        Seasons = new List<ITraktUserPersonalListItemsPostShowSeason>()
                        {
                            new TraktUserPersonalListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserPersonalListItemsPostShow
                    {
                        Seasons = new List<ITraktUserPersonalListItemsPostShowSeason>()
                        {
                            new TraktUserPersonalListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktUserPersonalListItemsPostShowEpisode>()
                                {
                                    new TraktUserPersonalListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserPersonalListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<ITraktUserPersonalListItemsPostPerson>()
                {
                    new TraktUserPersonalListItemsPostPerson
                    {
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };
        }

        private ITraktUserPersonalListItemsPost SetupRemovePersonalListItemsPost()
        {
            return new TraktUserPersonalListItemsPost
            {
                Movies = new List<ITraktUserPersonalListItemsPostMovie>()
                {
                    new TraktUserPersonalListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserPersonalListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserPersonalListItemsPostShow>()
                {
                    new TraktUserPersonalListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserPersonalListItemsPostShow
                    {
                        Seasons = new List<ITraktUserPersonalListItemsPostShowSeason>()
                        {
                            new TraktUserPersonalListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserPersonalListItemsPostShow
                    {
                        Seasons = new List<ITraktUserPersonalListItemsPostShowSeason>()
                        {
                            new TraktUserPersonalListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktUserPersonalListItemsPostShowEpisode>()
                                {
                                    new TraktUserPersonalListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserPersonalListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<ITraktUserPersonalListItemsPostPerson>()
                {
                    new TraktUserPersonalListItemsPostPerson
                    {
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };
        }

        private ITraktUserHiddenItemsPost SetupHiddenItemsPost()
        {
            return new TraktUserHiddenItemsPost
            {
                Movies = new List<ITraktUserHiddenItemsPostMovie>()
                {
                    new TraktUserHiddenItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserHiddenItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserHiddenItemsPostShow>()
                {
                    new TraktUserHiddenItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons = new List<ITraktUserHiddenItemsPostShowSeason>()
                        {
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons = new List<ITraktUserHiddenItemsPostShowSeason>()
                        {
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 2
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                Seasons = new List<ITraktUserHiddenItemsPostSeason>()
                {
                    new TraktUserHiddenItemsPostSeason
                    {
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430,
                            Tvdb = 578373,
                            Tmdb = 60523,
                            TvRage = 36939
                        }
                    }
                }
            };
        }

        private ITraktUserHiddenItemsRemovePost SetupHiddenItemsRemovePost()
        {
            return new TraktUserHiddenItemsRemovePost
            {
                Movies = new List<ITraktUserHiddenItemsPostMovie>()
                {
                    new TraktUserHiddenItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserHiddenItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserHiddenItemsPostShow>()
                {
                    new TraktUserHiddenItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons = new List<ITraktUserHiddenItemsPostShowSeason>()
                        {
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserHiddenItemsPostShow
                    {
                        Seasons = new List<ITraktUserHiddenItemsPostShowSeason>()
                        {
                            new TraktUserHiddenItemsPostShowSeason
                            {
                                Number = 2
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                Seasons = new List<ITraktUserHiddenItemsPostSeason>()
                {
                    new TraktUserHiddenItemsPostSeason
                    {
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430,
                            Tvdb = 578373,
                            Tmdb = 60523,
                            TvRage = 36939
                        }
                    }
                }
            };
        }
    }
}
