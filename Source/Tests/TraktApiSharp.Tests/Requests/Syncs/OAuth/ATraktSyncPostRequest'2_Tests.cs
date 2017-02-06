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
    public class ATraktSyncPostRequest_2_Tests
    {
        internal class TraktSyncPostRequestMock : ATraktSyncPostRequest<int, float>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktSyncPostRequest_2_Is_Abstract()
        {
            typeof(ATraktSyncPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSyncPostRequest_2_Has_GenericTypeParameter()
        {
            typeof(ATraktSyncPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ATraktSyncPostRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(ATraktSyncPostRequest<int, float>).IsSubclassOf(typeof(ATraktPostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktSyncPostRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktSyncPostRequestMock();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktSyncPostRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new TraktSyncPostRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
