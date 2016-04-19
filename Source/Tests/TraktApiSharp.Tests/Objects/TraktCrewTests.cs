namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCrewTests
    {
        [TestMethod]
        public void TestTraktCrewDefaultConstructor()
        {
            var crew = new TraktCrew();

            crew.Production.Should().BeNull();
            crew.Art.Should().BeNull();
            crew.Crew.Should().BeNull();
            crew.CostumeAndMakeup.Should().BeNull();
            crew.Directing.Should().BeNull();
            crew.Writing.Should().BeNull();
            crew.Sound.Should().BeNull();
            crew.Camera.Should().BeNull();
            crew.Lighting.Should().BeNull();
            crew.VisualEffects.Should().BeNull();
            crew.Editing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCrewReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Basic\Crew.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var crew = JsonConvert.DeserializeObject<TraktCrew>(jsonFile);

            crew.Should().NotBeNull();
            crew.Production.Should().NotBeNull();
            crew.Art.Should().NotBeNull();
            crew.Crew.Should().NotBeNull();
            crew.CostumeAndMakeup.Should().NotBeNull();
            crew.Directing.Should().NotBeNull();
            crew.Writing.Should().NotBeNull();
            crew.Sound.Should().NotBeNull();
            crew.Camera.Should().NotBeNull();
            crew.Lighting.Should().NotBeNull();
            crew.VisualEffects.Should().NotBeNull();
            crew.Editing.Should().NotBeNull();

            crew.Production.Should().HaveCount(10);
            crew.Art.Should().HaveCount(18);
            crew.Crew.Should().HaveCount(10);
            crew.CostumeAndMakeup.Should().HaveCount(12);
            crew.Directing.Should().HaveCount(1);
            crew.Writing.Should().HaveCount(4);
            crew.Sound.Should().HaveCount(11);
            crew.Camera.Should().HaveCount(13);
            crew.Lighting.Should().HaveCount(3);
            crew.VisualEffects.Should().HaveCount(21);
            crew.Editing.Should().HaveCount(4);

            // Production
            var productionCrew = crew.Production.ToArray();

            productionCrew[0].Job.Should().Be("Casting");
            productionCrew[0].Person.Should().NotBeNull();

            productionCrew[1].Job.Should().Be("Associate Producer");
            productionCrew[1].Person.Should().NotBeNull();

            productionCrew[2].Job.Should().Be("Producer");
            productionCrew[2].Person.Should().NotBeNull();

            productionCrew[3].Job.Should().Be("Casting");
            productionCrew[3].Person.Should().NotBeNull();

            productionCrew[4].Job.Should().Be("Casting");
            productionCrew[4].Person.Should().NotBeNull();

            productionCrew[5].Job.Should().Be("Casting Associate");
            productionCrew[5].Person.Should().NotBeNull();

            productionCrew[6].Job.Should().Be("Producer");
            productionCrew[6].Person.Should().NotBeNull();

            productionCrew[7].Job.Should().Be("Producer");
            productionCrew[7].Person.Should().NotBeNull();

            productionCrew[8].Job.Should().Be("Casting Associate");
            productionCrew[8].Person.Should().NotBeNull();

            productionCrew[9].Job.Should().Be("Researcher");
            productionCrew[9].Person.Should().NotBeNull();

            // Art
            var artCrew = crew.Art.ToArray();

            artCrew[0].Job.Should().Be("Production Design");
            artCrew[0].Person.Should().NotBeNull();

            artCrew[1].Job.Should().Be("Art Direction");
            artCrew[1].Person.Should().NotBeNull();

            artCrew[2].Job.Should().Be("Art Direction");
            artCrew[2].Person.Should().NotBeNull();

            artCrew[3].Job.Should().Be("Art Direction");
            artCrew[3].Person.Should().NotBeNull();

            artCrew[4].Job.Should().Be("Art Direction");
            artCrew[4].Person.Should().NotBeNull();

            artCrew[5].Job.Should().Be("Art Direction");
            artCrew[5].Person.Should().NotBeNull();

            artCrew[6].Job.Should().Be("Production Design");
            artCrew[6].Person.Should().NotBeNull();

            artCrew[7].Job.Should().Be("Set Decoration");
            artCrew[7].Person.Should().NotBeNull();

            artCrew[8].Job.Should().Be("Construction Coordinator");
            artCrew[8].Person.Should().NotBeNull();

            artCrew[9].Job.Should().Be("Art Direction");
            artCrew[9].Person.Should().NotBeNull();

            artCrew[10].Job.Should().Be("Art Direction");
            artCrew[10].Person.Should().NotBeNull();

            artCrew[11].Job.Should().Be("Art Direction");
            artCrew[11].Person.Should().NotBeNull();

            artCrew[12].Job.Should().Be("Art Department Coordinator");
            artCrew[12].Person.Should().NotBeNull();

            artCrew[13].Job.Should().Be("Art Direction");
            artCrew[13].Person.Should().NotBeNull();

            artCrew[14].Job.Should().Be("Art Direction");
            artCrew[14].Person.Should().NotBeNull();

            artCrew[15].Job.Should().Be("Art Direction");
            artCrew[15].Person.Should().NotBeNull();

            artCrew[16].Job.Should().Be("Art Direction");
            artCrew[16].Person.Should().NotBeNull();

            artCrew[17].Job.Should().Be("Art Direction");
            artCrew[17].Person.Should().NotBeNull();

            // Crew
            var crewCrew = crew.Crew.ToArray();

            crewCrew[0].Job.Should().Be("Stunt Coordinator");
            crewCrew[0].Person.Should().NotBeNull();

            crewCrew[1].Job.Should().Be("Property Master");
            crewCrew[1].Person.Should().NotBeNull();

            crewCrew[2].Job.Should().Be("Supervising Art Director");
            crewCrew[2].Person.Should().NotBeNull();

            crewCrew[3].Job.Should().Be("Second Unit Cinematographer");
            crewCrew[3].Person.Should().NotBeNull();

            crewCrew[4].Job.Should().Be("CG Supervisor");
            crewCrew[4].Person.Should().NotBeNull();

            crewCrew[5].Job.Should().Be("CG Supervisor");
            crewCrew[5].Person.Should().NotBeNull();

            crewCrew[6].Job.Should().Be("CG Supervisor");
            crewCrew[6].Person.Should().NotBeNull();

            crewCrew[7].Job.Should().Be("CG Supervisor");
            crewCrew[7].Person.Should().NotBeNull();

            crewCrew[8].Job.Should().Be("Visual Effects Art Director");
            crewCrew[8].Person.Should().NotBeNull();

            crewCrew[9].Job.Should().Be("Visual Effects Editor");
            crewCrew[9].Person.Should().NotBeNull();

            // CostumeAndMakeup
            var costumeCrew = crew.CostumeAndMakeup.ToArray();

            costumeCrew[0].Job.Should().Be("Costume Design");
            costumeCrew[0].Person.Should().NotBeNull();

            costumeCrew[1].Job.Should().Be("Makeup Department Head");
            costumeCrew[1].Person.Should().NotBeNull();

            costumeCrew[2].Job.Should().Be("Makeup Artist");
            costumeCrew[2].Person.Should().NotBeNull();

            costumeCrew[3].Job.Should().Be("Costume Supervisor");
            costumeCrew[3].Person.Should().NotBeNull();

            costumeCrew[4].Job.Should().Be("Hair Designer");
            costumeCrew[4].Person.Should().NotBeNull();

            costumeCrew[5].Job.Should().Be("Assistant Costume Designer");
            costumeCrew[5].Person.Should().NotBeNull();

            costumeCrew[6].Job.Should().Be("Makeup Artist");
            costumeCrew[6].Person.Should().NotBeNull();

            costumeCrew[7].Job.Should().Be("Hairstylist");
            costumeCrew[7].Person.Should().NotBeNull();

            costumeCrew[8].Job.Should().Be("Assistant Costume Designer");
            costumeCrew[8].Person.Should().NotBeNull();

            costumeCrew[9].Job.Should().Be("Hairstylist");
            costumeCrew[9].Person.Should().NotBeNull();

            costumeCrew[10].Job.Should().Be("Hairstylist");
            costumeCrew[10].Person.Should().NotBeNull();

            costumeCrew[11].Job.Should().Be("Key Hair Stylist");
            costumeCrew[11].Person.Should().NotBeNull();

            // Directing
            var directingCrew = crew.Directing.ToArray();

            directingCrew[0].Job.Should().Be("Director");
            directingCrew[0].Person.Should().NotBeNull();

            // Writing
            var writingCrew = crew.Writing.ToArray();

            writingCrew[0].Job.Should().Be("Characters");
            writingCrew[0].Person.Should().NotBeNull();

            writingCrew[1].Job.Should().Be("Writer");
            writingCrew[1].Person.Should().NotBeNull();

            writingCrew[2].Job.Should().Be("Screenplay");
            writingCrew[2].Person.Should().NotBeNull();

            writingCrew[3].Job.Should().Be("Screenplay");
            writingCrew[3].Person.Should().NotBeNull();

            // Sound
            var soundCrew = crew.Sound.ToArray();

            soundCrew[0].Job.Should().Be("Original Music Composer");
            soundCrew[0].Person.Should().NotBeNull();

            soundCrew[1].Job.Should().Be("Music Editor");
            soundCrew[1].Person.Should().NotBeNull();

            soundCrew[2].Job.Should().Be("Sound Re-Recording Mixer");
            soundCrew[2].Person.Should().NotBeNull();

            soundCrew[3].Job.Should().Be("Sound Designer");
            soundCrew[3].Person.Should().NotBeNull();

            soundCrew[4].Job.Should().Be("Supervising Sound Editor");
            soundCrew[4].Person.Should().NotBeNull();

            soundCrew[5].Job.Should().Be("Supervising Sound Editor");
            soundCrew[5].Person.Should().NotBeNull();

            soundCrew[6].Job.Should().Be("Sound Designer");
            soundCrew[6].Person.Should().NotBeNull();

            soundCrew[7].Job.Should().Be("Sound Designer");
            soundCrew[7].Person.Should().NotBeNull();

            soundCrew[8].Job.Should().Be("ADR & Dubbing");
            soundCrew[8].Person.Should().NotBeNull();

            soundCrew[9].Job.Should().Be("Foley");
            soundCrew[9].Person.Should().NotBeNull();

            soundCrew[10].Job.Should().Be("Production Sound Mixer");
            soundCrew[10].Person.Should().NotBeNull();

            // Camera
            var cameraCrew = crew.Camera.ToArray();

            cameraCrew[0].Job.Should().Be("Director of Photography");
            cameraCrew[0].Person.Should().NotBeNull();

            cameraCrew[1].Job.Should().Be("First Assistant Camera");
            cameraCrew[1].Person.Should().NotBeNull();

            cameraCrew[2].Job.Should().Be("Camera Operator");
            cameraCrew[2].Person.Should().NotBeNull();

            cameraCrew[3].Job.Should().Be("Camera Operator");
            cameraCrew[3].Person.Should().NotBeNull();

            cameraCrew[4].Job.Should().Be("Still Photographer");
            cameraCrew[4].Person.Should().NotBeNull();

            cameraCrew[5].Job.Should().Be("Helicopter Camera");
            cameraCrew[5].Person.Should().NotBeNull();

            cameraCrew[6].Job.Should().Be("Camera Operator");
            cameraCrew[6].Person.Should().NotBeNull();

            cameraCrew[7].Job.Should().Be("Steadicam Operator");
            cameraCrew[7].Person.Should().NotBeNull();

            cameraCrew[8].Job.Should().Be("First Assistant Camera");
            cameraCrew[8].Person.Should().NotBeNull();

            cameraCrew[9].Job.Should().Be("First Assistant Camera");
            cameraCrew[9].Person.Should().NotBeNull();

            cameraCrew[10].Job.Should().Be("First Assistant Camera");
            cameraCrew[10].Person.Should().NotBeNull();

            cameraCrew[11].Job.Should().Be("First Assistant Camera");
            cameraCrew[11].Person.Should().NotBeNull();

            cameraCrew[12].Job.Should().Be("Camera Operator");
            cameraCrew[12].Person.Should().NotBeNull();

            // Lighting
            var lightingCrew = crew.Lighting.ToArray();

            lightingCrew[0].Job.Should().Be("Gaffer");
            lightingCrew[0].Person.Should().NotBeNull();

            lightingCrew[1].Job.Should().Be("Gaffer");
            lightingCrew[1].Person.Should().NotBeNull();

            lightingCrew[2].Job.Should().Be("Gaffer");
            lightingCrew[2].Person.Should().NotBeNull();

            // VisualEffects
            var vfxCrew = crew.VisualEffects.ToArray();

            vfxCrew[0].Job.Should().Be("Visual Effects Supervisor");
            vfxCrew[0].Person.Should().NotBeNull();

            vfxCrew[1].Job.Should().Be("Special Effects Supervisor");
            vfxCrew[1].Person.Should().NotBeNull();

            vfxCrew[2].Job.Should().Be("Visual Effects Supervisor");
            vfxCrew[2].Person.Should().NotBeNull();

            vfxCrew[3].Job.Should().Be("Visual Effects Producer");
            vfxCrew[3].Person.Should().NotBeNull();

            vfxCrew[4].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[4].Person.Should().NotBeNull();

            vfxCrew[5].Job.Should().Be("Creature Design");
            vfxCrew[5].Person.Should().NotBeNull();

            vfxCrew[6].Job.Should().Be("Animation");
            vfxCrew[6].Person.Should().NotBeNull();

            vfxCrew[7].Job.Should().Be("Animation");
            vfxCrew[7].Person.Should().NotBeNull();

            vfxCrew[8].Job.Should().Be("Animation");
            vfxCrew[8].Person.Should().NotBeNull();

            vfxCrew[9].Job.Should().Be("Animation");
            vfxCrew[9].Person.Should().NotBeNull();

            vfxCrew[10].Job.Should().Be("Animation");
            vfxCrew[10].Person.Should().NotBeNull();

            vfxCrew[11].Job.Should().Be("Animation");
            vfxCrew[11].Person.Should().NotBeNull();

            vfxCrew[12].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[12].Person.Should().NotBeNull();

            vfxCrew[13].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[13].Person.Should().NotBeNull();

            vfxCrew[14].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[14].Person.Should().NotBeNull();

            vfxCrew[15].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[15].Person.Should().NotBeNull();

            vfxCrew[16].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[16].Person.Should().NotBeNull();

            vfxCrew[17].Job.Should().Be("Visual Effects Coordinator");
            vfxCrew[17].Person.Should().NotBeNull();

            vfxCrew[18].Job.Should().Be("Visual Effects Producer");
            vfxCrew[18].Person.Should().NotBeNull();

            vfxCrew[19].Job.Should().Be("Visual Effects Supervisor");
            vfxCrew[19].Person.Should().NotBeNull();

            vfxCrew[20].Job.Should().Be("VFX Editor");
            vfxCrew[20].Person.Should().NotBeNull();

            // Editing
            var editingCrew = crew.Editing.ToArray();

            editingCrew[0].Job.Should().Be("Editor");
            editingCrew[0].Person.Should().NotBeNull();

            editingCrew[1].Job.Should().Be("Editor");
            editingCrew[1].Person.Should().NotBeNull();

            editingCrew[2].Job.Should().Be("Digital Intermediate");
            editingCrew[2].Person.Should().NotBeNull();

            editingCrew[3].Job.Should().Be("First Assistant Editor");
            editingCrew[3].Person.Should().NotBeNull();
        }
    }
}
