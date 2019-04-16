﻿namespace TraktNet.Objects.Tests.Get.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().BeNull();

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().BeNull();

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().BeNull();

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().BeNull();

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().BeNull();

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().BeNull();

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().BeNull();

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().BeNull();

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().BeNull();

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_15()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_16()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_17()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_18()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_19()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_20()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_21()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_22()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().BeNull();

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().BeNull();

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().BeNull();

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().BeNull();

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().BeNull();

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().BeNull();

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().BeNull();

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().BeNull();

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().BeNull();

                showCreditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = showCreditsCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Show.Should().NotBeNull();
                editingCrew[0].Show.Title.Should().Be("Game of Thrones");
                editingCrew[0].Show.Year.Should().Be(2011);
                editingCrew[0].Show.Ids.Should().NotBeNull();
                editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Show.Should().NotBeNull();
                editingCrew[1].Show.Title.Should().Be("The Flash");
                editingCrew[1].Show.Year.Should().Be(2014);
                editingCrew[1].Show.Ids.Should().NotBeNull();
                editingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                editingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                editingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                editingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                editingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                editingCrew[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = showCreditsCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Show.Should().NotBeNull();
                productionCrew[0].Show.Title.Should().Be("Game of Thrones");
                productionCrew[0].Show.Year.Should().Be(2011);
                productionCrew[0].Show.Ids.Should().NotBeNull();
                productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Show.Should().NotBeNull();
                productionCrew[1].Show.Title.Should().Be("The Flash");
                productionCrew[1].Show.Year.Should().Be(2014);
                productionCrew[1].Show.Ids.Should().NotBeNull();
                productionCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                productionCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                productionCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                productionCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                productionCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                productionCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = showCreditsCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Show.Should().NotBeNull();
                artCrew[0].Show.Title.Should().Be("Game of Thrones");
                artCrew[0].Show.Year.Should().Be(2011);
                artCrew[0].Show.Ids.Should().NotBeNull();
                artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                artCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Show.Should().NotBeNull();
                artCrew[1].Show.Title.Should().Be("The Flash");
                artCrew[1].Show.Year.Should().Be(2014);
                artCrew[1].Show.Ids.Should().NotBeNull();
                artCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                artCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                artCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                artCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                artCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                artCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = showCreditsCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Show.Should().NotBeNull();
                crew[0].Show.Title.Should().Be("Game of Thrones");
                crew[0].Show.Year.Should().Be(2011);
                crew[0].Show.Ids.Should().NotBeNull();
                crew[0].Show.Ids.Trakt.Should().Be(1390U);
                crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                crew[0].Show.Ids.Tvdb.Should().Be(121361U);
                crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                crew[0].Show.Ids.Tmdb.Should().Be(1399U);
                crew[0].Show.Ids.TvRage.Should().Be(24493U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Show.Should().NotBeNull();
                crew[1].Show.Title.Should().Be("The Flash");
                crew[1].Show.Year.Should().Be(2014);
                crew[1].Show.Ids.Should().NotBeNull();
                crew[1].Show.Ids.Trakt.Should().Be(60300U);
                crew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                crew[1].Show.Ids.Tvdb.Should().Be(279121U);
                crew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                crew[1].Show.Ids.Tmdb.Should().Be(60735U);
                crew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = showCreditsCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Show.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
                costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
                costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Show.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Title.Should().Be("The Flash");
                costumeAndMakeupCrew[1].Show.Year.Should().Be(2014);
                costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = showCreditsCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Show.Should().NotBeNull();
                directingCrew[0].Show.Title.Should().Be("Game of Thrones");
                directingCrew[0].Show.Year.Should().Be(2011);
                directingCrew[0].Show.Ids.Should().NotBeNull();
                directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Show.Should().NotBeNull();
                directingCrew[1].Show.Title.Should().Be("The Flash");
                directingCrew[1].Show.Year.Should().Be(2014);
                directingCrew[1].Show.Ids.Should().NotBeNull();
                directingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                directingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                directingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                directingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                directingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                directingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = showCreditsCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Show.Should().NotBeNull();
                writingCrew[0].Show.Title.Should().Be("Game of Thrones");
                writingCrew[0].Show.Year.Should().Be(2011);
                writingCrew[0].Show.Ids.Should().NotBeNull();
                writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Show.Should().NotBeNull();
                writingCrew[1].Show.Title.Should().Be("The Flash");
                writingCrew[1].Show.Year.Should().Be(2014);
                writingCrew[1].Show.Ids.Should().NotBeNull();
                writingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                writingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                writingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                writingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                writingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                writingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = showCreditsCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Show.Should().NotBeNull();
                soundCrew[0].Show.Title.Should().Be("Game of Thrones");
                soundCrew[0].Show.Year.Should().Be(2011);
                soundCrew[0].Show.Ids.Should().NotBeNull();
                soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Show.Should().NotBeNull();
                soundCrew[1].Show.Title.Should().Be("The Flash");
                soundCrew[1].Show.Year.Should().Be(2014);
                soundCrew[1].Show.Ids.Should().NotBeNull();
                soundCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                soundCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                soundCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                soundCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                soundCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                soundCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = showCreditsCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Show.Should().NotBeNull();
                cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
                cameraCrew[0].Show.Year.Should().Be(2011);
                cameraCrew[0].Show.Ids.Should().NotBeNull();
                cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Show.Should().NotBeNull();
                cameraCrew[1].Show.Title.Should().Be("The Flash");
                cameraCrew[1].Show.Year.Should().Be(2014);
                cameraCrew[1].Show.Ids.Should().NotBeNull();
                cameraCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                cameraCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                cameraCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                cameraCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                cameraCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                cameraCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = showCreditsCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Show.Should().NotBeNull();
                lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
                lightingCrew[0].Show.Year.Should().Be(2011);
                lightingCrew[0].Show.Ids.Should().NotBeNull();
                lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Show.Should().NotBeNull();
                lightingCrew[1].Show.Title.Should().Be("The Flash");
                lightingCrew[1].Show.Year.Should().Be(2014);
                lightingCrew[1].Show.Ids.Should().NotBeNull();
                lightingCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                lightingCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                lightingCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                lightingCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                lightingCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                lightingCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = showCreditsCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Show.Should().NotBeNull();
                vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
                vfxCrew[0].Show.Year.Should().Be(2011);
                vfxCrew[0].Show.Ids.Should().NotBeNull();
                vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
                vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
                vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
                vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
                vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Show.Should().NotBeNull();
                vfxCrew[1].Show.Title.Should().Be("The Flash");
                vfxCrew[1].Show.Year.Should().Be(2014);
                vfxCrew[1].Show.Ids.Should().NotBeNull();
                vfxCrew[1].Show.Ids.Trakt.Should().Be(60300U);
                vfxCrew[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                vfxCrew[1].Show.Ids.Tvdb.Should().Be(279121U);
                vfxCrew[1].Show.Ids.Imdb.Should().Be("tt3107288");
                vfxCrew[1].Show.Ids.Tmdb.Should().Be(60735U);
                vfxCrew[1].Show.Ids.TvRage.Should().Be(36939U);

                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCrew.Should().NotBeNull();

                showCreditsCrew.Production.Should().BeNull();
                showCreditsCrew.Art.Should().BeNull();
                showCreditsCrew.Crew.Should().BeNull();
                showCreditsCrew.CostumeAndMakeup.Should().BeNull();
                showCreditsCrew.Directing.Should().BeNull();
                showCreditsCrew.Writing.Should().BeNull();
                showCreditsCrew.Sound.Should().BeNull();
                showCreditsCrew.Camera.Should().BeNull();
                showCreditsCrew.Lighting.Should().BeNull();
                showCreditsCrew.VisualEffects.Should().BeNull();
                showCreditsCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            var showCreditsCrew = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            showCreditsCrew.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonShowCreditsCrewObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrew = await traktJsonReader.ReadObjectAsync(jsonReader);
                showCreditsCrew.Should().BeNull();
            }
        }
    }
}
