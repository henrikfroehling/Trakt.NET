﻿namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public void Test_CastMemberObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CastMemberObjectJsonWriter();
            ITraktCastMember traktCastMember = new TraktCastMember();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCastMember);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktCastMember traktCastMember = new TraktCastMember();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCastMember);
                stringWriter.ToString().Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_JsonWriter_Only_Character_Property()
        {
            ITraktCastMember traktCastMember = new TraktCastMember
            {
                Character = "Character"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCastMember);
                stringWriter.ToString().Should().Be(@"{""character"":""Character""}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_JsonWriter_Only_Person_Property()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCastMember);
                stringWriter.ToString().Should().Be(@"{""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonWriter_WriteObject_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CastMemberObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCastMember);
                stringWriter.ToString().Should().Be(@"{""character"":""Character"",""person"":{""name"":""Person"",""ids"":{""trakt"":0,""slug"":""person""}}}");
            }
        }
    }
}
