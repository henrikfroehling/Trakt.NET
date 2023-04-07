namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendedByObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_RecommendedByObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new RecommendedByObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonWriter_WriteObject_Only_User_Property()
        {
            ITraktRecommendedBy traktRecommendedBy = new TraktRecommendedBy
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
                    },
                    Location = "SF",
                    About = "I have all your cassette tapes.",
                    Age = 35,
                    Gender = "male"
                }
            };

            var traktJsonWriter = new RecommendedByObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedBy);
            json.Should().Be(@"{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}}");
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonWriter_WriteObject_Only_Notes_Property()
        {
            ITraktRecommendedBy traktRecommendedBy = new TraktRecommendedBy
            {
                Notes = "Recommended because ..."
            };

            var traktJsonWriter = new RecommendedByObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedBy);
            json.Should().Be(@"{""notes"":""Recommended because ...""}");
        }

        [Fact]
        public async Task Test_RecommendedByObjectJsonWriter_WriteObject_Complete()
        {
            ITraktRecommendedBy traktRecommendedBy = new TraktRecommendedBy
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
                    },
                    Location = "SF",
                    About = "I have all your cassette tapes.",
                    Age = 35,
                    Gender = "male"
                },
                Notes = "Recommended because ..."
            };

            var traktJsonWriter = new RecommendedByObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendedBy);
            json.Should().Be(@"{""user"":{""username"":""sean"",""private"":false," +
                             @"""ids"":{""slug"":""sean"",""uuid"":""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true,""location"":""SF""," +
                             @"""about"":""I have all your cassette tapes."",""gender"":""male"",""age"":35}," +
                             @"""notes"":""Recommended because ...""}");
        }
    }
}
