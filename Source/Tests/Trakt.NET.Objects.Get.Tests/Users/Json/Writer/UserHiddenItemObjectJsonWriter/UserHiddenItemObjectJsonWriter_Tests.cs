namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class UserHiddenItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
