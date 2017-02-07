namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserWatchedHistoryRequest_Tests
    {
        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Is_Not_Abstract()
        {
            typeof(TraktUserWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Is_Sealed()
        {
            typeof(TraktUserWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Inherits_ATraktUsersPagedGetRequest_1()
        {
            typeof(TraktUserWatchedHistoryRequest).IsSubclassOf(typeof(ATraktUsersPagedGetRequest<TraktHistoryItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_ItemId_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ItemId")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_StartAt_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartAt")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_EndAt_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EndAt")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserWatchedHistoryRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserWatchedHistoryRequest();
            request.UriTemplate.Should().Be("users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [Fact]
        public void Test_TraktUserWatchedHistoryRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserWatchedHistoryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserWatchedHistoryRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserWatchedHistoryRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserWatchedHistoryRequest_TestData))]
        public void Test_TraktUserWatchedHistoryRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserWatchedHistoryRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private const uint _id = 123;
            private static readonly DateTime _startAt = DateTime.Now;
            private static readonly DateTime _endAt = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserWatchedHistoryRequest _request1 = new TraktUserWatchedHistoryRequest
            {
                Username = _username
            };

            private static readonly TraktUserWatchedHistoryRequest _request2 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly TraktUserWatchedHistoryRequest _request3 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id
            };

            private static readonly TraktUserWatchedHistoryRequest _request4 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request5 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request6 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchedHistoryRequest _request7 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly TraktUserWatchedHistoryRequest _request8 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request9 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                ItemId = _id
            };

            private static readonly TraktUserWatchedHistoryRequest _request10 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                StartAt = _startAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request11 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                EndAt = _endAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request12 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchedHistoryRequest _request13 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly TraktUserWatchedHistoryRequest _request14 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request15 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request16 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                StartAt = _startAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request17 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                EndAt = _endAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request18 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchedHistoryRequest _request19 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Page = _page
            };

            private static readonly TraktUserWatchedHistoryRequest _request20 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request21 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                ItemId = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request22 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                EndAt = _endAt
            };

            private static readonly TraktUserWatchedHistoryRequest _request23 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchedHistoryRequest _request24 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Page = _page
            };

            private static readonly TraktUserWatchedHistoryRequest _request25 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request26 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                StartAt = _startAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request27 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchedHistoryRequest _request28 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Page = _page
            };

            private static readonly TraktUserWatchedHistoryRequest _request29 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request30 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                EndAt = _endAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request31 = new TraktUserWatchedHistoryRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchedHistoryRequest _request32 = new TraktUserWatchedHistoryRequest
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

            public TraktUserWatchedHistoryRequest_TestData()
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
