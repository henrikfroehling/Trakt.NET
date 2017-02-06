namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserWatchedHistoryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestIsNotAbstract()
        {
            typeof(TraktUserWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestIsSealed()
        {
            typeof(TraktUserWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestIsSubclassOfATraktUsersPaginationGetRequest()
        {
            typeof(TraktUserWatchedHistoryRequest).IsSubclassOf(typeof(ATraktUsersPaginationGetRequest<TraktHistoryItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasAuthorizationOptional()
        {
            var request = new TraktUserWatchedHistoryRequest(null);
            //request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasValidUriTemplate()
        {
            var request = new TraktUserWatchedHistoryRequest(null);
            request.UriTemplate.Should().Be("users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasItemIdProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ItemId")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasStartAtProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartAt")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasEndAtProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EndAt")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserWatchedHistoryRequest).GetMethods()
                                                                   .Where(m => m.Name == "GetUriPathParameters")
                                                                   .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndType()
        {
            var username = "username";
            var type = TraktSyncItemType.Episode;

            var request = new TraktUserWatchedHistoryRequest(null)
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
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndUnspecifiedType()
        {
            var username = "username";
            var type = TraktSyncItemType.Unspecified;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndItemId()
        {
            var username = "username";
            var itemId = 123U;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                ItemId = itemId
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndValidItemId()
        {
            var username = "username";
            var type = TraktSyncItemType.Episode;
            var itemId = 123U;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndUnspecifiedTypeAndValidItemId()
        {
            var username = "username";
            var type = TraktSyncItemType.Unspecified;
            var itemId = 123U;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndInvalidItemId()
        {
            var username = "username";
            var type = TraktSyncItemType.Episode;
            var itemId = 0U;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId
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
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndStartAt()
        {
            var username = "username";
            var startAt = DateTime.Now.AddDays(-2);

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["start_at"] = startAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndEndAt()
        {
            var username = "username";
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndStartAtAndEndAt()
        {
            var username = "username";
            var startAt = DateTime.Now.AddDays(-2);
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                StartAt = startAt,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["start_at"] = startAt.ToTraktLongDateTimeString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndStartAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.Now.AddDays(-2);

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["start_at"] = startAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndEndAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndStartAtAndEndAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.Now.AddDays(-2);
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                StartAt = startAt,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(4);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["start_at"] = startAt.ToTraktLongDateTimeString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndItemIdAndStartAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.Now.AddDays(-2);

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId,
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(4);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString(),
                ["start_at"] = startAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndItemIdAndEndAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(4);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestUriParamsWithUsernameAndTypeAndItemIdAndStartAtAndEndAt()
        {
            var username = "username";
            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.Now.AddDays(-2);
            var endAt = DateTime.Now;

            var request = new TraktUserWatchedHistoryRequest(null)
            {
                Username = username,
                Type = type,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(5);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["username"] = username,
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString(),
                ["start_at"] = startAt.ToTraktLongDateTimeString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }
    }
}
