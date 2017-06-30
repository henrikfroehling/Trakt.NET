namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.Interfaces")]
    public class ITraktScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_ITraktScrobblePostResponse_Is_Interface()
        {
            typeof(ITraktScrobblePostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktScrobblePostResponse_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ulong));
        }

        [Fact]
        public void Test_ITraktScrobblePostResponse_Has_Action_Property()
        {
            var propertyInfo = typeof(ITraktScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Action");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktScrobbleActionType));
        }

        [Fact]
        public void Test_ITraktScrobblePostResponse_Has_Progress_Property()
        {
            var propertyInfo = typeof(ITraktScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Progress");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktScrobblePostResponse_Has_Sharing_Property()
        {
            var propertyInfo = typeof(ITraktScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Sharing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSharing));
        }
    }
}
