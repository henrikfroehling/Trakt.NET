namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Scrobbles.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class TraktScrobbleStartRequest_2_Tests
    {
        [Fact]
        public void Test_TraktScrobbleStartRequest_2_IsNotAbstract()
        {
            typeof(TraktScrobbleStartRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_IsSealed()
        {
            typeof(TraktScrobbleStartRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_Has_GenericTypeParameter()
        {
            typeof(TraktScrobbleStartRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobbleStartRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktScrobbleStartRequest<int, float>).IsSubclassOf(typeof(ATraktPostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktScrobbleStartRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_Has_Valid_UriTemplate()
        {
            var request = new TraktScrobbleStartRequest<int, float>();
            request.UriTemplate.Should().Be("scrobble/start");
        }

        [Fact]
        public void Test_TraktScrobbleStartRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new TraktScrobbleStartRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
