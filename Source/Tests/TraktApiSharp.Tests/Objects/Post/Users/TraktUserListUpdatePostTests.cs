namespace TraktApiSharp.Tests.Objects.Post.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Users;

    [TestClass]
    public class TraktUserListUpdatePostTests
    {
        [TestMethod]
        public void TestTraktUserListUpdatePostDefaultConstructor()
        {
            var userListUpdatePost = new TraktUserListUpdatePost();

            userListUpdatePost.Name.Should().BeNullOrEmpty();
            userListUpdatePost.Description.Should().BeNullOrEmpty();
            userListUpdatePost.Privacy.Should().Be(TraktAccessScope.Unspecified);
            userListUpdatePost.DisplayNumbers.Should().NotHaveValue();
            userListUpdatePost.AllowComments.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktUserListUpdatePostWriteJson()
        {
            var name = "list name";
            var description = "list description";
            var privacy = TraktAccessScope.Public;
            var displayNumbers = true;
            var allowComments = false;

            var userListUpdatePost = new TraktUserListUpdatePost
            {
                Name = name,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var strJson = JsonConvert.SerializeObject(userListUpdatePost);

            strJson.Should().NotBeNullOrEmpty();

            var userListUpdatePostFromJson = JsonConvert.DeserializeObject<TraktUserListUpdatePost>(strJson);

            userListUpdatePostFromJson.Should().NotBeNull();

            userListUpdatePostFromJson.Name.Should().Be(name);
            userListUpdatePostFromJson.Description.Should().Be(description);
            userListUpdatePostFromJson.Privacy.Should().Be(privacy);
            userListUpdatePostFromJson.DisplayNumbers.Should().Be(displayNumbers);
            userListUpdatePostFromJson.AllowComments.Should().Be(allowComments);
        }
    }
}
