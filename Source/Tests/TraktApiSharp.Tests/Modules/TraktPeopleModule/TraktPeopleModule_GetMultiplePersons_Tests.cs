namespace TraktApiSharp.Tests.Modules.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        [Fact]
        public void Test_TraktPeopleModule_GetPersonsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktPerson>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(null);
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { "person id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
