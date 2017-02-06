namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class ATraktSyncGetRequest_1_Tests
    {
        internal class TraktSyncGetRequestMock : ATraktSyncGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktSyncGetRequest_1_Is_Abstract()
        {
            typeof(ATraktSyncGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSyncGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktSyncGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktSyncGetRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktSyncGetRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSyncGetRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktSyncGetRequestMock();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktSyncGetRequest_1_Returns_Valid_UriPathParameters()
        {
            var request = new TraktSyncGetRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
