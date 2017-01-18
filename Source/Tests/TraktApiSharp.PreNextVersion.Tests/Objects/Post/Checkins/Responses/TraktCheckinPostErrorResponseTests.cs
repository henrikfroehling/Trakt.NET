namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Utils;

    [TestClass]
    public class TraktCheckinPostErrorResponseTests
    {
        [TestMethod]
        public void TestTraktCheckinPostErrorResponseDefaultConstructor()
        {
            var checkinErrorResponse = new TraktCheckinPostErrorResponse();

            checkinErrorResponse.ExpiresAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktCheckinPostErrorResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\CheckinPostErrorResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var checkinErrorResponse = JsonConvert.DeserializeObject<TraktCheckinPostErrorResponse>(jsonFile);

            checkinErrorResponse.Should().NotBeNull();
            checkinErrorResponse.ExpiresAt.Should().Be(DateTime.Parse("2014-10-15T22:21:29.000Z").ToUniversalTime());
        }
    }
}
