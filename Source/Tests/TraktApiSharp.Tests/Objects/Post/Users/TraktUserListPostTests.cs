namespace TraktApiSharp.Tests.Objects.Post.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Users;

    [TestClass]
    public class TraktUserListPostTests
    {
        [TestMethod]
        public void TestTraktUserListPostDefaultConstructor()
        {
            var userListPost = new TraktUserListPost();

            userListPost.Name.Should().BeNullOrEmpty();
            userListPost.Description.Should().BeNullOrEmpty();
            userListPost.Privacy.Should().Be(TraktAccessScope.Unspecified);
            userListPost.DisplayNumbers.Should().NotHaveValue();
            userListPost.AllowComments.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktUserListPostWriteJson()
        {
            var name = "list name";
            var description = "list description";
            var privacy = TraktAccessScope.Public;
            var displayNumbers = true;
            var allowComments = false;

            var userListPost = new TraktUserListPost
            {
                Name = name,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var strJson = JsonConvert.SerializeObject(userListPost);

            strJson.Should().NotBeNullOrEmpty();

            var userListPostFromJson = JsonConvert.DeserializeObject<TraktUserListPost>(strJson);

            userListPostFromJson.Should().NotBeNull();

            userListPostFromJson.Name.Should().Be(name);
            userListPostFromJson.Description.Should().Be(description);
            userListPostFromJson.Privacy.Should().Be(privacy);
            userListPostFromJson.DisplayNumbers.Should().Be(displayNumbers);
            userListPostFromJson.AllowComments.Should().Be(allowComments);
        }
    }
}
