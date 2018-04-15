namespace TraktApiSharp.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        [Fact]
        public void Test_TraktShowsModule_GetShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktShow>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(null);
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { "show id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
