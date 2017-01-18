namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktMovieCommentPostTests
    {
        [TestMethod]
        public void TestTraktMovieCommentPostDefaultConstructor()
        {
            var movieComment = new TraktMovieCommentPost();

            movieComment.Comment.Should().BeNullOrEmpty();
            movieComment.Spoiler.Should().NotHaveValue();
            movieComment.Sharing.Should().BeNull();
            movieComment.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieCommentPostWriteJson()
        {
            var comment = "this is a comment";
            var spoiler = true;
            var sharing = new TraktSharing { Facebook = true, Twitter = true, Tumblr = true };

            var movieTitle = "Guardians of the Galaxy";
            var movieYear = 2014;
            var movieTraktId = 28U;
            var movieSlug = "guardiangs-of-the-galaxy-2014";
            var movieImdb = "tt2015381";
            var movieTmdb = 118340U;

            var movie = new TraktMovie
            {
                Title = movieTitle,
                Year = movieYear,
                Ids = new TraktMovieIds
                {
                    Trakt = movieTraktId,
                    Slug = movieSlug,
                    Imdb = movieImdb,
                    Tmdb = movieTmdb
                }
            };

            var movieComment = new TraktMovieCommentPost
            {
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing,
                Movie = movie
            };

            var strJson = JsonConvert.SerializeObject(movieComment);

            strJson.Should().NotBeNullOrEmpty();

            var movieCommentFromJson = JsonConvert.DeserializeObject<TraktMovieCommentPost>(strJson);

            movieCommentFromJson.Should().NotBeNull();
            movieCommentFromJson.Comment.Should().Be(comment);
            movieCommentFromJson.Spoiler.Should().Be(spoiler);
            movieCommentFromJson.Sharing.Should().NotBeNull();
            movieCommentFromJson.Sharing.Facebook.Should().BeTrue();
            movieCommentFromJson.Sharing.Twitter.Should().BeTrue();
            movieCommentFromJson.Sharing.Tumblr.Should().BeTrue();

            movieCommentFromJson.Movie.Should().NotBeNull();
            movieCommentFromJson.Movie.Title.Should().Be(movieTitle);
            movieCommentFromJson.Movie.Year.Should().Be(movieYear);
            movieCommentFromJson.Movie.Ids.Should().NotBeNull();
            movieCommentFromJson.Movie.Ids.Trakt.Should().Be(movieTraktId);
            movieCommentFromJson.Movie.Ids.Slug.Should().Be(movieSlug);
            movieCommentFromJson.Movie.Ids.Imdb.Should().Be(movieImdb);
            movieCommentFromJson.Movie.Ids.Tmdb.Should().Be(movieTmdb);
        }
    }
}
