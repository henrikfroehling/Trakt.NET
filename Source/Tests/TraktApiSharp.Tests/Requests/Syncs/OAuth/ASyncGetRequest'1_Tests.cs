namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class ASyncGetRequest_1_Tests
    {
        internal class SyncGetRequestMock : ASyncGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ASyncGetRequest_1_Is_Abstract()
        {
            typeof(ASyncGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ASyncGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ASyncGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ASyncGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ASyncGetRequest_1_Inherits_AGetRequest_1()
        {
            typeof(ASyncGetRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ASyncGetRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncGetRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ASyncGetRequest_1_Returns_Valid_UriPathParameters()
        {
            var request = new SyncGetRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
