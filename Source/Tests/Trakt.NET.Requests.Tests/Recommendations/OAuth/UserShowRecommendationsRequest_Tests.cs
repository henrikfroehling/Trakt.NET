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
    public class UserShowRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_UserShowRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserShowRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserShowRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserShowRecommendationsRequest();
            request.UriTemplate.Should().Be("recommendations/shows{?extended,limit,ignore_collected,ignore_watchlisted}");
        }

        [Theory, ClassData(typeof(UserShowRecommendationsRequest_TestData))]
        public void Test_UserShowRecommendationsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserShowRecommendationsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _limit = 20;
            private const bool _ignoreCollected = true;
            private const bool _ignoreWatchlisted = true;

            private static readonly UserShowRecommendationsRequest _request1 = new UserShowRecommendationsRequest();

            private static readonly UserShowRecommendationsRequest _request2 = new UserShowRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserShowRecommendationsRequest _request3 = new UserShowRecommendationsRequest
            {
                Limit = _limit
            };

            private static readonly UserShowRecommendationsRequest _request4 = new UserShowRecommendationsRequest
            {
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserShowRecommendationsRequest _request5 = new UserShowRecommendationsRequest
            {
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserShowRecommendationsRequest _request6 = new UserShowRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserShowRecommendationsRequest _request7 = new UserShowRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserShowRecommendationsRequest _request8 = new UserShowRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserShowRecommendationsRequest _request9 = new UserShowRecommendationsRequest
            {
                Limit = _limit,
                IgnoreCollected = _ignoreCollected
            };

            private static readonly UserShowRecommendationsRequest _request10 = new UserShowRecommendationsRequest
            {
                Limit = _limit,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserShowRecommendationsRequest _request11 = new UserShowRecommendationsRequest
            {
                Limit = _limit,
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserShowRecommendationsRequest _request12 = new UserShowRecommendationsRequest
            {
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly UserShowRecommendationsRequest _request13 = new UserShowRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit,
                IgnoreCollected = _ignoreCollected,
                IgnoreWatchlisted = _ignoreWatchlisted
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserShowRecommendationsRequest_TestData()
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
