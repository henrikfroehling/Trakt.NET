namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowSummaryRequest_Tests
    {
        [Fact]
        public void Test_TraktShowSummaryRequest_Is_Not_Abstract()
        {
            typeof(TraktShowSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Is_Sealed()
        {
            typeof(TraktShowSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowSummaryRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowSummaryRequest();
            request.UriTemplate.Should().Be("shows/{id}{?extended}");
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktShowSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktShowSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktShowSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowSummaryRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
