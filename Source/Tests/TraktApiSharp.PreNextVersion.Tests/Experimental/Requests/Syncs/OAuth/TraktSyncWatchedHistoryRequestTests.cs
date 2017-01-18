namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncWatchedHistoryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsSealed()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsSubclassOfATraktSyncPaginationGetRequest()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSubclassOf(typeof(ATraktSyncPaginationGetRequest<TraktHistoryItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncWatchedHistoryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchedHistoryRequest(null);
            request.UriTemplate.Should().Be("sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasItemIdProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ItemId")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasStartAtProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartAt")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasEndAtProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EndAt")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSyncWatchedHistoryRequest).GetMethods()
                                                                   .Where(m => m.Name == "GetUriPathParameters")
                                                                   .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithoutAnyParameters()
        {
            var request = new TraktSyncWatchedHistoryRequest(null);
            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithUnspecifiedType()
        {
            var type = TraktSyncItemType.Unspecified;

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithType()
        {
            var type = TraktSyncItemType.Episode;

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("type", type.UriName);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithItemIdAndWithoutType()
        {
            var itemId = 1394U;

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                ItemId = itemId
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithItemIdAndWithType()
        {
            var type = TraktSyncItemType.Show;
            var itemId = 1394U;

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                ItemId = itemId,
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithStartAt()
        {
            var startAt = new DateTime(2016, 11, 1);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_at", startAt.ToTraktLongDateTimeString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithEndAt()
        {
            var endAt = new DateTime(2016, 11, 30);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("end_at", endAt.ToTraktLongDateTimeString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithTypeAndStartAt()
        {
            var type = TraktSyncItemType.Episode;
            var startAt = new DateTime(2016, 11, 1);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                Type = type,
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["start_at"] = startAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithTypeAndEndAt()
        {
            var type = TraktSyncItemType.Episode;
            var endAt = new DateTime(2016, 11, 30);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                Type = type,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithItemIdAndWithTypeAndStartAt()
        {
            var type = TraktSyncItemType.Show;
            var itemId = 1394U;
            var startAt = new DateTime(2016, 11, 1);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                ItemId = itemId,
                Type = type,
                StartAt = startAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString(),
                ["start_at"] = startAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithItemIdAndWithTypeAndEndAt()
        {
            var type = TraktSyncItemType.Show;
            var itemId = 1394U;
            var endAt = new DateTime(2016, 11, 30);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                ItemId = itemId,
                Type = type,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["item_id"] = itemId.ToString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithStartAtAndEndAt()
        {
            var startAt = new DateTime(2016, 11, 1);
            var endAt = new DateTime(2016, 11, 30);

            var request = new TraktSyncWatchedHistoryRequest(null)
            {
                StartAt = startAt,
                EndAt = endAt
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["start_at"] = startAt.ToTraktLongDateTimeString(),
                ["end_at"] = endAt.ToTraktLongDateTimeString()
            });
        }
    }
}
