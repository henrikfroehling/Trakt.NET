namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class ATraktUserRecommendationsRequest_1_Tests
    {
        internal class TraktUserRecommendationsRequestMock : ATraktUserRecommendationsRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_IsAbstract()
        {
            typeof(ATraktUserRecommendationsRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktUserRecommendationsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUserRecommendationsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktUserRecommendationsRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktUserRecommendationsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktUserRecommendationsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Has_Limit_Property()
        {
            var propertyInfo = typeof(ATraktUserRecommendationsRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Limit")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ATraktUserRecommendationsRequest_1_Returns_Valid_UriPathParameters()
        {
            // no parameters
            var requestMock = new TraktUserRecommendationsRequestMock();

            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktUserRecommendationsRequestMock { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });

            // with extended info and limit
            var limit = 123U;
            requestMock = new TraktUserRecommendationsRequestMock { ExtendedInfo = extendedInfo, Limit = limit };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString(),
                                                           ["limit"] = limit.ToString()
                                                       });
        }
    }
}
