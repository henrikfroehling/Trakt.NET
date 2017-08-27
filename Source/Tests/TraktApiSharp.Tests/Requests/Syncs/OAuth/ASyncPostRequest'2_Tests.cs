namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class ASyncPostRequest_2_Tests
    {
        internal class SyncPostRequestMock : ASyncPostRequest<int, float>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Is_Abstract()
        {
            typeof(ASyncPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Has_GenericTypeParameter()
        {
            typeof(ASyncPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ASyncPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(ASyncPostRequest<int, float>).IsSubclassOf(typeof(APostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncPostRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new SyncPostRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
