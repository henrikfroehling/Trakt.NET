namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsNotAbstract()
        {
            typeof(TraktUserRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsSealed()
        {
            typeof(TraktUserRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserRatingsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktRatingsItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktUserRatingsRequest(null);
            request.UriTemplate.Should().Be("users/{username}/ratings{/type}{/rating}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktRatingsItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasRatingFilterProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "RatingFilter")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(int[]));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserRatingsRequest).GetMethods()
                                                            .Where(m => m.Name == "GetUriPathParameters")
                                                            .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndType()
        {
            var username = "username";
            var type = TraktRatingsItemType.Episode;

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndUnspecifiedType()
        {
            var username = "username";
            var type = TraktRatingsItemType.Unspecified;

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndRatingFilter()
        {
            var username = "username";
            var ratingFilter = new int[] { 1 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndUnspecifiedTypeAndRatingFilter()
        {
            var username = "username";
            var type = TraktRatingsItemType.Unspecified;
            var ratingFilter = new int[] { 1 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5_6()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5_6_7()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5_6_7_8()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5_6_7_8_9()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndValidRatingFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratingFilter)
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndInvalidRatingFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndInvalidRatingFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndInvalidRatingFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestUriParamsWithUsernameAndTypeAndInvalidRatingFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var username = "username";
            var type = TraktRatingsItemType.Movie;
            var ratingFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var request = new TraktUserRatingsRequest(null)
            {
                Username = username,
                Type = type,
                RatingFilter = ratingFilter
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName
            });
        }
    }
}
