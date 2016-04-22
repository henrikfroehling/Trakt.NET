namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCrewMemberTests
    {
        [TestMethod]
        public void TestTraktCrewMemberDefaultConstructor()
        {
            var crewMember = new TraktCrewMember();

            crewMember.Job.Should().BeNullOrEmpty();
            crewMember.Person.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCrewMemberReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\CrewMember.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var crewMember = JsonConvert.DeserializeObject<TraktCrewMember>(jsonFile);

            crewMember.Should().NotBeNull();
            crewMember.Job.Should().Be("Executive Producer");
            crewMember.Person.Should().NotBeNull();
        }
    }
}
