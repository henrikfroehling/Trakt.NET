namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserRatingsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Is_Sealed()
        {
            typeof(TraktUserRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserRatingsRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktRatingsItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktRatingsItemType));
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Has_RatingFilter_Property()
        {
            var propertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RatingFilter")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int[]));
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserRatingsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserRatingsRequest();
            request.UriTemplate.Should().Be("users/{username}/ratings{/type}{/rating}{?extended}");
        }

        [Fact]
        public void Test_TraktUserRatingsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserRatingsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserRatingsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserRatingsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserRatingsRequest_TestData))]
        public void Test_TraktUserRatingsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserRatingsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktRatingsItemType _type = TraktRatingsItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly int[] _validRatingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            private static readonly int[] _invalidRatingFilter2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            private static readonly int[] _invalidRatingFilter4 = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter5 = new int[] { 1, 2, 3, 4, 5, 11, 7, 8, 9, 10 };

            private static readonly TraktUserRatingsRequest _request1 = new TraktUserRatingsRequest
            {
                Username = _username
            };

            private static readonly TraktUserRatingsRequest _request2 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly TraktUserRatingsRequest _request3 = new TraktUserRatingsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserRatingsRequest _request4 = new TraktUserRatingsRequest
            {
                Username = _username,
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktUserRatingsRequest _request5 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserRatingsRequest _request6 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktUserRatingsRequest _request7 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _validRatingFilter
            };

            private static readonly TraktUserRatingsRequest _request8 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly TraktUserRatingsRequest _request9 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly TraktUserRatingsRequest _request10 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly TraktUserRatingsRequest _request11 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly TraktUserRatingsRequest _request12 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly TraktUserRatingsRequest _request13 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly TraktUserRatingsRequest _request14 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly TraktUserRatingsRequest _request15 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly TraktUserRatingsRequest _request16 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly TraktUserRatingsRequest _request17 = new TraktUserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserRatingsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strValidRatingFilter = string.Join(",", _validRatingFilter);

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
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
