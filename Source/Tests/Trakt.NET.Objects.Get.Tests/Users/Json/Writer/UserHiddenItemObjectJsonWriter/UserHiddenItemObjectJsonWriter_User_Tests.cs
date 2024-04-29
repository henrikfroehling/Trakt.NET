namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class UserHiddenItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_User_WriteObject_Object_Only_HiddenAt_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_User_WriteObject_Object_Only_Type_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                Type = TraktHiddenItemType.User
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""type"":""user""}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_User_WriteObject_Object_Only_User_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = true,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean",
                        UUID = "3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070"
                    }
                }
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean""," +
                             @"""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_User_WriteObject_Object_Complete()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT,
                Type = TraktHiddenItemType.User,
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = true,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean",
                        UUID = "3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070"
                    }
                }
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""user""," +
                             @"""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean""," +
                             @"""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
        }
    }
}
