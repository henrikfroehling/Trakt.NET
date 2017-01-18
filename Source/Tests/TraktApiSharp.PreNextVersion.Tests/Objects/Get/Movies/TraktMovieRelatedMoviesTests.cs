namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieRelatedMoviesTests
    {
        [TestMethod]
        public void TestTraktMovieRelatedMoviesReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMovie>>(jsonFile);

            relatedMovies.Should().NotBeNull();
            relatedMovies.Should().HaveCount(2);

            var movies = relatedMovies.ToArray();

            movies[0].Title.Should().Be("Star Wars: Episode V - The Empire Strikes Back");
            movies[0].Year.Should().Be(1980);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1266U);
            movies[0].Ids.Slug.Should().Be("star-wars-episode-v-the-empire-strikes-back-1980");
            movies[0].Ids.Imdb.Should().Be("tt0080684");
            movies[0].Ids.Tmdb.Should().Be(1891U);

            movies[1].Title.Should().Be("Return of the Jedi");
            movies[1].Year.Should().Be(1983);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(1267U);
            movies[1].Ids.Slug.Should().Be("return-of-the-jedi-1983");
            movies[1].Ids.Imdb.Should().Be("tt0086190");
            movies[1].Ids.Tmdb.Should().Be(1892U);
        }

        [TestMethod]
        public void TestTraktMovieRelatedMoviesReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMovie>>(jsonFile);

            relatedMovies.Should().NotBeNull();
            relatedMovies.Should().HaveCount(2);

            var movies = relatedMovies.ToArray();

            movies[0].Title.Should().Be("Star Wars: Episode V - The Empire Strikes Back");
            movies[0].Year.Should().Be(1980);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1266U);
            movies[0].Ids.Slug.Should().Be("star-wars-episode-v-the-empire-strikes-back-1980");
            movies[0].Ids.Imdb.Should().Be("tt0080684");
            movies[0].Ids.Tmdb.Should().Be(1891U);
            movies[0].Images.Should().NotBeNull();
            movies[0].Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/original/e6f22a95c4.jpg");
            movies[0].Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/medium/e6f22a95c4.jpg");
            movies[0].Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/thumb/e6f22a95c4.jpg");
            movies[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/original/33004e8ae5.jpg");
            movies[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/medium/33004e8ae5.jpg");
            movies[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/thumb/33004e8ae5.jpg");
            movies[0].Images.Logo.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/logos/original/41b6d8d628.png");
            movies[0].Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/cleararts/original/73e98f5f87.png");
            movies[0].Images.Banner.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/banners/original/0c42c2d4f5.jpg");
            movies[0].Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/thumbs/original/dd04d96a00.jpg");

            movies[1].Title.Should().Be("Return of the Jedi");
            movies[1].Year.Should().Be(1983);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(1267U);
            movies[1].Ids.Slug.Should().Be("return-of-the-jedi-1983");
            movies[1].Ids.Imdb.Should().Be("tt0086190");
            movies[1].Ids.Tmdb.Should().Be(1892U);
            movies[1].Images.Should().NotBeNull();
            movies[1].Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/original/57469dd637.jpg");
            movies[1].Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/medium/57469dd637.jpg");
            movies[1].Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/thumb/57469dd637.jpg");
            movies[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/original/80c956258c.jpg");
            movies[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/medium/80c956258c.jpg");
            movies[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/thumb/80c956258c.jpg");
            movies[1].Images.Logo.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/logos/original/382be7b65d.png");
            movies[1].Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/cleararts/original/85a472d851.png");
            movies[1].Images.Banner.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/banners/original/632069ecb6.jpg");
            movies[1].Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/thumbs/original/a9a4f750a6.jpg");
        }

        [TestMethod]
        public void TestTraktMovieRelatedMoviesReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMovie>>(jsonFile);

            relatedMovies.Should().NotBeNull();
            relatedMovies.Should().HaveCount(2);

            var movies = relatedMovies.ToArray();

            movies[0].Title.Should().Be("Star Wars: Episode V - The Empire Strikes Back");
            movies[0].Year.Should().Be(1980);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1266U);
            movies[0].Ids.Slug.Should().Be("star-wars-episode-v-the-empire-strikes-back-1980");
            movies[0].Ids.Imdb.Should().Be("tt0080684");
            movies[0].Ids.Tmdb.Should().Be(1891U);
            movies[0].Tagline.Should().Be("The Adventure Continues...");
            movies[0].Overview.Should().Be("The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair.");
            movies[0].Released.Should().Be(DateTime.Parse("1980-05-17"));
            movies[0].Runtime.Should().Be(124);
            movies[0].Trailer.Should().BeNullOrEmpty();
            movies[0].Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-v-the-empire-strikes-back");
            movies[0].Rating.Should().Be(8.77461f);
            movies[0].Votes.Should().Be(13421);
            movies[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-04T08:50:42Z").ToUniversalTime());
            movies[0].LanguageCode.Should().Be("en");
            movies[0].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "fr", "it");
            movies[0].Genres.Should().NotBeNull().And.HaveCount(3).And.Contain("action", "adventure", "science-fiction");
            movies[0].Certification.Should().Be("PG");

            movies[1].Title.Should().Be("Return of the Jedi");
            movies[1].Year.Should().Be(1983);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(1267U);
            movies[1].Ids.Slug.Should().Be("return-of-the-jedi-1983");
            movies[1].Ids.Imdb.Should().Be("tt0086190");
            movies[1].Ids.Tmdb.Should().Be(1892U);
            movies[1].Tagline.Should().Be("The Empire Falls...");
            movies[1].Overview.Should().Be("As Rebel leaders map their strategy for an all-out attack on the Emperor's newer, bigger Death Star. Han Solo remains frozen in the cavernous desert fortress of Jabba the Hutt, the most loathsome outlaw in the universe, who is also keeping Princess Leia as a slave girl. Now a master of the Force, Luke Skywalker rescues his friends, but he cannot become a true Jedi Knight until he wages his own crucial battle against Darth Vader, who has sworn to win Luke over to the dark side of the Force.");
            movies[1].Released.Should().Be(DateTime.Parse("1983-05-25"));
            movies[1].Runtime.Should().Be(135);
            movies[1].Trailer.Should().Be("http://youtube.com/watch?v=2mqRbh7FJ0Y");
            movies[1].Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vi-return-of-the-jedi");
            movies[1].Rating.Should().Be(8.61184f);
            movies[1].Votes.Should().Be(12853);
            movies[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-04T08:51:42Z").ToUniversalTime());
            movies[1].LanguageCode.Should().Be("en");
            movies[1].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "fr", "it");
            movies[1].Genres.Should().NotBeNull().And.HaveCount(3).And.Contain("action", "adventure", "science-fiction");
            movies[1].Certification.Should().Be("PG");
        }

        [TestMethod]
        public void TestTraktMovieRelatedMoviesReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var relatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMovie>>(jsonFile);

            relatedMovies.Should().NotBeNull();
            relatedMovies.Should().HaveCount(2);

            var movies = relatedMovies.ToArray();

            movies[0].Title.Should().Be("Star Wars: Episode V - The Empire Strikes Back");
            movies[0].Year.Should().Be(1980);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1266U);
            movies[0].Ids.Slug.Should().Be("star-wars-episode-v-the-empire-strikes-back-1980");
            movies[0].Ids.Imdb.Should().Be("tt0080684");
            movies[0].Ids.Tmdb.Should().Be(1891U);
            movies[0].Images.Should().NotBeNull();
            movies[0].Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/original/e6f22a95c4.jpg");
            movies[0].Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/medium/e6f22a95c4.jpg");
            movies[0].Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/266/fanarts/thumb/e6f22a95c4.jpg");
            movies[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/original/33004e8ae5.jpg");
            movies[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/medium/33004e8ae5.jpg");
            movies[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/266/posters/thumb/33004e8ae5.jpg");
            movies[0].Images.Logo.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/logos/original/41b6d8d628.png");
            movies[0].Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/cleararts/original/73e98f5f87.png");
            movies[0].Images.Banner.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/banners/original/0c42c2d4f5.jpg");
            movies[0].Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/266/thumbs/original/dd04d96a00.jpg");
            movies[0].Tagline.Should().Be("The Adventure Continues...");
            movies[0].Overview.Should().Be("The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair.");
            movies[0].Released.Should().Be(DateTime.Parse("1980-05-17"));
            movies[0].Runtime.Should().Be(124);
            movies[0].Trailer.Should().BeNullOrEmpty();
            movies[0].Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-v-the-empire-strikes-back");
            movies[0].Rating.Should().Be(8.77461f);
            movies[0].Votes.Should().Be(13421);
            movies[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-04T08:50:42Z").ToUniversalTime());
            movies[0].LanguageCode.Should().Be("en");
            movies[0].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "fr", "it");
            movies[0].Genres.Should().NotBeNull().And.HaveCount(3).And.Contain("action", "adventure", "science-fiction");
            movies[0].Certification.Should().Be("PG");

            movies[1].Title.Should().Be("Return of the Jedi");
            movies[1].Year.Should().Be(1983);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(1267U);
            movies[1].Ids.Slug.Should().Be("return-of-the-jedi-1983");
            movies[1].Ids.Imdb.Should().Be("tt0086190");
            movies[1].Ids.Tmdb.Should().Be(1892U);
            movies[1].Images.Should().NotBeNull();
            movies[1].Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/original/57469dd637.jpg");
            movies[1].Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/medium/57469dd637.jpg");
            movies[1].Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/267/fanarts/thumb/57469dd637.jpg");
            movies[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/original/80c956258c.jpg");
            movies[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/medium/80c956258c.jpg");
            movies[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/001/267/posters/thumb/80c956258c.jpg");
            movies[1].Images.Logo.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/logos/original/382be7b65d.png");
            movies[1].Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/cleararts/original/85a472d851.png");
            movies[1].Images.Banner.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/banners/original/632069ecb6.jpg");
            movies[1].Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/movies/000/001/267/thumbs/original/a9a4f750a6.jpg");
            movies[1].Tagline.Should().Be("The Empire Falls...");
            movies[1].Overview.Should().Be("As Rebel leaders map their strategy for an all-out attack on the Emperor's newer, bigger Death Star. Han Solo remains frozen in the cavernous desert fortress of Jabba the Hutt, the most loathsome outlaw in the universe, who is also keeping Princess Leia as a slave girl. Now a master of the Force, Luke Skywalker rescues his friends, but he cannot become a true Jedi Knight until he wages his own crucial battle against Darth Vader, who has sworn to win Luke over to the dark side of the Force.");
            movies[1].Released.Should().Be(DateTime.Parse("1983-05-25"));
            movies[1].Runtime.Should().Be(135);
            movies[1].Trailer.Should().Be("http://youtube.com/watch?v=2mqRbh7FJ0Y");
            movies[1].Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vi-return-of-the-jedi");
            movies[1].Rating.Should().Be(8.61184f);
            movies[1].Votes.Should().Be(12853);
            movies[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-04T08:51:42Z").ToUniversalTime());
            movies[1].LanguageCode.Should().Be("en");
            movies[1].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "fr", "it");
            movies[1].Genres.Should().NotBeNull().And.HaveCount(3).And.Contain("action", "adventure", "science-fiction");
            movies[1].Certification.Should().Be("PG");
        }
    }
}
