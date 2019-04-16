﻿namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class AUsersPagedGetRequest_1_Tests
    {
        internal class UsersPagedGetRequestMock : AUsersPagedGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AUsersPagedGetRequest_1_Has_AuthorizationRequirement_Optional()
        {
            var request = new UsersPagedGetRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Theory, ClassData(typeof(UsersPagedGetRequestMock_TestData))]
        public void Test_AUsersPagedGetRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UsersPagedGetRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UsersPagedGetRequestMock _request1 = new UsersPagedGetRequestMock();

            private static readonly UsersPagedGetRequestMock _request2 = new UsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly UsersPagedGetRequestMock _request3 = new UsersPagedGetRequestMock
            {
                Page = _page
            };

            private static readonly UsersPagedGetRequestMock _request4 = new UsersPagedGetRequestMock
            {
                Limit = _limit
            };

            private static readonly UsersPagedGetRequestMock _request5 = new UsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UsersPagedGetRequestMock _request6 = new UsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UsersPagedGetRequestMock _request7 = new UsersPagedGetRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly UsersPagedGetRequestMock _request8 = new UsersPagedGetRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UsersPagedGetRequestMock_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
