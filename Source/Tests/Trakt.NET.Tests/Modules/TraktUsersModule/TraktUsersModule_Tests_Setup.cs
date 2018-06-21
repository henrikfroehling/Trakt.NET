namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.CustomListItems;
    using TraktNet.Objects.Post.Users.HiddenItems;

    public partial class TraktUsersModule_Tests
    {
        private ITraktUserCustomListItemsPost AddCustomListItemsPost { get; }
        private ITraktUserCustomListItemsPost RemoveCustomListItemsPost { get; }
        private string GetHiddenItemsUri { get; }
        private string HistoryStartAt { get; }
        private string HistoryEndAt { get; }
        private TraktListItemType MulitpleListItemTypes { get; }
        private string[] MulitpleListItemTypesUriNames { get; }
        private string MulitpleListItemTypesEncoded { get; }
        private string GetMulitpleListItemTypes { get; }
        private string AddHiddenItemsUri { get; }
        private string RemoveHiddenItemsUri { get; }
        private ITraktUserHiddenItemsPost HiddenItemsPost { get; }

        public TraktUsersModule_Tests()
        {
            AddCustomListItemsPost = SetupAddCustomListItemsPost();
            RemoveCustomListItemsPost = SetupRemoveCustomListItemsPost();
            GetHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}";
            HistoryStartAt = START_AT.ToTraktLongDateTimeString();
            HistoryEndAt = END_AT.ToTraktLongDateTimeString();
            MulitpleListItemTypes = LIST_ITEM_TYPE_MOVIE | LIST_ITEM_TYPE_SHOW;
            MulitpleListItemTypesUriNames = new string[] { LIST_ITEM_TYPE_MOVIE.UriName, LIST_ITEM_TYPE_SHOW.UriName };
            MulitpleListItemTypesEncoded = string.Join(ENCODED_COMMA, MulitpleListItemTypesUriNames);
            AddHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}";
            RemoveHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}/remove";
            HiddenItemsPost = SetupHiddenItemsPost();
        }

        private ITraktUserCustomListItemsPost SetupAddCustomListItemsPost()
        {
            return new TraktUserCustomListItemsPost
            {
                Movies = new List<ITraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<ITraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<ITraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<ITraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
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

        private ITraktUserCustomListItemsPost SetupRemoveCustomListItemsPost()
        {
            return new TraktUserCustomListItemsPost
            {
                Movies = new List<ITraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<ITraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<ITraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<ITraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<ITraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<ITraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
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
    }
}
