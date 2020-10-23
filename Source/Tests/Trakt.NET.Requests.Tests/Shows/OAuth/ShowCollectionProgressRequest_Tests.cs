namespace TraktNet.Requests.Tests.Shows.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [Category("Requests.Shows.OAuth")]
    public class ShowCollectionProgressRequest_Tests
    {
        [Fact]
        public void Test_ShowCollectionProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowCollectionProgressRequest();
            request.UriTemplate.Should().Be("shows/{id}/progress/collection{?hidden,specials,count_specials,last_activity}");
        }

        [Theory, ClassData(typeof(ShowCollectionProgressRequest_TestData))]
        public void Test_ShowCollectionProgressRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                       IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowCollectionProgressRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const bool _hidden = true;
            private const bool _specials = true;
            private const bool _countSpecials = true;
            private static readonly TraktLastActivity _lastActivity = TraktLastActivity.Collected;

            private static readonly ShowCollectionProgressRequest _request1 = new ShowCollectionProgressRequest
            {
                Id = _id
            };

            private static readonly ShowCollectionProgressRequest _request2 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden
            };

            private static readonly ShowCollectionProgressRequest _request3 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Specials = _specials
            };

            private static readonly ShowCollectionProgressRequest _request4 = new ShowCollectionProgressRequest
            {
                Id = _id,
                CountSpecials = _countSpecials
            };

            private static readonly ShowCollectionProgressRequest _request5 = new ShowCollectionProgressRequest
            {
                Id = _id,
                LastActivity = _lastActivity
            };

            private static readonly ShowCollectionProgressRequest _request6 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials
            };

            private static readonly ShowCollectionProgressRequest _request7 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                CountSpecials = _countSpecials
            };

            private static readonly ShowCollectionProgressRequest _request8 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                LastActivity = _lastActivity
            };

            private static readonly ShowCollectionProgressRequest _request9 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowCollectionProgressRequest _request10 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Specials = _specials,
                LastActivity = _lastActivity
            };

            private static readonly ShowCollectionProgressRequest _request11 = new ShowCollectionProgressRequest
            {
                Id = _id,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly ShowCollectionProgressRequest _request12 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowCollectionProgressRequest _request13 = new ShowCollectionProgressRequest
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowCollectionProgressRequest_TestData()
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
