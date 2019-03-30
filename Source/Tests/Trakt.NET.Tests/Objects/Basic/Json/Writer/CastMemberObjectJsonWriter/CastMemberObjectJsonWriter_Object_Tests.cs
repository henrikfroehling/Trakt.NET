namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.People;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CastMemberObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CastMemberObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CastMemberObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
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
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_Object_Only_Character_Property()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Character = "Character"
            };

            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be(@"{""character"":""Character""}");
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

            var traktJsonWriter = new CastMemberObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCastMember);
            json.Should().Be(@"{""character"":""Character"",""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
        }
    }
}
