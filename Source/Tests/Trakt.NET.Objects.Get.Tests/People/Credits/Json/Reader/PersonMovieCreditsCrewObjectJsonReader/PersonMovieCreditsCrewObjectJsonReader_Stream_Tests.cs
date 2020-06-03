namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCrewObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().BeNull();

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().BeNull();

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().BeNull();

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().BeNull();

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().BeNull();

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().BeNull();

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().BeNull();

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().BeNull();

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().BeNull();

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().BeNull();

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().BeNull();

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().BeNull();

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().BeNull();

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().BeNull();

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().BeNull();

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().BeNull();

                movieCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = movieCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Movie.Should().NotBeNull();
                editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                editingCrew[0].Movie.Year.Should().Be(2015);
                editingCrew[0].Movie.Ids.Should().NotBeNull();
                editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Movie.Should().NotBeNull();
                editingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                editingCrew[1].Movie.Year.Should().Be(2010);
                editingCrew[1].Movie.Ids.Should().NotBeNull();
                editingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                editingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                editingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                editingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = movieCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Movie.Should().NotBeNull();
                productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                productionCrew[0].Movie.Year.Should().Be(2015);
                productionCrew[0].Movie.Ids.Should().NotBeNull();
                productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Movie.Should().NotBeNull();
                productionCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                productionCrew[1].Movie.Year.Should().Be(2010);
                productionCrew[1].Movie.Ids.Should().NotBeNull();
                productionCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                productionCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                productionCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                productionCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = movieCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Movie.Should().NotBeNull();
                artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                artCrew[0].Movie.Year.Should().Be(2015);
                artCrew[0].Movie.Ids.Should().NotBeNull();
                artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Movie.Should().NotBeNull();
                artCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                artCrew[1].Movie.Year.Should().Be(2010);
                artCrew[1].Movie.Ids.Should().NotBeNull();
                artCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                artCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                artCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                artCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = movieCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Movie.Should().NotBeNull();
                crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                crew[0].Movie.Year.Should().Be(2015);
                crew[0].Movie.Ids.Should().NotBeNull();
                crew[0].Movie.Ids.Trakt.Should().Be(94024U);
                crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                crew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Movie.Should().NotBeNull();
                crew[1].Movie.Title.Should().Be("TRON: Legacy");
                crew[1].Movie.Year.Should().Be(2010);
                crew[1].Movie.Ids.Should().NotBeNull();
                crew[1].Movie.Ids.Trakt.Should().Be(12601U);
                crew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                crew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                crew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = movieCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
                costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                costumeAndMakeupCrew[1].Movie.Year.Should().Be(2010);
                costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = movieCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Movie.Should().NotBeNull();
                directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                directingCrew[0].Movie.Year.Should().Be(2015);
                directingCrew[0].Movie.Ids.Should().NotBeNull();
                directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Movie.Should().NotBeNull();
                directingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                directingCrew[1].Movie.Year.Should().Be(2010);
                directingCrew[1].Movie.Ids.Should().NotBeNull();
                directingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                directingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                directingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                directingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = movieCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Movie.Should().NotBeNull();
                writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                writingCrew[0].Movie.Year.Should().Be(2015);
                writingCrew[0].Movie.Ids.Should().NotBeNull();
                writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Movie.Should().NotBeNull();
                writingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                writingCrew[1].Movie.Year.Should().Be(2010);
                writingCrew[1].Movie.Ids.Should().NotBeNull();
                writingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                writingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                writingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                writingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = movieCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Movie.Should().NotBeNull();
                soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                soundCrew[0].Movie.Year.Should().Be(2015);
                soundCrew[0].Movie.Ids.Should().NotBeNull();
                soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Movie.Should().NotBeNull();
                soundCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                soundCrew[1].Movie.Year.Should().Be(2010);
                soundCrew[1].Movie.Ids.Should().NotBeNull();
                soundCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                soundCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                soundCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                soundCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = movieCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Movie.Should().NotBeNull();
                cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                cameraCrew[0].Movie.Year.Should().Be(2015);
                cameraCrew[0].Movie.Ids.Should().NotBeNull();
                cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Movie.Should().NotBeNull();
                cameraCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                cameraCrew[1].Movie.Year.Should().Be(2010);
                cameraCrew[1].Movie.Ids.Should().NotBeNull();
                cameraCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                cameraCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                cameraCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = movieCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Movie.Should().NotBeNull();
                lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                lightingCrew[0].Movie.Year.Should().Be(2015);
                lightingCrew[0].Movie.Ids.Should().NotBeNull();
                lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Movie.Should().NotBeNull();
                lightingCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                lightingCrew[1].Movie.Year.Should().Be(2010);
                lightingCrew[1].Movie.Ids.Should().NotBeNull();
                lightingCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                lightingCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                lightingCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = movieCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Movie.Should().NotBeNull();
                vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                vfxCrew[0].Movie.Year.Should().Be(2015);
                vfxCrew[0].Movie.Ids.Should().NotBeNull();
                vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
                vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Movie.Should().NotBeNull();
                vfxCrew[1].Movie.Title.Should().Be("TRON: Legacy");
                vfxCrew[1].Movie.Year.Should().Be(2010);
                vfxCrew[1].Movie.Ids.Should().NotBeNull();
                vfxCrew[1].Movie.Ids.Trakt.Should().Be(12601U);
                vfxCrew[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                vfxCrew[1].Movie.Ids.Tmdb.Should().Be(20526U);

                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCrew.Should().NotBeNull();

                movieCreditsCrew.Production.Should().BeNull();
                movieCreditsCrew.Art.Should().BeNull();
                movieCreditsCrew.Crew.Should().BeNull();
                movieCreditsCrew.CostumeAndMakeup.Should().BeNull();
                movieCreditsCrew.Directing.Should().BeNull();
                movieCreditsCrew.Writing.Should().BeNull();
                movieCreditsCrew.Sound.Should().BeNull();
                movieCreditsCrew.Camera.Should().BeNull();
                movieCreditsCrew.Lighting.Should().BeNull();
                movieCreditsCrew.VisualEffects.Should().BeNull();
                movieCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            var movieCreditsCrew = await jsonReader.ReadObjectAsync(default(Stream));
            movieCreditsCrew.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var movieCreditsCrew = await jsonReader.ReadObjectAsync(stream);
                movieCreditsCrew.Should().BeNull();
            }
        }
    }
}
