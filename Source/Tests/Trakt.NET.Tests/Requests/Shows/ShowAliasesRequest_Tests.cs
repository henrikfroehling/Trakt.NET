namespace TraktNet.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowAliasesRequest_Tests
    {
        [Fact]
        public void Test_ShowAliasesRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowAliasesRequest();
            request.UriTemplate.Should().Be("shows/{id}/aliases");
        }

        [Fact]
        public void Test_ShowAliasesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ShowAliasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_ShowAliasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowAliasesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ShowAliasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ShowAliasesRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();
        }
    }
}
