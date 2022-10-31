namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.People;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CastMemberObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CastMemberObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCastMember traktCastMember = new TraktCastMember();
            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Only_Characters_Property()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Characters = new List<string>
                {
                    "Character"
                }
            };

            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be(@"{""characters"":[""Character""]}");
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Only_Person_Property()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Person = new TraktPerson
                {
                    Name = "Person",
                    Ids = new TraktPersonIds
                    {
                        Slug = "person"
                    }
                }
            };

            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be(@"{""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Characters = new List<string>
                {
                    "Character"
                },
                Person = new TraktPerson
                {
                    Name = "Person",
                    Ids = new TraktPersonIds
                    {
                        Slug = "person"
                    }
                }
            };

            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be(@"{""characters"":[""Character""],""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
        }
    }
}
