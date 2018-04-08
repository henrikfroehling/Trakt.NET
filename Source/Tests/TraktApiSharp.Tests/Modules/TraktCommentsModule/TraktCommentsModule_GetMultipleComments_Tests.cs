namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        [Fact]
        public void Test_TraktCommentsModule_GetCommentsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktComment>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(new uint[] { 0 });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(new uint[] { });
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(null);
            act.Should().NotThrow();
        }
    }
}
