namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects;
    using Utils;

    [TestClass]
    public class TraktCastAndCrewTests
    {
        [TestMethod]
        public void TestTraktCastAndCrewDefaultConstructor()
        {
            var castAndCrew = new TraktCastAndCrew();

            castAndCrew.Cast.Should().BeNull();
            castAndCrew.Crew.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCastAndCrewReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Basic\CastAndCrew.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var castAndCrew = JsonConvert.DeserializeObject<TraktCastAndCrew>(jsonFile);

            castAndCrew.Should().NotBeNull();
            castAndCrew.Cast.Should().NotBeNull().And.HaveCount(39);
            castAndCrew.Crew.Should().NotBeNull();

            castAndCrew.Crew.Should().NotBeNull();
            castAndCrew.Crew.Production.Should().NotBeNull();
            castAndCrew.Crew.Art.Should().NotBeNull();
            castAndCrew.Crew.Crew.Should().NotBeNull();
            castAndCrew.Crew.CostumeAndMakeup.Should().NotBeNull();
            castAndCrew.Crew.Directing.Should().NotBeNull();
            castAndCrew.Crew.Writing.Should().NotBeNull();
            castAndCrew.Crew.Sound.Should().NotBeNull();
            castAndCrew.Crew.Camera.Should().NotBeNull();
            castAndCrew.Crew.Lighting.Should().NotBeNull();
            castAndCrew.Crew.VisualEffects.Should().NotBeNull();
            castAndCrew.Crew.Editing.Should().NotBeNull();

            castAndCrew.Crew.Production.Should().HaveCount(10);
            castAndCrew.Crew.Art.Should().HaveCount(18);
            castAndCrew.Crew.Crew.Should().HaveCount(10);
            castAndCrew.Crew.CostumeAndMakeup.Should().HaveCount(12);
            castAndCrew.Crew.Directing.Should().HaveCount(1);
            castAndCrew.Crew.Writing.Should().HaveCount(4);
            castAndCrew.Crew.Sound.Should().HaveCount(11);
            castAndCrew.Crew.Camera.Should().HaveCount(13);
            castAndCrew.Crew.Lighting.Should().HaveCount(3);
            castAndCrew.Crew.VisualEffects.Should().HaveCount(21);
            castAndCrew.Crew.Editing.Should().HaveCount(4);

            // Cast
            var cast = castAndCrew.Cast.ToArray();

            cast[0].Character.Should().Be("Rey");
            cast[0].Person.Should().NotBeNull();

            cast[1].Character.Should().Be("Finn");
            cast[1].Person.Should().NotBeNull();

            cast[2].Character.Should().Be("Kylo Ren");
            cast[2].Person.Should().NotBeNull();

            cast[3].Character.Should().Be("Han Solo");
            cast[3].Person.Should().NotBeNull();

            cast[4].Character.Should().Be("Princess Leia");
            cast[4].Person.Should().NotBeNull();

            cast[5].Character.Should().Be("Poe Dameron");
            cast[5].Person.Should().NotBeNull();

            cast[6].Character.Should().Be("Luke Skywalker");
            cast[6].Person.Should().NotBeNull();

            cast[7].Character.Should().Be("Chewbacca");
            cast[7].Person.Should().NotBeNull();

            cast[8].Character.Should().Be("General Hux");
            cast[8].Person.Should().NotBeNull();

            cast[9].Character.Should().Be("Maz Kanata");
            cast[9].Person.Should().NotBeNull();

            cast[10].Character.Should().Be("Captain Phasma");
            cast[10].Person.Should().NotBeNull();

            cast[11].Character.Should().Be("Supreme Leader Snoke");
            cast[11].Person.Should().NotBeNull();

            cast[12].Character.Should().Be("Unkar Plutt");
            cast[12].Person.Should().NotBeNull();

            cast[13].Character.Should().Be("Lor San Tekka");
            cast[13].Person.Should().NotBeNull();

            cast[14].Character.Should().Be("C3PO");
            cast[14].Person.Should().NotBeNull();

            cast[15].Character.Should().Be("R2D2");
            cast[15].Person.Should().NotBeNull();

            cast[16].Character.Should().Be("Lieutenant Connix");
            cast[16].Person.Should().NotBeNull();

            cast[17].Character.Should().Be("Snap Wexley");
            cast[17].Person.Should().NotBeNull();

            cast[18].Character.Should().Be("Admiral Statura");
            cast[18].Person.Should().NotBeNull();

            cast[19].Character.Should().Be("Korr Sella");
            cast[19].Person.Should().NotBeNull();

            cast[20].Character.Should().Be("Bar Patron");
            cast[20].Person.Should().NotBeNull();

            cast[21].Character.Should().Be("Lead Stormtrooper");
            cast[21].Person.Should().NotBeNull();

            cast[22].Character.Should().Be("Resistance Soldier");
            cast[22].Person.Should().NotBeNull();

            cast[23].Character.Should().Be("Jess Testor");
            cast[23].Person.Should().NotBeNull();

            cast[24].Character.Should().Be("Wollivan");
            cast[24].Person.Should().NotBeNull();

            cast[25].Character.Should().Be("Razoo Quin-Fee");
            cast[25].Person.Should().NotBeNull();

            cast[26].Character.Should().Be("Tasu Leech");
            cast[26].Person.Should().NotBeNull();

            cast[27].Character.Should().Be("Ensign Goode");
            cast[27].Person.Should().NotBeNull();

            cast[28].Character.Should().Be("Min Sakul");
            cast[28].Person.Should().NotBeNull();

            cast[29].Character.Should().Be("Bazine Netal");
            cast[29].Person.Should().NotBeNull();

            cast[30].Character.Should().Be("Dr. Kalonia");
            cast[30].Person.Should().NotBeNull();

            cast[31].Character.Should().Be("Stormtrooper");
            cast[31].Person.Should().NotBeNull();

            cast[32].Character.Should().Be("Obi-Wan Kenobi (voice cameo)");
            cast[32].Person.Should().NotBeNull();

            cast[33].Character.Should().Be("Ben (Obi Wan) Kenobi (voice cameo)");
            cast[33].Person.Should().NotBeNull();

            cast[34].Character.Should().Be("Yoda (voice cameo)");
            cast[34].Person.Should().NotBeNull();

            cast[35].Character.Should().Be("Obi-Wan Kenobi (voice cameo)");
            cast[35].Person.Should().NotBeNull();

            cast[36].Character.Should().Be("Ben (Obi Wan) Kenobi (voice cameo)");
            cast[36].Person.Should().NotBeNull();

            cast[37].Character.Should().Be("BB-8 Voice Consultant");
            cast[37].Person.Should().NotBeNull();

            cast[38].Character.Should().Be("BB-8 Voice Consultant");
            cast[38].Person.Should().NotBeNull();
        }
    }
}
