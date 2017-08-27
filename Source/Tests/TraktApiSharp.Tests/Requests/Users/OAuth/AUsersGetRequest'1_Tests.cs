namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class AUsersGetRequest_1_Tests
    {
        internal class UsersGetRequestMock : AUsersGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Is_Abstract()
        {
            typeof(AUsersGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(AUsersGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(AUsersGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(AUsersGetRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(AUsersGetRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Has_AuthorizationRequirement_Optional()
        {
            var request = new UsersGetRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_AUsersGetRequest_1_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var requestMock = new UsersGetRequestMock();
            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new UsersGetRequestMock { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });
        }
    }
}
