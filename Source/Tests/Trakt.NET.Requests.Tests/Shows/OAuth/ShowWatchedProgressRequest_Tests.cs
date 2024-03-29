﻿namespace TraktNet.Requests.Tests.Shows.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [TestCategory("Requests.Shows.OAuth")]
    public class ShowWatchedProgressRequest_Tests
    {
        [Fact]
        public void Test_ShowWatchedProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowWatchedProgressRequest();
            request.UriTemplate.Should().Be("shows/{id}/progress/watched{?hidden,specials,count_specials,last_activity}");
        }

        [Theory, ClassData(typeof(ShowWatchedProgressRequest_TestData))]
        public void Test_ShowWatchedProgressRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowWatchedProgressRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const bool _hidden = true;
            private const bool _specials = true;
            private const bool _countSpecials = true;
            private static readonly TraktLastActivity _lastActivity = TraktLastActivity.Collected;

            private static readonly ShowWatchedProgressRequest _request1 = new ShowWatchedProgressRequest
            {
                Id = _id
            };

            private static readonly ShowWatchedProgressRequest _request2 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden
            };

            private static readonly ShowWatchedProgressRequest _request3 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Specials = _specials
            };

            private static readonly ShowWatchedProgressRequest _request4 = new ShowWatchedProgressRequest
            {
                Id = _id,
                CountSpecials = _countSpecials
            };

            private static readonly ShowWatchedProgressRequest _request5 = new ShowWatchedProgressRequest
            {
                Id = _id,
                LastActivity = _lastActivity
            };

            private static readonly ShowWatchedProgressRequest _request6 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials
            };

            private static readonly ShowWatchedProgressRequest _request7 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                CountSpecials = _countSpecials
            };

            private static readonly ShowWatchedProgressRequest _request8 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                LastActivity = _lastActivity
            };

            private static readonly ShowWatchedProgressRequest _request9 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowWatchedProgressRequest _request10 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Specials = _specials,
                LastActivity = _lastActivity
            };

            private static readonly ShowWatchedProgressRequest _request11 = new ShowWatchedProgressRequest
            {
                Id = _id,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly ShowWatchedProgressRequest _request12 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowWatchedProgressRequest _request13 = new ShowWatchedProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowWatchedProgressRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strHidden = _hidden.ToString().ToLower();
                var strSpecials = _specials.ToString().ToLower();
                var strCountSpecials = _countSpecials.ToString().ToLower();
                var strLastActivity = _lastActivity.UriName;

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["specials"] = strSpecials
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["last_activity"] = strLastActivity
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["specials"] = strSpecials
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["last_activity"] = strLastActivity
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["specials"] = strSpecials,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["specials"] = strSpecials,
                        ["last_activity"] = strLastActivity
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["count_specials"] = strCountSpecials,
                        ["last_activity"] = strLastActivity
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["specials"] = strSpecials,
                        ["count_specials"] = strCountSpecials
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["hidden"] = strHidden,
                        ["specials"] = strSpecials,
                        ["count_specials"] = strCountSpecials,
                        ["last_activity"] = strLastActivity
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
