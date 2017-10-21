namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryRequest();
            request.UriTemplate.Should().Be("sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [Theory, ClassData(typeof(SyncWatchedHistoryRequest_TestData))]
        public void Test_SyncWatchedHistoryRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SyncWatchedHistoryRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private const uint _id = 123;
            private static readonly DateTime _startAt = DateTime.Now;
            private static readonly DateTime _endAt = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly SyncWatchedHistoryRequest _request1 = new SyncWatchedHistoryRequest();

            private static readonly SyncWatchedHistoryRequest _request2 = new SyncWatchedHistoryRequest
            {
                Type = _type
            };

            private static readonly SyncWatchedHistoryRequest _request3 = new SyncWatchedHistoryRequest
            {
                ItemId = _id
            };

            private static readonly SyncWatchedHistoryRequest _request4 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt
            };

            private static readonly SyncWatchedHistoryRequest _request5 = new SyncWatchedHistoryRequest
            {
                EndAt = _endAt
            };

            private static readonly SyncWatchedHistoryRequest _request6 = new SyncWatchedHistoryRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchedHistoryRequest _request7 = new SyncWatchedHistoryRequest
            {
                Page = _page
            };

            private static readonly SyncWatchedHistoryRequest _request8 = new SyncWatchedHistoryRequest
            {
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request9 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                ItemId = _id
            };

            private static readonly SyncWatchedHistoryRequest _request10 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                StartAt = _startAt
            };

            private static readonly SyncWatchedHistoryRequest _request11 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                EndAt = _endAt
            };

            private static readonly SyncWatchedHistoryRequest _request12 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchedHistoryRequest _request13 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly SyncWatchedHistoryRequest _request14 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request15 = new SyncWatchedHistoryRequest
            {
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request16 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                StartAt = _startAt
            };

            private static readonly SyncWatchedHistoryRequest _request17 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                EndAt = _endAt
            };

            private static readonly SyncWatchedHistoryRequest _request18 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchedHistoryRequest _request19 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                Page = _page
            };

            private static readonly SyncWatchedHistoryRequest _request20 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request21 = new SyncWatchedHistoryRequest
            {
                ItemId = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request22 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                EndAt = _endAt
            };

            private static readonly SyncWatchedHistoryRequest _request23 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchedHistoryRequest _request24 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Page = _page
            };

            private static readonly SyncWatchedHistoryRequest _request25 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request26 = new SyncWatchedHistoryRequest
            {
                StartAt = _startAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request27 = new SyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchedHistoryRequest _request28 = new SyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Page = _page
            };

            private static readonly SyncWatchedHistoryRequest _request29 = new SyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request30 = new SyncWatchedHistoryRequest
            {
                EndAt = _endAt,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request31 = new SyncWatchedHistoryRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchedHistoryRequest _request32 = new SyncWatchedHistoryRequest
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

            public SyncWatchedHistoryRequest_TestData()
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
