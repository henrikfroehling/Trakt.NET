namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncRatingsRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Is_Sealed()
        {
            typeof(TraktSyncRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncRatingsRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktRatingsItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncRatingsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncRatingsRequest();
            request.UriTemplate.Should().Be("sync/ratings{/type}{/rating}{?extended}");
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Has_Type_Property()
        {
            var sortingPropertyInfo = typeof(TraktSyncRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktRatingsItemType));
        }

        [Fact]
        public void Test_TraktSyncRatingsRequest_Has_RatingFilter_Property()
        {
            var sortingPropertyInfo = typeof(TraktSyncRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RatingFilter")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(int[]));
        }

        [Theory, ClassData(typeof(TraktSyncRatingsRequest_TestData))]
        public void Test_TraktSyncRatingsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSyncRatingsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktRatingsItemType _type = TraktRatingsItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly int[] _validRatingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            private static readonly int[] _invalidRatingFilter2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            private static readonly int[] _invalidRatingFilter4 = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter5 = new int[] { 1, 2, 3, 4, 5, 11, 7, 8, 9, 10 };

            private static readonly TraktSyncRatingsRequest _request1 = new TraktSyncRatingsRequest();

            private static readonly TraktSyncRatingsRequest _request2 = new TraktSyncRatingsRequest
            {
                Type = _type
            };

            private static readonly TraktSyncRatingsRequest _request3 = new TraktSyncRatingsRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncRatingsRequest _request4 = new TraktSyncRatingsRequest
            {
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktSyncRatingsRequest _request5 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncRatingsRequest _request6 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktSyncRatingsRequest _request7 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktSyncRatingsRequest _request8 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly TraktSyncRatingsRequest _request9 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly TraktSyncRatingsRequest _request10 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly TraktSyncRatingsRequest _request11 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly TraktSyncRatingsRequest _request12 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly TraktSyncRatingsRequest _request13 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly TraktSyncRatingsRequest _request14 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly TraktSyncRatingsRequest _request15 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly TraktSyncRatingsRequest _request16 = new TraktSyncRatingsRequest
            {
                Type = _type,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly TraktSyncRatingsRequest _request17 = new TraktSyncRatingsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSyncRatingsRequest_TestData()
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
