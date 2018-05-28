namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using System.Collections.Generic;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Implementations;

    public partial class TraktUsersModule_Tests
    {
        private ITraktUserCustomListItemsPost AddCustomListItemsPost { get; }
        private ITraktUserCustomListItemsPost RemoveCustomListItemsPost { get; }
        private string GetHiddenItemsUri { get; }
        private string HistoryStartAt { get; }
        private string HistoryEndAt { get; }

        public TraktUsersModule_Tests()
        {
            AddCustomListItemsPost = SetupAddCustomListItemsPost();
            RemoveCustomListItemsPost = SetupRemoveCustomListItemsPost();
            GetHiddenItemsUri = $"users/hidden/{HIDDEN_ITEMS_SECTION.UriName}";
            HistoryStartAt = START_AT.ToTraktLongDateTimeString();
            HistoryEndAt = END_AT.ToTraktLongDateTimeString();
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
    }
}
