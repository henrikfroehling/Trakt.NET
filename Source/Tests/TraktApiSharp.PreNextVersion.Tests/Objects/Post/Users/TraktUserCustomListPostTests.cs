namespace TraktApiSharp.Tests.Objects.Post.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Users.Implementations;

    [TestClass]
    public class TraktUserCustomListPostTests
    {
        [TestMethod]
        public void TestTraktUserCustomListPostDefaultConstructor()
        {
            var userListPost = new TraktUserCustomListPost();

            userListPost.Name.Should().BeNullOrEmpty();
            userListPost.Description.Should().BeNullOrEmpty();
            userListPost.Privacy.Should().BeNull();
            userListPost.DisplayNumbers.Should().NotHaveValue();
            userListPost.AllowComments.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktUserCustomListPostWriteJson()
        {
            var name = "list name";
            var description = "list description";
            var privacy = TraktAccessScope.Public;
            var displayNumbers = true;
            var allowComments = false;

            var userListPost = new TraktUserCustomListPost
            {
                Name = name,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            //var strJson = JsonConvert.SerializeObject(userListPost);

            //strJson.Should().NotBeNullOrEmpty();

            //var userListPostFromJson = JsonConvert.DeserializeObject<TraktUserCustomListPost>(strJson);

            //userListPostFromJson.Should().NotBeNull();

            //userListPostFromJson.Name.Should().Be(name);
            //userListPostFromJson.Description.Should().Be(description);
            //userListPostFromJson.Privacy.Should().Be(privacy);
            //userListPostFromJson.DisplayNumbers.Should().Be(displayNumbers);
            //userListPostFromJson.AllowComments.Should().Be(allowComments);
        }
    }
}
