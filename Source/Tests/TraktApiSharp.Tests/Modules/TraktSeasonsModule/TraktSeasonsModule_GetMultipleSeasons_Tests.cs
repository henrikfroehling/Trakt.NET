namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonsArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            Func<Task<IEnumerable<TraktListResponse<ITraktEpisode>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(null);
            act.Should().NotThrow();

            var queryParams = new TraktMultipleSeasonsQueryParams();
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().NotThrow();

            queryParams = new TraktMultipleSeasonsQueryParams { { null, seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { string.Empty, seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { "show id", seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "eng" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentOutOfRangeException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "e" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentOutOfRangeException>();

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}?translations=all", SEASON_EPISODES_JSON);

            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "all" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().NotThrow();
        }
    }
}
