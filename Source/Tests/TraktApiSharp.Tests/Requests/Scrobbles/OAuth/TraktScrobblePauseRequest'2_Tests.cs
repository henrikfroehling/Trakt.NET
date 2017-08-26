namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Scrobbles.OAuth;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class TraktScrobblePauseRequest_2_Tests
    {
        [Fact]
        public void Test_TraktScrobblePauseRequest_2_IsNotAbstract()
        {
            typeof(TraktScrobblePauseRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_IsSealed()
        {
            typeof(TraktScrobblePauseRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_Has_GenericTypeParameter()
        {
            typeof(TraktScrobblePauseRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktScrobblePauseRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktScrobblePauseRequest<int, float>).IsSubclassOf(typeof(APostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktScrobblePauseRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_Has_Valid_UriTemplate()
        {
            var request = new TraktScrobblePauseRequest<int, float>();
            request.UriTemplate.Should().Be("scrobble/pause");
        }

        [Fact]
        public void Test_TraktScrobblePauseRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new TraktScrobblePauseRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
