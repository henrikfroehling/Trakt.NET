namespace TraktApiSharp.Tests.Modules.TraktListsModule
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private const string GET_POPULAR_LISTS_URI = "lists/popular";

        [Fact]
        public async Task Test_TraktListsModule_GetPopularLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_LISTS_URI, POPULAR_LISTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Lists.GetPopularListsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetPopularLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_POPULAR_LISTS_URI}?page={PAGE}",
                                                           POPULAR_LISTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetPopularListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetPopularLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_POPULAR_LISTS_URI}?limit={LIMIT}",
                                                           POPULAR_LISTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetPopularListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetPopularLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_POPULAR_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           POPULAR_LISTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetPopularListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }
    }
}
