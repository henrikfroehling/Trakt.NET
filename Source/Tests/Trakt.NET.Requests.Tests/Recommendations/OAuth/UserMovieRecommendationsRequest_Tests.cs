namespace TraktNet.Requests.Tests.Recommendations.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Recommendations.OAuth;
    using Xunit;

    [TestCategory("Requests.Recommendations.OAuth")]
    public class UserMovieRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_UserMovieRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserMovieRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserMovieRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserMovieRecommendationsRequest();
            request.UriTemplate.Should().Be("recommendations/movies{?extended,limit,ignore_collected,ignore_watchlisted}");
        }

        [Theory, ClassData(typeof(UserMovieRecommendationsRequest_TestData))]
        public void Test_UserMovieRecommendationsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                         IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserMovieRecommendationsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _limit = 20;
            private const bool _ignoreCollected = true;
            private const bool _ignoreWatchlisted = true;

            private static readonly UserMovieRecommendationsRequest _request1 = new UserMovieRecommendationsRequest();

            private static readonly UserMovieRecommendationsRequest _request2 = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserMovieRecommendationsRequest _request3 = new UserMovieRecommendationsRequest
            {
                Limit = _limit
            };

            private static readonly UserMovieRecommendationsRequest _request4 = new UserMovieRecommendationsRequest
            {
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserMovieRecommendationsRequest _request5 = new UserMovieRecommendationsRequest
            {
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserMovieRecommendationsRequest _request6 = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserMovieRecommendationsRequest _request7 = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserMovieRecommendationsRequest _request8 = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserMovieRecommendationsRequest _request9 = new UserMovieRecommendationsRequest
            {
                Limit = _limit,
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserMovieRecommendationsRequest _request10 = new UserMovieRecommendationsRequest
            {
                Limit = _limit,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserMovieRecommendationsRequest _request11 = new UserMovieRecommendationsRequest
            {
                Limit = _limit,
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserMovieRecommendationsRequest _request12 = new UserMovieRecommendationsRequest
            {
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserMovieRecommendationsRequest _request13 = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserMovieRecommendationsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var strLimit = _limit.ToString();
                var strIgnoreCollected = "true";
                var strIgnoreWatchlisted = "true";

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["ignore_collected"] = strIgnoreCollected
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit,
                        ["ignore_collected"] = strIgnoreCollected
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit,
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit,
                        ["ignore_collected"] = strIgnoreCollected
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit,
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit,
                        ["ignore_collected"] = strIgnoreCollected,
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["ignore_collected"] = strIgnoreCollected,
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit,
                        ["ignore_collected"] = strIgnoreCollected,
                        ["ignore_watchlisted"] = strIgnoreWatchlisted
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
