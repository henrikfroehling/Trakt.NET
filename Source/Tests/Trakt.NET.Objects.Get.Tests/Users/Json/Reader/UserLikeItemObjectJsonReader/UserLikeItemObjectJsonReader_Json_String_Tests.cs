namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserLikeItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();
            Func<Task<ITraktUserLikeItem>> traktUserLikeItem = () => jsonReader.ReadObjectAsync(default(string));
            traktUserLikeItem.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserLikeItem.Should().BeNull();
        }
    }
}
