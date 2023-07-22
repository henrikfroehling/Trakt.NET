namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Implementations")]
    public class TraktSyncFavoritesPost_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPost_Default_Constructor()
        {
            var syncFavoritesPost = new TraktSyncFavoritesPost();

            syncFavoritesPost.Movies.Should().BeNull();
            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPost_From_Json()
        {
            var jsonReader = new SyncFavoritesPostObjectJsonReader();
            var syncFavoritesPost = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPost;

            syncFavoritesPost.Should().NotBeNull();

            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostMovie[] postMovies = syncFavoritesPost.Movies.ToArray();

            postMovies[0].Title.Should().Be("Batman Begins");
            postMovies[0].Year.Should().Be(2005);
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("batman-begins-2005");
            postMovies[0].Ids.Imdb.Should().Be("tt0372784");
            postMovies[0].Ids.Tmdb.Should().Be(272U);
            postMovies[0].Notes.Should().Be("One of Chritian Bale's most iconic roles.");

            postMovies[1].Title.Should().BeNull();
            postMovies[1].Year.Should().BeNull();
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(0U);
            postMovies[1].Ids.Slug.Should().BeNull();
            postMovies[1].Ids.Imdb.Should().Be("tt0000111");
            postMovies[1].Ids.Tmdb.Should().BeNull();
            postMovies[1].Notes.Should().BeNull();

            syncFavoritesPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostShow[] postShows = syncFavoritesPost.Shows.ToArray();

            postShows[0].Title.Should().Be("Breaking Bad");
            postShows[0].Year.Should().Be(2008);
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("breaking-bad");
            postShows[0].Ids.Tvdb.Should().Be(81189U);
            postShows[0].Ids.Imdb.Should().Be("tt0903747");
            postShows[0].Ids.Tmdb.Should().Be(1396U);
            postShows[0].Notes.Should().Be("I AM THE DANGER!");

            postShows[1].Title.Should().Be("The Walking Dead");
            postShows[1].Year.Should().Be(2010);
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("the-walking-dead");
            postShows[1].Ids.Tvdb.Should().Be(153021U);
            postShows[1].Ids.Imdb.Should().Be("tt1520211");
            postShows[1].Ids.Tmdb.Should().Be(1402U);
            postShows[1].Notes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSyncFavoritesPost_Validate()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = new TraktSyncFavoritesPost();
            
            // movies = null, shows = null
            Action act = () => syncFavoritesPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null
            syncFavoritesPost.Movies = new List<ITraktSyncFavoritesPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty
            syncFavoritesPost.Shows = new List<ITraktSyncFavoritesPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty
            (syncFavoritesPost.Movies as List<ITraktSyncFavoritesPostMovie>).Add(new TraktSyncFavoritesPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item
            (syncFavoritesPost.Movies as List<ITraktSyncFavoritesPostMovie>).Clear();
            (syncFavoritesPost.Shows as List<ITraktSyncFavoritesPostShow>).Add(new TraktSyncFavoritesPostShow());
            act.Should().NotThrow();
        }

        private const string JSON =
            @"{
                ""movies"": [
                  {
                    ""title"": ""Batman Begins"",
                    ""year"": 2005,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    },
                    ""notes"": ""One of Chritian Bale's most iconic roles.""
                  },
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000111""
                    }
                  }
                ],
                ""shows"": [
                  {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""breaking-bad"",
                      ""tvdb"": 81189,
                      ""imdb"": ""tt0903747"",
                      ""tmdb"": 1396
                    },
                    ""notes"": ""I AM THE DANGER!""
                  },
                  {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                ]
              }";
    }
}
