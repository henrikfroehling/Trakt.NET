namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Shows;
    using Utils;

    [TestClass]
    public class TraktShowPeopleTests
    {
        [TestMethod]
        public void TestTraktShowPeopleReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Shows\ShowPeople.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var people = JsonConvert.DeserializeObject<TraktShowPeople>(jsonFile);

            people.Should().NotBeNull();

            people.Cast.Should().NotBeNull().And.HaveCount(3);

            var cast = people.Cast.ToArray();

            cast[0].Character.Should().Be("Rick Grimes");
            cast[0].Person.Should().NotBeNull();

            cast[1].Character.Should().Be("Daryl Dixon");
            cast[1].Person.Should().NotBeNull();

            cast[2].Character.Should().Be("Glenn Rhee");
            cast[2].Person.Should().NotBeNull();

            people.Crew.Should().NotBeNull();

            people.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            people.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            people.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            people.Crew.CostumeAndMakeup.Should().BeNull();
            people.Crew.Directing.Should().BeNull();
            people.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            people.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            people.Crew.Camera.Should().BeNull();
            people.Crew.Lighting.Should().BeNull();
            people.Crew.VisualEffects.Should().BeNull();
            people.Crew.Editing.Should().BeNull();

            // Production
            var productionCrew = people.Crew.Production.ToArray();

            productionCrew[0].Job.Should().Be("Casting");
            productionCrew[0].Person.Should().NotBeNull();

            productionCrew[1].Job.Should().Be("Executive Producer");
            productionCrew[1].Person.Should().NotBeNull();

            // Crew
            var crewCrew = people.Crew.Crew.ToArray();

            crewCrew[0].Job.Should().Be("Makeup Effects");
            crewCrew[0].Person.Should().NotBeNull();

            // Art
            var artCrew = people.Crew.Art.ToArray();

            artCrew[0].Job.Should().Be("Production Design");
            artCrew[0].Person.Should().NotBeNull();

            // Sound
            var soundCrew = people.Crew.Sound.ToArray();

            soundCrew[0].Job.Should().Be("Music");
            soundCrew[0].Person.Should().NotBeNull();

            // Writing
            var writingCrew = people.Crew.Writing.ToArray();

            writingCrew[0].Job.Should().Be("Comic Book");
            writingCrew[0].Person.Should().NotBeNull();

            writingCrew[1].Job.Should().Be("Comic Book");
            writingCrew[1].Person.Should().NotBeNull();

            writingCrew[2].Job.Should().Be("Comic Book");
            writingCrew[2].Person.Should().NotBeNull();
        }
    }
}
