namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowPeopleRequest_Tests
    {
        [Fact]
        public void Test_ShowPeopleRequest_Is_Not_Abstract()
        {
            typeof(ShowPeopleRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ShowPeopleRequest_Is_Sealed()
        {
            typeof(ShowPeopleRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ShowPeopleRequest_Inherits_AShowRequest_1()
        {
            typeof(ShowPeopleRequest).IsSubclassOf(typeof(AShowRequest<ITraktCastAndCrew>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ShowPeopleRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(ShowPeopleRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ShowPeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowPeopleRequest();
            request.UriTemplate.Should().Be("shows/{id}/people{?extended}");
        }

        [Fact]
        public void Test_ShowPeopleRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new ShowPeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new ShowPeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_ShowPeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowPeopleRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowPeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowPeopleRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
