namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.Implementations")]
    public class TraktScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_TraktScrobblePostResponse_Implements_ITraktScrobblePostResponse_Interface()
        {
            typeof(TraktScrobblePostResponse).GetInterfaces().Should().Contain(typeof(ITraktScrobblePostResponse));
        }
    }
}
