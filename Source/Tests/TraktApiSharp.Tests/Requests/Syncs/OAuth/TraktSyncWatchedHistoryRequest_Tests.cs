namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchedHistoryRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<ITraktHistoryItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncWatchedHistoryRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktSyncWatchedHistoryRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchedHistoryRequest();
            request.UriTemplate.Should().Be("sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Has_ItemId_Property()
        {
            var propertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ItemId")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Has_StartAt_Property()
        {
            var propertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartAt")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRequest_Has_EndAt_Property()
        {
            var propertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EndAt")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Theory, ClassData(typeof(TraktSyncWatchedHistoryRequest_TestData))]
        public void Test_TraktSyncWatchedHistoryRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSyncWatchedHistoryRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private const uint _id = 123;
            private static readonly DateTime _startAt = DateTime.Now;
            private static readonly DateTime _endAt = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktSyncWatchedHistoryRequest _request1 = new TraktSyncWatchedHistoryRequest();

            private static readonly TraktSyncWatchedHistoryRequest _request2 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type
            };

            private static readonly TraktSyncWatchedHistoryRequest _request3 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id
            };

            private static readonly TraktSyncWatchedHistoryRequest _request4 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request5 = new TraktSyncWatchedHistoryRequest
            {
                EndAt = _endAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request6 = new TraktSyncWatchedHistoryRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchedHistoryRequest _request7 = new TraktSyncWatchedHistoryRequest
            {
                Page = _page
            };

            private static readonly TraktSyncWatchedHistoryRequest _request8 = new TraktSyncWatchedHistoryRequest
            {
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request9 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                ItemId = _id
            };

            private static readonly TraktSyncWatchedHistoryRequest _request10 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                StartAt = _startAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request11 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                EndAt = _endAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request12 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchedHistoryRequest _request13 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly TraktSyncWatchedHistoryRequest _request14 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request15 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request16 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                StartAt = _startAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request17 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                EndAt = _endAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request18 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchedHistoryRequest _request19 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                Page = _page
            };

            private static readonly TraktSyncWatchedHistoryRequest _request20 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request21 = new TraktSyncWatchedHistoryRequest
            {
                ItemId = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request22 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                EndAt = _endAt
            };

            private static readonly TraktSyncWatchedHistoryRequest _request23 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchedHistoryRequest _request24 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Page = _page
            };

            private static readonly TraktSyncWatchedHistoryRequest _request25 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request26 = new TraktSyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request27 = new TraktSyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchedHistoryRequest _request28 = new TraktSyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Page = _page
            };

            private static readonly TraktSyncWatchedHistoryRequest _request29 = new TraktSyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request30 = new TraktSyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request31 = new TraktSyncWatchedHistoryRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchedHistoryRequest _request32 = new TraktSyncWatchedHistoryRequest
            {
                Type = _type,
                ItemId = _id,
                StartAt = _startAt,
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSyncWatchedHistoryRequest_TestData()
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

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["item_id"] = strId
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt,
                        ["end_at"] = strEndAt
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_at"] = strStartAt,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["end_at"] = strEndAt,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request32.GetUriPathParameters(), new Dictionary<string, object>
                    {
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
