namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncRatingsRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsRequest();
            request.UriTemplate.Should().Be("sync/ratings{/type}{/rating}{?extended}");
        }

        [Theory, ClassData(typeof(SyncRatingsRequest_TestData))]
        public void Test_SyncRatingsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                            IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SyncRatingsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktRatingsItemType _type = TraktRatingsItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly int[] _validRatingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            private static readonly int[] _invalidRatingFilter2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            private static readonly int[] _invalidRatingFilter4 = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter5 = new int[] { 1, 2, 3, 4, 5, 11, 7, 8, 9, 10 };

            private static readonly SyncRatingsRequest _request1 = new SyncRatingsRequest();

            private static readonly SyncRatingsRequest _request2 = new SyncRatingsRequest
            {
                Type = _type
            };

            private static readonly SyncRatingsRequest _request3 = new SyncRatingsRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncRatingsRequest _request4 = new SyncRatingsRequest
            {
                RatingFilter = _validRatingFilter
            };

            private static readonly SyncRatingsRequest _request5 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncRatingsRequest _request6 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _validRatingFilter
            };

            private static readonly SyncRatingsRequest _request7 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _validRatingFilter
            };

            private static readonly SyncRatingsRequest _request8 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly SyncRatingsRequest _request9 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly SyncRatingsRequest _request10 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly SyncRatingsRequest _request11 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly SyncRatingsRequest _request12 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly SyncRatingsRequest _request13 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly SyncRatingsRequest _request14 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly SyncRatingsRequest _request15 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly SyncRatingsRequest _request16 = new SyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly SyncRatingsRequest _request17 = new SyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SyncRatingsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strValidRatingFilter = string.Join(",", _validRatingFilter);

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
