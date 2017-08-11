namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.JsonReader")]
    public partial class TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup>));
        }
    }
}
