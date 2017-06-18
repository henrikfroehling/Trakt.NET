namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.Interfaces")]
    public class ITraktCommentPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktCommentPostResponse_Is_Interface()
        {
            typeof(ITraktCommentPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCommentPostResponse_Inherits_ITraktComment_Interface()
        {
            typeof(ITraktCommentPostResponse).GetInterfaces().Should().Contain(typeof(ITraktComment));
        }

        [Fact]
        public void Test_ITraktCommentPostResponse_Has_Sharing_Property()
        {
            var propertyInfo = typeof(ITraktCommentPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Sharing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSharing));
        }
    }
}
