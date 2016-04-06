namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects;
    using Utils;

    [TestClass]
    public class TraktCastMemberTests
    {
        [TestMethod]
        public void TestTraktCastMemberDefaultConstructor()
        {
            var castMember = new TraktCastMember();

            castMember.Character.Should().BeNullOrEmpty();
            castMember.Person.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCastMemberReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\CastMember.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var castMember = JsonConvert.DeserializeObject<TraktCastMember>(jsonFile);

            castMember.Should().NotBeNull();
            castMember.Character.Should().Be("Barry Allen / The Flash");
            castMember.Person.Should().NotBeNull();
        }
    }
}
