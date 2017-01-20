namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class TraktScrobbleStopRequest_2_Tests
    {
        [Fact]
        public void Test_TraktScrobbleStopRequest_2_IsNotAbstract()
        {
            typeof(TraktScrobbleStopRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_IsSealed()
        {
            typeof(TraktScrobbleStopRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_Has_GenericTypeParameter()
        {
            typeof(TraktScrobbleStopRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobbleStopRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktScrobbleStopRequest<int, float>).IsSubclassOf(typeof(ATraktPostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktScrobbleStopRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_Has_Valid_UriTemplate()
        {
            var request = new TraktScrobbleStopRequest<int, float>();
            request.UriTemplate.Should().Be("scrobble/stop");
        }

        [Fact]
        public void Test_TraktScrobbleStopRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new TraktScrobbleStopRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
