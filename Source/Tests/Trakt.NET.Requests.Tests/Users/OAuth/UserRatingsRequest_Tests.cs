namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserRatingsRequest_Tests
    {
        [Fact]
        public void Test_UserRatingsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserRatingsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserRatingsRequest();
            request.UriTemplate.Should().Be("users/{username}/ratings{/type}{/rating}{?extended,page,limit}");
        }

        [Fact]
        public void Test_UserRatingsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserRatingsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserRatingsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserRatingsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserRatingsRequest_TestData))]
        public void Test_UserRatingsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                            IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserRatingsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktRatingsItemType _type = TraktRatingsItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;
            private static readonly int[] _validRatingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            private static readonly int[] _invalidRatingFilter2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            private static readonly int[] _invalidRatingFilter4 = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            private static readonly int[] _invalidRatingFilter5 = new int[] { 1, 2, 3, 4, 5, 11, 7, 8, 9, 10 };

            private static readonly UserRatingsRequest _request1 = new UserRatingsRequest
            {
                Username = _username
            };

            private static readonly UserRatingsRequest _request2 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly UserRatingsRequest _request3 = new UserRatingsRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserRatingsRequest _request4 = new UserRatingsRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserRatingsRequest _request5 = new UserRatingsRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserRatingsRequest _request6 = new UserRatingsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserRatingsRequest _request7 = new UserRatingsRequest
            {
                Username = _username,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request8 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserRatingsRequest _request9 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly UserRatingsRequest _request10 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly UserRatingsRequest _request11 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserRatingsRequest _request12 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request13 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request14 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request15 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request16 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _validRatingFilter
            };

            private static readonly UserRatingsRequest _request17 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly UserRatingsRequest _request18 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly UserRatingsRequest _request19 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly UserRatingsRequest _request20 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly UserRatingsRequest _request21 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter1
            };

            private static readonly UserRatingsRequest _request22 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly UserRatingsRequest _request23 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly UserRatingsRequest _request24 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly UserRatingsRequest _request25 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly UserRatingsRequest _request26 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter2
            };

            private static readonly UserRatingsRequest _request27 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly UserRatingsRequest _request28 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly UserRatingsRequest _request29 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly UserRatingsRequest _request30 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly UserRatingsRequest _request31 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter3
            };

            private static readonly UserRatingsRequest _request32 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly UserRatingsRequest _request33 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly UserRatingsRequest _request34 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly UserRatingsRequest _request35 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly UserRatingsRequest _request36 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter4
            };

            private static readonly UserRatingsRequest _request37 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly UserRatingsRequest _request38 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly UserRatingsRequest _request39 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly UserRatingsRequest _request40 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly UserRatingsRequest _request41 = new UserRatingsRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit,
                RatingFilter = _invalidRatingFilter5
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserRatingsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();
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
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit,
                        ["rating"] = strValidRatingFilter
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request28.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request29.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request30.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request31.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request32.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request33.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request34.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request35.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request36.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request37.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                    }});

                _data.Add(new object[] { _request38.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request39.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request40.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request41.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
