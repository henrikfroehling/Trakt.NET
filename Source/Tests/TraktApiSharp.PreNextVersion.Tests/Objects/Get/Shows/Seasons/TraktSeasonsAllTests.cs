namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonsAllTests
    {
        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Minimal\SeasonsAllMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);

            seasonsArray[0].Episodes.Should().BeNull();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();

            seasonsArray[1].Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonMinimalWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Minimal\SeasonsAllMinimalWithEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);

            seasonsArray[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season1Episodes = seasonsArray[0].Episodes.ToArray();

            season1Episodes[0].SeasonNumber.Should().Be(1);
            season1Episodes[0].Number.Should().Be(1);
            season1Episodes[0].Title.Should().Be("City of Heroes");
            season1Episodes[0].Ids.Should().NotBeNull();
            season1Episodes[0].Ids.Trakt.Should().Be(962074U);
            season1Episodes[0].Ids.Tvdb.Should().Be(4812524U);
            season1Episodes[0].Ids.Imdb.Should().Be("tt3187092");
            season1Episodes[0].Ids.Tmdb.Should().Be(977122U);
            season1Episodes[0].Ids.TvRage.Should().Be(1065564472U);

            season1Episodes[1].SeasonNumber.Should().Be(1);
            season1Episodes[1].Number.Should().Be(2);
            season1Episodes[1].Title.Should().Be("Fastest Man Alive");
            season1Episodes[1].Ids.Should().NotBeNull();
            season1Episodes[1].Ids.Trakt.Should().Be(962075U);
            season1Episodes[1].Ids.Tvdb.Should().Be(4929322U);
            season1Episodes[1].Ids.Imdb.Should().Be("tt3819518");
            season1Episodes[1].Ids.Tmdb.Should().Be(1005650U);
            season1Episodes[1].Ids.TvRage.Should().Be(1065603573U);

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();

            seasonsArray[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season2Episodes = seasonsArray[1].Episodes.ToArray();

            season2Episodes[0].SeasonNumber.Should().Be(2);
            season2Episodes[0].Number.Should().Be(1);
            season2Episodes[0].Title.Should().Be("The Man Who Saved Central City");
            season2Episodes[0].Ids.Should().NotBeNull();
            season2Episodes[0].Ids.Trakt.Should().Be(1866102U);
            season2Episodes[0].Ids.Tvdb.Should().Be(5260562U);
            season2Episodes[0].Ids.Imdb.Should().BeNull();
            season2Episodes[0].Ids.Tmdb.Should().Be(1063859U);
            season2Episodes[0].Ids.TvRage.Should().Be(0U);

            season2Episodes[1].SeasonNumber.Should().Be(2);
            season2Episodes[1].Number.Should().Be(2);
            season2Episodes[1].Title.Should().Be("Flash of Two Worlds");
            season2Episodes[1].Ids.Should().NotBeNull();
            season2Episodes[1].Ids.Trakt.Should().Be(1933746U);
            season2Episodes[1].Ids.Tvdb.Should().Be(5280328U);
            season2Episodes[1].Ids.Imdb.Should().BeNull();
            season2Episodes[1].Ids.Tmdb.Should().Be(1063860U);
            season2Episodes[1].Ids.TvRage.Should().Be(0U);
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Images\SeasonsAllImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Images.Should().NotBeNull();
            seasonsArray[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            seasonsArray[0].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[0].Episodes.Should().BeNull();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Images.Should().NotBeNull();
            seasonsArray[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/original/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/medium/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/thumb/26132fb16c.jpg");
            seasonsArray[1].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[1].Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonImagesWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Images\SeasonsAllImagesWithEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Images.Should().NotBeNull();
            seasonsArray[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            seasonsArray[0].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season1Episodes = seasonsArray[0].Episodes.ToArray();

            season1Episodes[0].SeasonNumber.Should().Be(1);
            season1Episodes[0].Number.Should().Be(1);
            season1Episodes[0].Title.Should().Be("City of Heroes");
            season1Episodes[0].Ids.Should().NotBeNull();
            season1Episodes[0].Ids.Trakt.Should().Be(962074U);
            season1Episodes[0].Ids.Tvdb.Should().Be(4812524U);
            season1Episodes[0].Ids.Imdb.Should().Be("tt3187092");
            season1Episodes[0].Ids.Tmdb.Should().Be(977122U);
            season1Episodes[0].Ids.TvRage.Should().Be(1065564472U);
            season1Episodes[0].Images.Should().NotBeNull();
            season1Episodes[0].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/original/b992ef650c.jpg");
            season1Episodes[0].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/medium/b992ef650c.jpg");
            season1Episodes[0].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/thumb/b992ef650c.jpg");

            season1Episodes[1].SeasonNumber.Should().Be(1);
            season1Episodes[1].Number.Should().Be(2);
            season1Episodes[1].Title.Should().Be("Fastest Man Alive");
            season1Episodes[1].Ids.Should().NotBeNull();
            season1Episodes[1].Ids.Trakt.Should().Be(962075U);
            season1Episodes[1].Ids.Tvdb.Should().Be(4929322U);
            season1Episodes[1].Ids.Imdb.Should().Be("tt3819518");
            season1Episodes[1].Ids.Tmdb.Should().Be(1005650U);
            season1Episodes[1].Ids.TvRage.Should().Be(1065603573U);
            season1Episodes[1].Images.Should().NotBeNull();
            season1Episodes[1].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/original/a7e0815b17.jpg");
            season1Episodes[1].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/medium/a7e0815b17.jpg");
            season1Episodes[1].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/thumb/a7e0815b17.jpg");

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Images.Should().NotBeNull();
            seasonsArray[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/original/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/medium/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/thumb/26132fb16c.jpg");
            seasonsArray[1].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season2Episodes = seasonsArray[1].Episodes.ToArray();

            season2Episodes[0].SeasonNumber.Should().Be(2);
            season2Episodes[0].Number.Should().Be(1);
            season2Episodes[0].Title.Should().Be("The Man Who Saved Central City");
            season2Episodes[0].Ids.Should().NotBeNull();
            season2Episodes[0].Ids.Trakt.Should().Be(1866102U);
            season2Episodes[0].Ids.Tvdb.Should().Be(5260562U);
            season2Episodes[0].Ids.Imdb.Should().BeNull();
            season2Episodes[0].Ids.Tmdb.Should().Be(1063859U);
            season2Episodes[0].Ids.TvRage.Should().Be(0U);
            season2Episodes[0].Images.Should().NotBeNull();
            season2Episodes[0].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/original/c00e524f80.jpg");
            season2Episodes[0].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/medium/c00e524f80.jpg");
            season2Episodes[0].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/thumb/c00e524f80.jpg");

            season2Episodes[1].SeasonNumber.Should().Be(2);
            season2Episodes[1].Number.Should().Be(2);
            season2Episodes[1].Title.Should().Be("Flash of Two Worlds");
            season2Episodes[1].Ids.Should().NotBeNull();
            season2Episodes[1].Ids.Trakt.Should().Be(1933746U);
            season2Episodes[1].Ids.Tvdb.Should().Be(5280328U);
            season2Episodes[1].Ids.Imdb.Should().BeNull();
            season2Episodes[1].Ids.Tmdb.Should().Be(1063860U);
            season2Episodes[1].Ids.TvRage.Should().Be(0U);
            season1Episodes[1].Images.Should().NotBeNull();
            season2Episodes[1].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/original/9fbe3faf84.jpg");
            season2Episodes[1].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/medium/9fbe3faf84.jpg");
            season2Episodes[1].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/thumb/9fbe3faf84.jpg");
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Rating.Should().Be(8.57053f);
            seasonsArray[0].Votes.Should().Be(794);
            seasonsArray[0].TotalEpisodesCount.Should().Be(23);
            seasonsArray[0].AiredEpisodesCount.Should().Be(23);
            seasonsArray[0].Overview.Should().BeNullOrEmpty();
            seasonsArray[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());

            seasonsArray[0].Episodes.Should().BeNull();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Rating.Should().Be(8.61539f);
            seasonsArray[1].Votes.Should().Be(325);
            seasonsArray[1].TotalEpisodesCount.Should().Be(23);
            seasonsArray[1].AiredEpisodesCount.Should().Be(17);
            seasonsArray[1].Overview.Should().Be("Following the defeat of Barry Allen's arch-nemesis Eobard Thawne (aka Reverse Flash), Team Flash quickly turned their attention to the singularity swirling high above Central City, which fans last saw consuming everything in its path. Armed with the heart of a hero and the ability to move at super speeds, Barry charged into the eye of the singularity, but will he actually be able to save his city from impending doom?");
            seasonsArray[1].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());

            seasonsArray[1].Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonFullWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFullWithEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Rating.Should().Be(8.57053f);
            seasonsArray[0].Votes.Should().Be(794);
            seasonsArray[0].TotalEpisodesCount.Should().Be(23);
            seasonsArray[0].AiredEpisodesCount.Should().Be(23);
            seasonsArray[0].Overview.Should().BeNullOrEmpty();
            seasonsArray[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());

            seasonsArray[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season1Episodes = seasonsArray[0].Episodes.ToArray();

            season1Episodes[0].SeasonNumber.Should().Be(1);
            season1Episodes[0].Number.Should().Be(1);
            season1Episodes[0].Title.Should().Be("City of Heroes");
            season1Episodes[0].Ids.Should().NotBeNull();
            season1Episodes[0].Ids.Trakt.Should().Be(962074U);
            season1Episodes[0].Ids.Tvdb.Should().Be(4812524U);
            season1Episodes[0].Ids.Imdb.Should().Be("tt3187092");
            season1Episodes[0].Ids.Tmdb.Should().Be(977122U);
            season1Episodes[0].Ids.TvRage.Should().Be(1065564472U);
            season1Episodes[0].NumberAbsolute.Should().NotHaveValue();
            season1Episodes[0].Overview.Should().Be("CSI investigator Barry Allen awakens from a coma, nine months after he was hit by lightning, and discovers he has superhuman speed.");
            season1Episodes[0].Rating.Should().Be(8.15951f);
            season1Episodes[0].Votes.Should().Be(3517);
            season1Episodes[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            season1Episodes[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T19:45:15Z").ToUniversalTime());
            season1Episodes[0].AvailableTranslationLanguageCodes.Should().BeEmpty();

            season1Episodes[1].SeasonNumber.Should().Be(1);
            season1Episodes[1].Number.Should().Be(2);
            season1Episodes[1].Title.Should().Be("Fastest Man Alive");
            season1Episodes[1].Ids.Should().NotBeNull();
            season1Episodes[1].Ids.Trakt.Should().Be(962075U);
            season1Episodes[1].Ids.Tvdb.Should().Be(4929322U);
            season1Episodes[1].Ids.Imdb.Should().Be("tt3819518");
            season1Episodes[1].Ids.Tmdb.Should().Be(1005650U);
            season1Episodes[1].Ids.TvRage.Should().Be(1065603573U);
            season1Episodes[1].NumberAbsolute.Should().NotHaveValue();
            season1Episodes[1].Overview.Should().Be("Barry escorts Iris to a university gathering honoring scientist Simon Stagg. When six gunmen storm the event, Barry changes into The Flash and tries to stop them. While he does save a man's life, he passes out before he can capture the robbers, which frustrates him. As Dr. Wells, Caitlin and Cisco scramble to find out what's wrong with Barry, Joe comes down hard on Barry for taking the law into his own hands and risking his life. Barry realizes that it wasn't six gunmen but a metahuman named Danton Black, who can make multiples of himself. Meanwhile, Iris becomes even more intrigued by the “red streak.”");
            season1Episodes[1].Rating.Should().Be(7.99713f);
            season1Episodes[1].Votes.Should().Be(2788);
            season1Episodes[1].FirstAired.Should().Be(DateTime.Parse("2014-10-15T00:00:00Z").ToUniversalTime());
            season1Episodes[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T16:16:05Z").ToUniversalTime());
            season1Episodes[1].AvailableTranslationLanguageCodes.Should().BeEmpty();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Rating.Should().Be(8.61539f);
            seasonsArray[1].Votes.Should().Be(325);
            seasonsArray[1].TotalEpisodesCount.Should().Be(23);
            seasonsArray[1].AiredEpisodesCount.Should().Be(17);
            seasonsArray[1].Overview.Should().Be("Following the defeat of Barry Allen's arch-nemesis Eobard Thawne (aka Reverse Flash), Team Flash quickly turned their attention to the singularity swirling high above Central City, which fans last saw consuming everything in its path. Armed with the heart of a hero and the ability to move at super speeds, Barry charged into the eye of the singularity, but will he actually be able to save his city from impending doom?");
            seasonsArray[1].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());

            seasonsArray[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season2Episodes = seasonsArray[1].Episodes.ToArray();

            season2Episodes[0].SeasonNumber.Should().Be(2);
            season2Episodes[0].Number.Should().Be(1);
            season2Episodes[0].Title.Should().Be("The Man Who Saved Central City");
            season2Episodes[0].Ids.Should().NotBeNull();
            season2Episodes[0].Ids.Trakt.Should().Be(1866102U);
            season2Episodes[0].Ids.Tvdb.Should().Be(5260562U);
            season2Episodes[0].Ids.Imdb.Should().BeNull();
            season2Episodes[0].Ids.Tmdb.Should().Be(1063859U);
            season2Episodes[0].Ids.TvRage.Should().Be(0U);
            season2Episodes[0].NumberAbsolute.Should().NotHaveValue();
            season2Episodes[0].Overview.Should().Be("Picking up months after the Singularity attacked Central City, Barry is still struggling to forgive himself for Eddie’s death. Concerned about putting his friends in danger, Barry has pushed everyone away and has chosen to protect the city on his own. When a meta-human named Atom Smasher attacks the city, Iris tells Barry that he needs to let his friends help him protect the citizens of Central City. Meanwhile, Cisco helps Joe with his Meta Task Force.");
            season2Episodes[0].Rating.Should().Be(7.8933f);
            season2Episodes[0].Votes.Should().Be(3074);
            season2Episodes[0].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());
            season2Episodes[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T19:19:28Z").ToUniversalTime());
            season2Episodes[0].AvailableTranslationLanguageCodes.Should().BeEmpty();

            season2Episodes[1].SeasonNumber.Should().Be(2);
            season2Episodes[1].Number.Should().Be(2);
            season2Episodes[1].Title.Should().Be("Flash of Two Worlds");
            season2Episodes[1].Ids.Should().NotBeNull();
            season2Episodes[1].Ids.Trakt.Should().Be(1933746U);
            season2Episodes[1].Ids.Tvdb.Should().Be(5280328U);
            season2Episodes[1].Ids.Imdb.Should().BeNull();
            season2Episodes[1].Ids.Tmdb.Should().Be(1063860U);
            season2Episodes[1].Ids.TvRage.Should().Be(0U);
            season2Episodes[1].NumberAbsolute.Should().NotHaveValue();
            season2Episodes[1].Overview.Should().Be("Jay Garrick, a mysterious man from Earth-2, appears at S.T.A.R. Labs with a dire warning about an evil speedster named Zoom, who is set on destroying The Flash. Barry and the team must decide if they can trust this stranger even as they face yet another powerful meta-human. Meanwhile, Joe must deal with a determined officer named Patty Spivot who wants to join his meta-human task force.");
            season2Episodes[1].Rating.Should().Be(7.89878f);
            season2Episodes[1].Votes.Should().Be(2628);
            season2Episodes[1].FirstAired.Should().Be(DateTime.Parse("2015-10-14T00:00:00Z").ToUniversalTime());
            season2Episodes[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T20:03:26Z").ToUniversalTime());
            season2Episodes[1].AvailableTranslationLanguageCodes.Should().BeEmpty();
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Rating.Should().Be(8.57053f);
            seasonsArray[0].Votes.Should().Be(794);
            seasonsArray[0].TotalEpisodesCount.Should().Be(23);
            seasonsArray[0].AiredEpisodesCount.Should().Be(23);
            seasonsArray[0].Overview.Should().BeNullOrEmpty();
            seasonsArray[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            seasonsArray[0].Images.Should().NotBeNull();
            seasonsArray[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            seasonsArray[0].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[0].Episodes.Should().BeNull();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Rating.Should().Be(8.61539f);
            seasonsArray[1].Votes.Should().Be(325);
            seasonsArray[1].TotalEpisodesCount.Should().Be(23);
            seasonsArray[1].AiredEpisodesCount.Should().Be(17);
            seasonsArray[1].Overview.Should().Be("Following the defeat of Barry Allen's arch-nemesis Eobard Thawne (aka Reverse Flash), Team Flash quickly turned their attention to the singularity swirling high above Central City, which fans last saw consuming everything in its path. Armed with the heart of a hero and the ability to move at super speeds, Barry charged into the eye of the singularity, but will he actually be able to save his city from impending doom?");
            seasonsArray[1].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());
            seasonsArray[1].Images.Should().NotBeNull();
            seasonsArray[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/original/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/medium/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/thumb/26132fb16c.jpg");
            seasonsArray[1].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[1].Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSeasonsAllReadFromJsonFullAndImagesWithEpisodes()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImagesWithEpisodes.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasons = JsonConvert.DeserializeObject<IEnumerable<TraktSeason>>(jsonFile);

            seasons.Should().NotBeNull();
            seasons.Should().HaveCount(2);

            var seasonsArray = seasons.ToArray();

            // season 1
            seasonsArray[0].Number.Should().Be(1);
            seasonsArray[0].Ids.Should().NotBeNull();
            seasonsArray[0].Ids.Trakt.Should().Be(61430U);
            seasonsArray[0].Ids.Tvdb.Should().Be(279121U);
            seasonsArray[0].Ids.Tmdb.Should().Be(60523U);
            seasonsArray[0].Ids.TvRage.Should().Be(36939U);
            seasonsArray[0].Rating.Should().Be(8.57053f);
            seasonsArray[0].Votes.Should().Be(794);
            seasonsArray[0].TotalEpisodesCount.Should().Be(23);
            seasonsArray[0].AiredEpisodesCount.Should().Be(23);
            seasonsArray[0].Overview.Should().BeNullOrEmpty();
            seasonsArray[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            seasonsArray[0].Images.Should().NotBeNull();
            seasonsArray[0].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/original/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/medium/ea214a63c3.jpg");
            seasonsArray[0].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/061/430/posters/thumb/ea214a63c3.jpg");
            seasonsArray[0].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season1Episodes = seasonsArray[0].Episodes.ToArray();

            season1Episodes[0].SeasonNumber.Should().Be(1);
            season1Episodes[0].Number.Should().Be(1);
            season1Episodes[0].Title.Should().Be("City of Heroes");
            season1Episodes[0].Ids.Should().NotBeNull();
            season1Episodes[0].Ids.Trakt.Should().Be(962074U);
            season1Episodes[0].Ids.Tvdb.Should().Be(4812524U);
            season1Episodes[0].Ids.Imdb.Should().Be("tt3187092");
            season1Episodes[0].Ids.Tmdb.Should().Be(977122U);
            season1Episodes[0].Ids.TvRage.Should().Be(1065564472U);
            season1Episodes[0].Images.Should().NotBeNull();
            season1Episodes[0].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/original/b992ef650c.jpg");
            season1Episodes[0].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/medium/b992ef650c.jpg");
            season1Episodes[0].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/962/074/screenshots/thumb/b992ef650c.jpg");
            season1Episodes[0].NumberAbsolute.Should().NotHaveValue();
            season1Episodes[0].Overview.Should().Be("CSI investigator Barry Allen awakens from a coma, nine months after he was hit by lightning, and discovers he has superhuman speed.");
            season1Episodes[0].Rating.Should().Be(8.15951f);
            season1Episodes[0].Votes.Should().Be(3517);
            season1Episodes[0].FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00Z").ToUniversalTime());
            season1Episodes[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T19:45:15Z").ToUniversalTime());
            season1Episodes[0].AvailableTranslationLanguageCodes.Should().BeEmpty();

            season1Episodes[1].SeasonNumber.Should().Be(1);
            season1Episodes[1].Number.Should().Be(2);
            season1Episodes[1].Title.Should().Be("Fastest Man Alive");
            season1Episodes[1].Ids.Should().NotBeNull();
            season1Episodes[1].Ids.Trakt.Should().Be(962075U);
            season1Episodes[1].Ids.Tvdb.Should().Be(4929322U);
            season1Episodes[1].Ids.Imdb.Should().Be("tt3819518");
            season1Episodes[1].Ids.Tmdb.Should().Be(1005650U);
            season1Episodes[1].Ids.TvRage.Should().Be(1065603573U);
            season1Episodes[1].Images.Should().NotBeNull();
            season1Episodes[1].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/original/a7e0815b17.jpg");
            season1Episodes[1].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/medium/a7e0815b17.jpg");
            season1Episodes[1].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/962/075/screenshots/thumb/a7e0815b17.jpg");
            season1Episodes[1].NumberAbsolute.Should().NotHaveValue();
            season1Episodes[1].Overview.Should().Be("Barry escorts Iris to a university gathering honoring scientist Simon Stagg. When six gunmen storm the event, Barry changes into The Flash and tries to stop them. While he does save a man's life, he passes out before he can capture the robbers, which frustrates him. As Dr. Wells, Caitlin and Cisco scramble to find out what's wrong with Barry, Joe comes down hard on Barry for taking the law into his own hands and risking his life. Barry realizes that it wasn't six gunmen but a metahuman named Danton Black, who can make multiples of himself. Meanwhile, Iris becomes even more intrigued by the “red streak.”");
            season1Episodes[1].Rating.Should().Be(7.99713f);
            season1Episodes[1].Votes.Should().Be(2788);
            season1Episodes[1].FirstAired.Should().Be(DateTime.Parse("2014-10-15T00:00:00Z").ToUniversalTime());
            season1Episodes[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T16:16:05Z").ToUniversalTime());
            season1Episodes[1].AvailableTranslationLanguageCodes.Should().BeEmpty();

            // season 2
            seasonsArray[1].Number.Should().Be(2);
            seasonsArray[1].Ids.Should().NotBeNull();
            seasonsArray[1].Ids.Trakt.Should().Be(110984U);
            seasonsArray[1].Ids.Tvdb.Should().BeNull();
            seasonsArray[1].Ids.Tmdb.Should().Be(66922U);
            seasonsArray[1].Ids.TvRage.Should().BeNull();
            seasonsArray[1].Rating.Should().Be(8.61539f);
            seasonsArray[1].Votes.Should().Be(325);
            seasonsArray[1].TotalEpisodesCount.Should().Be(23);
            seasonsArray[1].AiredEpisodesCount.Should().Be(17);
            seasonsArray[1].Overview.Should().Be("Following the defeat of Barry Allen's arch-nemesis Eobard Thawne (aka Reverse Flash), Team Flash quickly turned their attention to the singularity swirling high above Central City, which fans last saw consuming everything in its path. Armed with the heart of a hero and the ability to move at super speeds, Barry charged into the eye of the singularity, but will he actually be able to save his city from impending doom?");
            seasonsArray[1].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());
            seasonsArray[1].Images.Should().NotBeNull();
            seasonsArray[1].Images.Poster.Full.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/original/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/medium/26132fb16c.jpg");
            seasonsArray[1].Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/seasons/000/110/984/posters/thumb/26132fb16c.jpg");
            seasonsArray[1].Images.Thumb.Full.Should().BeNullOrEmpty();

            seasonsArray[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var season2Episodes = seasonsArray[1].Episodes.ToArray();

            season2Episodes[0].SeasonNumber.Should().Be(2);
            season2Episodes[0].Number.Should().Be(1);
            season2Episodes[0].Title.Should().Be("The Man Who Saved Central City");
            season2Episodes[0].Ids.Should().NotBeNull();
            season2Episodes[0].Ids.Trakt.Should().Be(1866102U);
            season2Episodes[0].Ids.Tvdb.Should().Be(5260562U);
            season2Episodes[0].Ids.Imdb.Should().BeNull();
            season2Episodes[0].Ids.Tmdb.Should().Be(1063859U);
            season2Episodes[0].Ids.TvRage.Should().Be(0U);
            season2Episodes[0].Images.Should().NotBeNull();
            season2Episodes[0].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/original/c00e524f80.jpg");
            season2Episodes[0].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/medium/c00e524f80.jpg");
            season2Episodes[0].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/001/866/102/screenshots/thumb/c00e524f80.jpg");
            season2Episodes[0].NumberAbsolute.Should().NotHaveValue();
            season2Episodes[0].Overview.Should().Be("Picking up months after the Singularity attacked Central City, Barry is still struggling to forgive himself for Eddie’s death. Concerned about putting his friends in danger, Barry has pushed everyone away and has chosen to protect the city on his own. When a meta-human named Atom Smasher attacks the city, Iris tells Barry that he needs to let his friends help him protect the citizens of Central City. Meanwhile, Cisco helps Joe with his Meta Task Force.");
            season2Episodes[0].Rating.Should().Be(7.8933f);
            season2Episodes[0].Votes.Should().Be(3074);
            season2Episodes[0].FirstAired.Should().Be(DateTime.Parse("2015-10-07T00:00:00Z").ToUniversalTime());
            season2Episodes[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T19:19:28Z").ToUniversalTime());
            season2Episodes[0].AvailableTranslationLanguageCodes.Should().BeEmpty();

            season2Episodes[1].SeasonNumber.Should().Be(2);
            season2Episodes[1].Number.Should().Be(2);
            season2Episodes[1].Title.Should().Be("Flash of Two Worlds");
            season2Episodes[1].Ids.Should().NotBeNull();
            season2Episodes[1].Ids.Trakt.Should().Be(1933746U);
            season2Episodes[1].Ids.Tvdb.Should().Be(5280328U);
            season2Episodes[1].Ids.Imdb.Should().BeNull();
            season2Episodes[1].Ids.Tmdb.Should().Be(1063860U);
            season2Episodes[1].Ids.TvRage.Should().Be(0U);
            season1Episodes[1].Images.Should().NotBeNull();
            season2Episodes[1].Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/original/9fbe3faf84.jpg");
            season2Episodes[1].Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/medium/9fbe3faf84.jpg");
            season2Episodes[1].Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/001/933/746/screenshots/thumb/9fbe3faf84.jpg");
            season2Episodes[1].NumberAbsolute.Should().NotHaveValue();
            season2Episodes[1].Overview.Should().Be("Jay Garrick, a mysterious man from Earth-2, appears at S.T.A.R. Labs with a dire warning about an evil speedster named Zoom, who is set on destroying The Flash. Barry and the team must decide if they can trust this stranger even as they face yet another powerful meta-human. Meanwhile, Joe must deal with a determined officer named Patty Spivot who wants to join his meta-human task force.");
            season2Episodes[1].Rating.Should().Be(7.89878f);
            season2Episodes[1].Votes.Should().Be(2628);
            season2Episodes[1].FirstAired.Should().Be(DateTime.Parse("2015-10-14T00:00:00Z").ToUniversalTime());
            season2Episodes[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T20:03:26Z").ToUniversalTime());
            season2Episodes[1].AvailableTranslationLanguageCodes.Should().BeEmpty();
        }
    }
}
