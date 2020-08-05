namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CastMemberArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CastMemberArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<TraktCastMember>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCastMembers);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<ITraktCastMember>
            {
                new TraktCastMember
                {
                    Characters = new List<string>
                    {
                        "Character 1"
                    },
                    Person = new TraktPerson
                    {
                        Name = "Person 1",
                        Ids = new TraktPersonIds
                        {
                            Slug = "person-1"
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCastMembers);
            json.Should().Be(@"[{""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}]");
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<ITraktCastMember>
            {
                new TraktCastMember
                {
                    Characters = new List<string>
                    {
                        "Character 1"
                    },
                    Person = new TraktPerson
                    {
                        Name = "Person 1",
                        Ids = new TraktPersonIds
                        {
                            Slug = "person-1"
                        }
                    }
                },
                new TraktCastMember
                {
                    Characters = new List<string>
                    {
                        "Character 2"
                    },
                    Person = new TraktPerson
                    {
                        Name = "Person 2",
                        Ids = new TraktPersonIds
                        {
                            Slug = "person-2"
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCastMembers);
            json.Should().Be(@"[{""characters"":[""Character 1""],""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                             @"{""characters"":[""Character 2""],""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]");
        }
    }
}
