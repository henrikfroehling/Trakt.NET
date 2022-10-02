namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncWatchlistPostBuilder()
        {
            ITraktSyncWatchlistPostBuilder syncWatchlistPostBuilder = TraktPost.NewSyncWatchlistPost();
            syncWatchlistPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_Empty_Build()
        {
            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost().Build();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovie()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "movie title",
                Year = 2020,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithMovie(movie)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostMovie postMovie = syncWatchlistPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().BeNull();

            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovieWithNotes()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "movie title",
                Year = 2020,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            string notes = "movie notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movie, notes)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostMovie postMovie = syncWatchlistPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().Be(notes);

            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovies()
        {
            var movies = new List<ITraktMovie>
            {
                new TraktMovie
                {
                    Title = "movie 1 title",
                    Year = 2020,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 1,
                        Slug = "movie-1-title",
                        Imdb = "ttmovie1title",
                        Tmdb = 1
                    }
                },
                new TraktMovie
                {
                    Title = "movie 2 title",
                    Year = 2020,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 2,
                        Slug = "movie-2-title",
                        Imdb = "ttmovie2title",
                        Tmdb = 2
                    }
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithMovies(movies)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostMovie[] postMovies = syncWatchlistPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().BeNull();

            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMoviesWithNotes()
        {
            string notes = "movie notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(new List<Tuple<ITraktMovie, string>>
                {
                    new Tuple<ITraktMovie, string>(new TraktMovie
                        {
                            Title = "movie 1 title",
                            Year = 2020,
                            Ids = new TraktMovieIds
                            {
                                Trakt = 1,
                                Slug = "movie-1-title",
                                Imdb = "ttmovie1title",
                                Tmdb = 1
                            }
                        },
                        notes),
                    new Tuple<ITraktMovie, string>(new TraktMovie
                        {
                            Title = "movie 2 title",
                            Year = 2020,
                            Ids = new TraktMovieIds
                            {
                                Trakt = 2,
                                Slug = "movie-2-title",
                                Imdb = "ttmovie2title",
                                Tmdb = 2
                            }
                        },
                notes)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostMovie[] postMovies = syncWatchlistPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().Be(notes);

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().Be(notes);

            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShow()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShow(show)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();
            postShow.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            string notes = "show notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(show, notes)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();
            postShow.Notes.Should().Be(notes);

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShows()
        {
            var shows = new List<ITraktShow>
            {
                new TraktShow
                {
                    Title = "show 1 title",
                    Year = 2020,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1,
                        Slug = "show-1-title",
                        Imdb = "ttshow1title",
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktShow
                {
                    Title = "show 2 title",
                    Year = 2020,
                    Ids = new TraktShowIds
                    {
                        Trakt = 2,
                        Slug = "show-2-title",
                        Imdb = "ttshow2title",
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShows(shows)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow[] postShows = syncWatchlistPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();
            postShows[0].Notes.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();
            postShows[1].Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotes()
        {
            string notes = "show notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(new List<Tuple<ITraktShow, string>>
                {
                    new Tuple<ITraktShow, string>(new TraktShow
                        {
                            Title = "show 1 title",
                            Year = 2020,
                            Ids = new TraktShowIds
                            {
                                Trakt = 1,
                                Slug = "show-1-title",
                                Imdb = "ttshow1title",
                                Tmdb = 1,
                                Tvdb = 1,
                                TvRage = 1
                            }
                        },
                        notes),
                    new Tuple<ITraktShow, string>(new TraktShow
                        {
                            Title = "show 2 title",
                            Year = 2020,
                            Ids = new TraktShowIds
                            {
                                Trakt = 2,
                                Slug = "show-2-title",
                                Imdb = "ttshow2title",
                                Tmdb = 2,
                                Tvdb = 2,
                                TvRage = 2
                            }
                        },
                        notes)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow[] postShows = syncWatchlistPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();
            postShows[0].Notes.Should().Be(notes);

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();
            postShows[1].Notes.Should().Be(notes);

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasons()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);
            postShow.Notes.Should().BeNull();

            ITraktSyncWatchlistPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasonsCollection()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            var seasons = new PostSeasonsOld
            {
                1,
                { 2, new PostEpisodesOld { 1, 2 } }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);
            postShow.Notes.Should().BeNull();

            ITraktSyncWatchlistPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisode()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "ttepisodetitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisode(episode)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodeWithNotes()
        {
            ITraktEpisode episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "ttepisodetitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            string notes = "episode notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodeWithNotes(episode, notes)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.Notes.Should().Be(notes);

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodes()
        {
            var episodes = new List<ITraktEpisode>
            {
                new TraktEpisode
                {
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 1,
                        Imdb = "ttepisode1title",
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktEpisode
                {
                    Ids = new TraktEpisodeIds
                    {
                        Trakt = 2,
                        Imdb = "ttepisode2title",
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodes(episodes)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode[] postEpisodes = syncWatchlistPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].Notes.Should().BeNull();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodesWithNotes()
        {
            string notes = "episode notes";

            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodesWithNotes(new List<Tuple<ITraktEpisode, string>>
                {
                    new Tuple<ITraktEpisode, string>(new TraktEpisode
                        {
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 1,
                                Imdb = "ttepisode1title",
                                Tmdb = 1,
                                Tvdb = 1,
                                TvRage = 1
                            }
                        },
                        notes),
                    new Tuple<ITraktEpisode, string>(new TraktEpisode
                        {
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 2,
                                Imdb = "ttepisode2title",
                                Tmdb = 2,
                                Tvdb = 2,
                                TvRage = 2
                            }
                        },
                        notes)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode[] postEpisodes = syncWatchlistPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].Notes.Should().Be(notes);

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].Notes.Should().Be(notes);

            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
        }
    }
}
