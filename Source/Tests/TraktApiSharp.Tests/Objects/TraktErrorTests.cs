namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects;
    using Utils;

    [TestClass]
    public class TraktErrorTests
    {
        [TestMethod]
        public void TestTraktErrorDefaultConstructor()
        {
            var error = new TraktError();

            error.Error.Should().BeNullOrEmpty();
            error.Description.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktErrorReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\Error.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var error = JsonConvert.DeserializeObject<TraktError>(jsonFile);

            error.Should().NotBeNull();
            error.Error.Should().Be("invalid_grant");
            error.Description.Should().Be("The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client.");
        }
    }
}
