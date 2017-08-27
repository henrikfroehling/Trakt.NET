namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowStatisticsRequest_Tests
    {
        [Fact]
        public void Test_ShowStatisticsRequest_Is_Not_Abstract()
        {
            typeof(ShowStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ShowStatisticsRequest_Is_Sealed()
        {
            typeof(ShowStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ShowStatisticsRequest_Inherits_AShowRequest_1()
        {
            typeof(ShowStatisticsRequest).IsSubclassOf(typeof(AShowRequest<ITraktStatistics>)).Should().BeTrue();
        }

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
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowStatisticsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
