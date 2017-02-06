namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class ATraktUsersGetRequest_1_Tests
    {
        internal class TraktUsersGetRequestMock : ATraktUsersGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Is_Abstract()
        {
            typeof(ATraktUsersGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktUsersGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktUsersGetRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktUsersGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUsersGetRequestMock();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_ATraktUsersGetRequest_1_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var requestMock = new TraktUsersGetRequestMock();
            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktUsersGetRequestMock { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });
        }
    }
}
