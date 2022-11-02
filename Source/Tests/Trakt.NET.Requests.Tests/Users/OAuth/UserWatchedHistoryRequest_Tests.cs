namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserWatchedHistoryRequest_Tests
    {
        [Fact]
        public void Test_UserWatchedHistoryRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserWatchedHistoryRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserWatchedHistoryRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchedHistoryRequest();
            request.UriTemplate.Should().Be("users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [Fact]
        public void Test_UserWatchedHistoryRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchedHistoryRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserWatchedHistoryRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserWatchedHistoryRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserWatchedHistoryRequest_TestData))]
        public void Test_UserWatchedHistoryRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserWatchedHistoryRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private const uint _id = 123;
            private static readonly DateTime _startAt = DateTime.Now;
            private static readonly DateTime _endAt = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserWatchedHistoryRequest _request1 = new UserWatchedHistoryRequest
            {
                Username = _username
            };

            private static readonly UserWatchedHistoryRequest _request2 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly UserWatchedHistoryRequest _request3 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id
            };

            private static readonly UserWatchedHistoryRequest _request4 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt
            };

            private static readonly UserWatchedHistoryRequest _request5 = new UserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt
            };

            private static readonly UserWatchedHistoryRequest _request6 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchedHistoryRequest _request7 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserWatchedHistoryRequest _request8 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request9 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                ItemId = _id
            };

            private static readonly UserWatchedHistoryRequest _request10 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                StartAt = _startAt
            };

            private static readonly UserWatchedHistoryRequest _request11 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                EndAt = _endAt
            };

            private static readonly UserWatchedHistoryRequest _request12 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchedHistoryRequest _request13 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly UserWatchedHistoryRequest _request14 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request15 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request16 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                StartAt = _startAt
            };

            private static readonly UserWatchedHistoryRequest _request17 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                EndAt = _endAt
            };

            private static readonly UserWatchedHistoryRequest _request18 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchedHistoryRequest _request19 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Page = _page
            };

            private static readonly UserWatchedHistoryRequest _request20 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request21 = new UserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request22 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                EndAt = _endAt
            };

            private static readonly UserWatchedHistoryRequest _request23 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchedHistoryRequest _request24 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Page = _page
            };

            private static readonly UserWatchedHistoryRequest _request25 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request26 = new UserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request27 = new UserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchedHistoryRequest _request28 = new UserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Page = _page
            };

            private static readonly UserWatchedHistoryRequest _request29 = new UserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request30 = new UserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request31 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchedHistoryRequest _request32 = new UserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                ItemId = _id,
                StartAt = _startAt,
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserWatchedHistoryRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strId = _id.ToString();
                var strStartAt = _startAt.ToTraktLongDateTimeString();
                var strEndAt = _endAt.ToTraktLongDateTimeString();
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["item_id"] = strId
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["start_at"] = strStartAt,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["end_at"] = strEndAt,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request32.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["item_id"] = strId,
                        ["start_at"] = strStartAt,
                        ["end_at"] = strEndAt,
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
