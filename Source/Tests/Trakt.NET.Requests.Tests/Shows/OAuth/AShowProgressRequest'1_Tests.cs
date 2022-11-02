namespace TraktNet.Requests.Tests.Shows.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows.OAuth;
    using Xunit;

    [TestCategory("Requests.Shows.OAuth")]
    public class AShowProgressRequest_1_Tests
    {
        internal class ShowProgressRequestMock : AShowProgressRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AShowProgressRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ShowProgressRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_AShowProgressRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ShowProgressRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_AShowProgressRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new ShowProgressRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            requestMock = new ShowProgressRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            requestMock = new ShowProgressRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(ShowProgressRequestMock_TestData))]
        public void Test_AShowProgressRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowProgressRequestMock_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private const bool _hidden = true;
            private const bool _specials = true;
            private const bool _countSpecials = true;
            private static readonly TraktLastActivity _lastActivity = TraktLastActivity.Collected;

            private static readonly ShowProgressRequestMock _request1 = new ShowProgressRequestMock
            {
                Id = _id
            };

            private static readonly ShowProgressRequestMock _request2 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden
            };

            private static readonly ShowProgressRequestMock _request3 = new ShowProgressRequestMock
            {
                Id = _id,
                Specials = _specials
            };

            private static readonly ShowProgressRequestMock _request4 = new ShowProgressRequestMock
            {
                Id = _id,
                CountSpecials = _countSpecials
            };

            private static readonly ShowProgressRequestMock _request5 = new ShowProgressRequestMock
            {
                Id = _id,
                LastActivity = _lastActivity
            };

            private static readonly ShowProgressRequestMock _request6 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials
            };

            private static readonly ShowProgressRequestMock _request7 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                CountSpecials = _countSpecials
            };

            private static readonly ShowProgressRequestMock _request8 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                LastActivity = _lastActivity
            };

            private static readonly ShowProgressRequestMock _request9 = new ShowProgressRequestMock
            {
                Id = _id,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowProgressRequestMock _request10 = new ShowProgressRequestMock
            {
                Id = _id,
                Specials = _specials,
                LastActivity = _lastActivity
            };

            private static readonly ShowProgressRequestMock _request11 = new ShowProgressRequestMock
            {
                Id = _id,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly ShowProgressRequestMock _request12 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials
            };

            private static readonly ShowProgressRequestMock _request13 = new ShowProgressRequestMock
            {
                Id = _id,
                Hidden = _hidden,
                Specials = _specials,
                CountSpecials = _countSpecials,
                LastActivity = _lastActivity
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowProgressRequestMock_TestData()
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
