namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMoviePeopleTests
    {
        [TestMethod]
        public void TestTraktMoviePeopleReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var people = JsonConvert.DeserializeObject<TraktMoviePeople>(jsonFile);

            people.Should().NotBeNull();

            people.Cast.Should().NotBeNull().And.HaveCount(3);

            var cast = people.Cast.ToArray();

            cast[0].Character.Should().Be("Rey");
            cast[0].Person.Should().NotBeNull();

            cast[1].Character.Should().Be("Finn");
            cast[1].Person.Should().NotBeNull();

            cast[2].Character.Should().Be("Kylo Ren");
            cast[2].Person.Should().NotBeNull();

            people.Crew.Should().NotBeNull();

            people.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            people.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            people.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            people.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Editing.Should().NotBeNull().And.HaveCount(2);

            // Writing
            var writingCrew = people.Crew.Writing.ToArray();

            writingCrew[0].Job.Should().Be("Characters");
            writingCrew[0].Person.Should().NotBeNull();

            writingCrew[1].Job.Should().Be("Writer");
            writingCrew[1].Person.Should().NotBeNull();

            // Sound
            var soundCrew = people.Crew.Sound.ToArray();

            soundCrew[0].Job.Should().Be("Original Music Composer");
            soundCrew[0].Person.Should().NotBeNull();

            soundCrew[1].Job.Should().Be("Music Editor");
            soundCrew[1].Person.Should().NotBeNull();

            // Art
            var artCrew = people.Crew.Art.ToArray();

            artCrew[0].Job.Should().Be("Production Design");
            artCrew[0].Person.Should().NotBeNull();

            artCrew[1].Job.Should().Be("Art Direction");
            artCrew[1].Person.Should().NotBeNull();

            // CostumeAndMakeup
            var makeupCrew = people.Crew.CostumeAndMakeup.ToArray();

            makeupCrew[0].Job.Should().Be("Costume Design");
            makeupCrew[0].Person.Should().NotBeNull();

            makeupCrew[1].Job.Should().Be("Makeup Department Head");
            makeupCrew[1].Person.Should().NotBeNull();

            // Production
            var productionCrew = people.Crew.Production.ToArray();

            productionCrew[0].Job.Should().Be("Casting");
            productionCrew[0].Person.Should().NotBeNull();

            productionCrew[1].Job.Should().Be("Associate Producer");
            productionCrew[1].Person.Should().NotBeNull();

            // Crew
            var crewCrew = people.Crew.Crew.ToArray();

            crewCrew[0].Job.Should().Be("Stunt Coordinator");
            crewCrew[0].Person.Should().NotBeNull();

            crewCrew[1].Job.Should().Be("Property Master");
            crewCrew[1].Person.Should().NotBeNull();

            // Camera
            var cameraCrew = people.Crew.Camera.ToArray();

            cameraCrew[0].Job.Should().Be("Director of Photography");
            cameraCrew[0].Person.Should().NotBeNull();

            cameraCrew[1].Job.Should().Be("First Assistant Camera");
            cameraCrew[1].Person.Should().NotBeNull();

            // Editing
            var editingCrew = people.Crew.Editing.ToArray();

            editingCrew[0].Job.Should().Be("Editor");
            editingCrew[0].Person.Should().NotBeNull();

            editingCrew[1].Job.Should().Be("Editor");
            editingCrew[1].Person.Should().NotBeNull();

            // VisualEffects
            var vfxCrew = people.Crew.VisualEffects.ToArray();

            vfxCrew[0].Job.Should().Be("Visual Effects Supervisor");
            vfxCrew[0].Person.Should().NotBeNull();

            vfxCrew[1].Job.Should().Be("Special Effects Supervisor");
            vfxCrew[1].Person.Should().NotBeNull();

            // Directing
            var directingCrew = people.Crew.Directing.ToArray();

            directingCrew[0].Job.Should().Be("Director");
            directingCrew[0].Person.Should().NotBeNull();

            // Lighting
            var lightingCrew = people.Crew.Lighting.ToArray();

            lightingCrew[0].Job.Should().Be("Gaffer");
            lightingCrew[0].Person.Should().NotBeNull();

            lightingCrew[1].Job.Should().Be("Gaffer");
            lightingCrew[1].Person.Should().NotBeNull();
        }
    }
}
