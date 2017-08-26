namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowSummaryRequest_Tests
    {
        [Fact]
        public void Test_ShowSummaryRequest_Is_Not_Abstract()
        {
            typeof(ShowSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ShowSummaryRequest_Is_Sealed()
        {
            typeof(ShowSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ShowSummaryRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(ShowSummaryRequest).IsSubclassOf(typeof(AShowRequest<ITraktShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ShowSummaryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ShowSummaryRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ShowSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowSummaryRequest();
            request.UriTemplate.Should().Be("shows/{id}{?extended}");
        }

        [Fact]
        public void Test_ShowSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new ShowSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_ShowSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowSummaryRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
