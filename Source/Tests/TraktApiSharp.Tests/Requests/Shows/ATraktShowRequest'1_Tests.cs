namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows")]
    public class ATraktShowRequest_1_Tests
    {
        internal class TraktShowRequestMock : ATraktShowRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Is_Abstract()
        {
            typeof(ATraktShowRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktShowRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktShowRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktShowRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktShowRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktShowRequestMock();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Shows);
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new TraktShowRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_ATraktShowRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktShowRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktShowRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktShowRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
