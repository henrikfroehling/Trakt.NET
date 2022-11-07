namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();
            Func<Task<ITraktUserLikeItem>> traktUserLikeItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktUserLikeItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserLikeItem = await jsonReader.ReadObjectAsync(stream);
                traktUserLikeItem.Should().BeNull();
            }
        }
    }
}
