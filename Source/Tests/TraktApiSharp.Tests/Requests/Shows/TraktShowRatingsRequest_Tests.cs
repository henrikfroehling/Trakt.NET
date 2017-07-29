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
    public class TraktShowRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowRatingsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowRatingsRequest_Is_Sealed()
        {
            typeof(TraktShowRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowRatingsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowRatingsRequest).IsSubclassOf(typeof(ATraktShowRequest<ITraktRating>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/ratings");
        }

        [Fact]
        public void Test_TraktShowRatingsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktShowRatingsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktShowRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowRatingsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowRatingsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowRatingsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
