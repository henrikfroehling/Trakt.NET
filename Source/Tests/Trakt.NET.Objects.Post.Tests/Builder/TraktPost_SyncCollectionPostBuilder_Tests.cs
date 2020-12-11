namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncCollectionPostBuilder_Tests
    {
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_TraktPost_Get_SyncCollectionPostBuilder()
        {
            ITraktSyncCollectionPostBuilder syncCollectionPostBuilder = TraktPost.NewSyncCollectionPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_Empty_Build()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost().Build();
            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovie()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovie(movie)
                .Build();
            
            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovies()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovies(movies)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie[] postMovies = syncCollectionPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].CollectedAt.Should().BeNull();
            postMovies[0].Audio.Should().BeNull();
            postMovies[0].AudioChannels.Should().BeNull();
            postMovies[0].MediaType.Should().BeNull();
            postMovies[0].MediaResolution.Should().BeNull();
            postMovies[0].HDR.Should().BeNull();
            postMovies[0].ThreeDimensional.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].CollectedAt.Should().BeNull();
            postMovies[1].Audio.Should().BeNull();
            postMovies[1].AudioChannels.Should().BeNull();
            postMovies[1].MediaType.Should().BeNull();
            postMovies[1].MediaResolution.Should().BeNull();
            postMovies[1].HDR.Should().BeNull();
            postMovies[1].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesAndMetadata()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var movies = new List<Tuple<ITraktMovie, ITraktMetadata>>
            {
                new Tuple<ITraktMovie, ITraktMetadata>
                (
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
                    metadata
                ),
                new Tuple<ITraktMovie, ITraktMetadata>
                (
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
                    },
                    metadata
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesAndMetadata(movies)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie[] postMovies = syncCollectionPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].CollectedAt.Should().BeNull();
            postMovies[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovies[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovies[0].MediaType.Should().Be(TraktMediaType.Digital);
            postMovies[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovies[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovies[0].ThreeDimensional.Should().BeTrue();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].CollectedAt.Should().BeNull();
            postMovies[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovies[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovies[1].MediaType.Should().Be(TraktMediaType.Digital);
            postMovies[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovies[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovies[1].ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesAndMetadata_With_CollectedAt()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var movies = new List<Tuple<ITraktMovie, ITraktMetadata, DateTime?>>
            {
                new Tuple<ITraktMovie, ITraktMetadata, DateTime?>
                (
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
                    metadata,
                    COLLECTED_AT
                ),
                new Tuple<ITraktMovie, ITraktMetadata, DateTime?>
                (
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
                    },
                    metadata,
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesAndMetadata(movies)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie[] postMovies = syncCollectionPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].CollectedAt.Should().Be(COLLECTED_AT);
            postMovies[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovies[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovies[0].MediaType.Should().Be(TraktMediaType.Digital);
            postMovies[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovies[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovies[0].ThreeDimensional.Should().BeTrue();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].CollectedAt.Should().Be(COLLECTED_AT);
            postMovies[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovies[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovies[1].MediaType.Should().Be(TraktMediaType.Digital);
            postMovies[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovies[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovies[1].ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithCollectedMovies()
        {
            var movies = new List<Tuple<ITraktMovie, DateTime?>>
            {
                new Tuple<ITraktMovie, DateTime?>
                (
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
                    COLLECTED_AT
                ),
                new Tuple<ITraktMovie, DateTime?>
                (
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
                    },
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithCollectedMovies(movies)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie[] postMovies = syncCollectionPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].CollectedAt.Should().Be(COLLECTED_AT);
            postMovies[0].Audio.Should().BeNull();
            postMovies[0].AudioChannels.Should().BeNull();
            postMovies[0].MediaType.Should().BeNull();
            postMovies[0].MediaResolution.Should().BeNull();
            postMovies[0].HDR.Should().BeNull();
            postMovies[0].ThreeDimensional.Should().BeNull();

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].CollectedAt.Should().Be(COLLECTED_AT);
            postMovies[1].Audio.Should().BeNull();
            postMovies[1].AudioChannels.Should().BeNull();
            postMovies[1].MediaType.Should().BeNull();
            postMovies[1].MediaResolution.Should().BeNull();
            postMovies[1].HDR.Should().BeNull();
            postMovies[1].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddCollectedMovie()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddCollectedMovie(movie).CollectedAt(COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.CollectedAt.Should().Be(COLLECTED_AT);
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddMovieAndMetadata()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddMovieAndMetadata(movie).WithMetadata(metadata)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovie.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovie.MediaType.Should().Be(TraktMediaType.Digital);
            postMovie.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovie.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovie.ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddMovieAndMetadata_With_CollectedAt()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddMovieAndMetadata(movie).WithMetadata(metadata, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.CollectedAt.Should().Be(COLLECTED_AT);
            postMovie.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postMovie.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postMovie.MediaType.Should().Be(TraktMediaType.Digital);
            postMovie.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postMovie.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postMovie.ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShow()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShow(show)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShows()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShows(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().BeNull();
            postShows[0].Audio.Should().BeNull();
            postShows[0].AudioChannels.Should().BeNull();
            postShows[0].MediaType.Should().BeNull();
            postShows[0].MediaResolution.Should().BeNull();
            postShows[0].HDR.Should().BeNull();
            postShows[0].ThreeDimensional.Should().BeNull();
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().BeNull();
            postShows[1].Audio.Should().BeNull();
            postShows[1].AudioChannels.Should().BeNull();
            postShows[1].MediaType.Should().BeNull();
            postShows[1].MediaResolution.Should().BeNull();
            postShows[1].HDR.Should().BeNull();
            postShows[1].ThreeDimensional.Should().BeNull();
            postShows[1].Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndMetadata()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var shows = new List<Tuple<ITraktShow, ITraktMetadata>>
            {
                new Tuple<ITraktShow, ITraktMetadata>
                (
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
                    metadata
                ),
                new Tuple<ITraktShow, ITraktMetadata>
                (
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
                    },
                    metadata
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndMetadata(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().BeNull();
            postShows[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[0].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[0].ThreeDimensional.Should().BeTrue();
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().BeNull();
            postShows[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[1].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[1].ThreeDimensional.Should().BeTrue();
            postShows[1].Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndMetadata_With_CollectedAt()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var shows = new List<Tuple<ITraktShow, ITraktMetadata, DateTime?>>
            {
                new Tuple<ITraktShow, ITraktMetadata, DateTime?>
                (
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
                    metadata,
                    COLLECTED_AT
                ),
                new Tuple<ITraktShow, ITraktMetadata, DateTime?>
                (
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
                    },
                    metadata,
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndMetadata(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[0].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[0].ThreeDimensional.Should().BeTrue();
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[1].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[1].ThreeDimensional.Should().BeTrue();
            postShows[1].Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndMetadata_And_Seasons()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            var shows = new List<Tuple<ITraktShow, ITraktMetadata, PostSeasons>>
            {
                new Tuple<ITraktShow, ITraktMetadata, PostSeasons>
                (
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
                    metadata,
                    seasons
                ),
                new Tuple<ITraktShow, ITraktMetadata, PostSeasons>
                (
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
                    },
                    metadata,
                    seasons
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndMetadata(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().BeNull();
            postShows[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[0].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[0].ThreeDimensional.Should().BeTrue();
            postShows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShows[0].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            // ---------------------------------------------------------------------------

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().BeNull();
            postShows[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[1].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[1].ThreeDimensional.Should().BeTrue();
            postShows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            showSeasons = postShows[1].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndMetadata_And_Seasons_And_CollectedAt()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            var shows = new List<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>>
            {
                new Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>
                (
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
                    metadata,
                    COLLECTED_AT,
                    seasons
                ),
                new Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>
                (
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
                    },
                    metadata,
                    COLLECTED_AT,
                    seasons
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndMetadata(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[0].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[0].ThreeDimensional.Should().BeTrue();
            postShows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShows[0].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            // ---------------------------------------------------------------------------

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShows[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShows[1].MediaType.Should().Be(TraktMediaType.Digital);
            postShows[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShows[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShows[1].ThreeDimensional.Should().BeTrue();
            postShows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            showSeasons = postShows[1].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithCollectedShows()
        {
            var shows = new List<Tuple<ITraktShow, DateTime?>>
            {
                new Tuple<ITraktShow, DateTime?>
                (
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
                    COLLECTED_AT
                ),
                new Tuple<ITraktShow, DateTime?>
                (
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
                    },
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithCollectedShows(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[0].Audio.Should().BeNull();
            postShows[0].AudioChannels.Should().BeNull();
            postShows[0].MediaType.Should().BeNull();
            postShows[0].MediaResolution.Should().BeNull();
            postShows[0].HDR.Should().BeNull();
            postShows[0].ThreeDimensional.Should().BeNull();
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[1].Audio.Should().BeNull();
            postShows[1].AudioChannels.Should().BeNull();
            postShows[1].MediaType.Should().BeNull();
            postShows[1].MediaResolution.Should().BeNull();
            postShows[1].HDR.Should().BeNull();
            postShows[1].ThreeDimensional.Should().BeNull();
            postShows[1].Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithCollectedShows_And_Seasons()
        {
            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            var shows = new List<Tuple<ITraktShow, DateTime?, PostSeasons>>
            {
                new Tuple<ITraktShow, DateTime?, PostSeasons>
                (
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
                    COLLECTED_AT,
                    seasons
                ),
                new Tuple<ITraktShow, DateTime?, PostSeasons>
                (
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
                    },
                    COLLECTED_AT,
                    seasons
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithCollectedShows(shows)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow[] postShows = syncCollectionPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[0].Audio.Should().BeNull();
            postShows[0].AudioChannels.Should().BeNull();
            postShows[0].MediaType.Should().BeNull();
            postShows[0].MediaResolution.Should().BeNull();
            postShows[0].HDR.Should().BeNull();
            postShows[0].ThreeDimensional.Should().BeNull();
            postShows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShows[0].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            // ---------------------------------------------------------------------------

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].CollectedAt.Should().Be(COLLECTED_AT);
            postShows[1].Audio.Should().BeNull();
            postShows[1].AudioChannels.Should().BeNull();
            postShows[1].MediaType.Should().BeNull();
            postShows[1].MediaResolution.Should().BeNull();
            postShows[1].HDR.Should().BeNull();
            postShows[1].ThreeDimensional.Should().BeNull();
            postShows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            showSeasons = postShows[1].Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddCollectedShow()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddCollectedShow(show).CollectedAt(COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddCollectedShowAndSeasons()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddCollectedShowAndSeasons(show).CollectedAt(COLLECTED_AT, 1, 2, 3)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncCollectionPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddCollectedShowAndSeasonsCollection()
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

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddCollectedShowAndSeasonsCollection(show).CollectedAt(COLLECTED_AT, seasons)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadata()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadata(show).WithMetadata(metadata)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadata_With_CollectedAt()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadata(show).WithMetadata(metadata, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadataAndSeasons()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadataAndSeasons(show).WithMetadata(metadata, 1, 2, 3)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncCollectionPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadataAndSeasons_With_CollectedAt()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadataAndSeasons(show).WithMetadata(metadata, COLLECTED_AT, 1, 2, 3)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncCollectionPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadataAndSeasonsCollection()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadataAndSeasonsCollection(show).WithMetadata(metadata, seasons)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndMetadataAndSeasonsCollection_With_CollectedAt()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndMetadataAndSeasonsCollection(show).WithMetadata(metadata, COLLECTED_AT, seasons)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postShow.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postShow.MediaType.Should().Be(TraktMediaType.Digital);
            postShow.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postShow.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postShow.ThreeDimensional.Should().BeTrue();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndSeasons()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktSyncCollectionPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddShowAndSeasonsCollection()
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

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShowEpisode[] showSeasonEpisodes = showSeasons[1].Episodes.ToArray();

            showSeasonEpisodes[0].Number.Should().Be(1);
            showSeasonEpisodes[1].Number.Should().Be(2);

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisode()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisode(episode)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodes()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodes(episodes)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode[] postEpisodes = syncCollectionPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].CollectedAt.Should().BeNull();
            postEpisodes[0].Audio.Should().BeNull();
            postEpisodes[0].AudioChannels.Should().BeNull();
            postEpisodes[0].MediaType.Should().BeNull();
            postEpisodes[0].MediaResolution.Should().BeNull();
            postEpisodes[0].HDR.Should().BeNull();
            postEpisodes[0].ThreeDimensional.Should().BeNull();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].CollectedAt.Should().BeNull();
            postEpisodes[1].Audio.Should().BeNull();
            postEpisodes[1].AudioChannels.Should().BeNull();
            postEpisodes[1].MediaType.Should().BeNull();
            postEpisodes[1].MediaResolution.Should().BeNull();
            postEpisodes[1].HDR.Should().BeNull();
            postEpisodes[1].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesAndMetadata()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var episodes = new List<Tuple<ITraktEpisode, ITraktMetadata>>
            {
                new Tuple<ITraktEpisode, ITraktMetadata>
                (
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
                    metadata
                ),
                new Tuple<ITraktEpisode, ITraktMetadata>
                (
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
                    },
                    metadata
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesAndMetadata(episodes)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode[] postEpisodes = syncCollectionPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].CollectedAt.Should().BeNull();
            postEpisodes[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisodes[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisodes[0].MediaType.Should().Be(TraktMediaType.Digital);
            postEpisodes[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisodes[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisodes[0].ThreeDimensional.Should().BeTrue();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].CollectedAt.Should().BeNull();
            postEpisodes[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisodes[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisodes[1].MediaType.Should().Be(TraktMediaType.Digital);
            postEpisodes[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisodes[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisodes[1].ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesAndMetadata_With_CollectedAt()
        {
            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            var episodes = new List<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>>
            {
                new Tuple<ITraktEpisode, ITraktMetadata, DateTime?>
                (
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
                    metadata,
                    COLLECTED_AT
                ),
                new Tuple<ITraktEpisode, ITraktMetadata, DateTime?>
                (
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
                    },
                    metadata,
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesAndMetadata(episodes)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode[] postEpisodes = syncCollectionPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].CollectedAt.Should().Be(COLLECTED_AT);
            postEpisodes[0].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisodes[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisodes[0].MediaType.Should().Be(TraktMediaType.Digital);
            postEpisodes[0].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisodes[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisodes[0].ThreeDimensional.Should().BeTrue();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].CollectedAt.Should().Be(COLLECTED_AT);
            postEpisodes[1].Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisodes[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisodes[1].MediaType.Should().Be(TraktMediaType.Digital);
            postEpisodes[1].MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisodes[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisodes[1].ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithCollectedEpisodes()
        {
            var episodes = new List<Tuple<ITraktEpisode, DateTime?>>
            {
                new Tuple<ITraktEpisode, DateTime?>
                (
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
                    COLLECTED_AT
                ),
                new Tuple<ITraktEpisode, DateTime?>
                (
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
                    },
                    COLLECTED_AT
                )
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithCollectedEpisodes(episodes)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode[] postEpisodes = syncCollectionPost.Episodes.ToArray();

            postEpisodes[0].Ids.Should().NotBeNull();
            postEpisodes[0].Ids.Trakt.Should().Be(1U);
            postEpisodes[0].Ids.Imdb.Should().Be("ttepisode1title");
            postEpisodes[0].Ids.Tmdb.Should().Be(1U);
            postEpisodes[0].Ids.Tvdb.Should().Be(1U);
            postEpisodes[0].Ids.TvRage.Should().Be(1U);
            postEpisodes[0].CollectedAt.Should().Be(COLLECTED_AT);
            postEpisodes[0].Audio.Should().BeNull();
            postEpisodes[0].AudioChannels.Should().BeNull();
            postEpisodes[0].MediaType.Should().BeNull();
            postEpisodes[0].MediaResolution.Should().BeNull();
            postEpisodes[0].HDR.Should().BeNull();
            postEpisodes[0].ThreeDimensional.Should().BeNull();

            postEpisodes[1].Ids.Should().NotBeNull();
            postEpisodes[1].Ids.Trakt.Should().Be(2U);
            postEpisodes[1].Ids.Imdb.Should().Be("ttepisode2title");
            postEpisodes[1].Ids.Tmdb.Should().Be(2U);
            postEpisodes[1].Ids.Tvdb.Should().Be(2U);
            postEpisodes[1].Ids.TvRage.Should().Be(2U);
            postEpisodes[1].CollectedAt.Should().Be(COLLECTED_AT);
            postEpisodes[1].Audio.Should().BeNull();
            postEpisodes[1].AudioChannels.Should().BeNull();
            postEpisodes[1].MediaType.Should().BeNull();
            postEpisodes[1].MediaResolution.Should().BeNull();
            postEpisodes[1].HDR.Should().BeNull();
            postEpisodes[1].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddCollectedEpisode()
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

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddCollectedEpisode(episode).CollectedAt(COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddEpisodeAndMetadata()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddEpisodeAndMetadata(episode).WithMetadata(metadata)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisode.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisode.MediaType.Should().Be(TraktMediaType.Digital);
            postEpisode.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisode.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisode.ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_AddEpisodeAndMetadata_With_CollectedAt()
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

            ITraktMetadata metadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                MediaResolution = TraktMediaResolution.UHD_4k,
                MediaType = TraktMediaType.Digital,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .AddEpisodeAndMetadata(episode).WithMetadata(metadata, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(1U);
            postEpisode.Ids.Imdb.Should().Be("ttepisodetitle");
            postEpisode.Ids.Tmdb.Should().Be(1U);
            postEpisode.Ids.Tvdb.Should().Be(1U);
            postEpisode.Ids.TvRage.Should().Be(1U);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().Be(TraktMediaAudio.DolbyAtmos);
            postEpisode.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_7_1);
            postEpisode.MediaType.Should().Be(TraktMediaType.Digital);
            postEpisode.MediaResolution.Should().Be(TraktMediaResolution.UHD_4k);
            postEpisode.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            postEpisode.ThreeDimensional.Should().BeTrue();

            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
        }
    }
}
