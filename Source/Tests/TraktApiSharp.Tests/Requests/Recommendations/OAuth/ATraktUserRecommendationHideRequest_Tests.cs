namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class ATraktUserRecommendationHideRequest_Tests
    {
        internal class TraktUserRecommendationHideRequestMock : ATraktUserRecommendationHideRequest
        {
            public override TraktRequestObjectType RequestObjectType { get { throw new NotImplementedException(); } }

            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_IsAbstract()
        {
            typeof(ATraktUserRecommendationHideRequest).IsAbstract.Should().BeTrue();
        }
        
        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(ATraktUserRecommendationHideRequest).IsSubclassOf(typeof(ADeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktUserRecommendationHideRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktUserRecommendationHideRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new TraktUserRecommendationHideRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_ATraktUserRecommendationHideRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktUserRecommendationHideRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktUserRecommendationHideRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktUserRecommendationHideRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
