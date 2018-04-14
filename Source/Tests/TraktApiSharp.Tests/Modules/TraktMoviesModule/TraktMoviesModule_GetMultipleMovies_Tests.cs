namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMultipleMoviesArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktMovie>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(null);
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { "movie id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
