namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.People;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CastMemberObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CastMemberObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CastMemberObjectJsonWriter();
            ITraktCastMember traktCastMember = new TraktCastMember();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCastMember);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktCastMember traktCastMember = new TraktCastMember();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastMember);
                json.Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_StringWriter_Only_Character_Property()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Character = "Character"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastMember);
                json.Should().Be(@"{""character"":""Character""}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_StringWriter_Only_Person_Property()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastMember);
                json.Should().Be(@"{""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Character = "Character",
                Person = new TraktPerson
                {
                    Name = "Person",
                    Ids = new TraktPersonIds
                    {
                        Slug = "person"
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCastMember);
                json.Should().Be(@"{""character"":""Character"",""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
            }
        }
    }
}
