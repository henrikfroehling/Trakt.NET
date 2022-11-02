namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows")]
    public class ShowStatisticsRequest_Tests
    {
        [Fact]
        public void Test_ShowStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowStatisticsRequest();
            request.UriTemplate.Should().Be("shows/{id}/stats");
        }

        [Fact]
        public void Test_ShowStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowStatisticsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowStatisticsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ShowStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ShowStatisticsRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
