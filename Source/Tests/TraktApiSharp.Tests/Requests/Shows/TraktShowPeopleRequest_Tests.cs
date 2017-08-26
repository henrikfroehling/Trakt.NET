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
    public class TraktShowPeopleRequest_Tests
    {
        [Fact]
        public void Test_TraktShowPeopleRequest_Is_Not_Abstract()
        {
            typeof(TraktShowPeopleRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Is_Sealed()
        {
            typeof(TraktShowPeopleRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowPeopleRequest).IsSubclassOf(typeof(AShowRequest<ITraktCastAndCrew>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowPeopleRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowPeopleRequest();
            request.UriTemplate.Should().Be("shows/{id}/people{?extended}");
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktShowPeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktShowPeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktShowPeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowPeopleRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowPeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowPeopleRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
