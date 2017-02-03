namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowAliasesRequest_Tests
    {
        [Fact]
        public void Test_TraktShowAliasesRequest_Is_Not_Abstract()
        {
            typeof(TraktShowAliasesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowAliasesRequest_Is_Sealed()
        {
            typeof(TraktShowAliasesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowAliasesRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowAliasesRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktShowAlias>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowAliasesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowAliasesRequest();
            request.UriTemplate.Should().Be("shows/{id}/aliases");
        }

        [Fact]
        public void Test_TraktShowAliasesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktShowAliasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktShowAliasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowAliasesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowAliasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowAliasesRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
