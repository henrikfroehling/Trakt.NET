namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowStatisticsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowStatisticsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowStatisticsRequest_Is_Sealed()
        {
            typeof(TraktShowStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowStatisticsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowStatisticsRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktStatistics>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowStatisticsRequest();
            request.UriTemplate.Should().Be("shows/{id}/stats");
        }

        [Fact]
        public void Test_TraktShowStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktShowStatisticsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktShowStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowStatisticsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowStatisticsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowStatisticsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
