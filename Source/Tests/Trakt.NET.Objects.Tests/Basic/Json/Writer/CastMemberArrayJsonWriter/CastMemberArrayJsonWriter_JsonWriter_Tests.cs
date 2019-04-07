namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        public void Test_CastMemberArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
            IEnumerable<ITraktCastMember> traktCastMembers = new List<TraktCastMember>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCastMembers);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<TraktCastMember>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCastMembers);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<ITraktCastMember>
            {
                new TraktCastMember
                {
                    Character = "Character 1",
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCastMembers);
                stringWriter.ToString().Should().Be(@"[{""character"":""Character 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}]");
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCastMember> traktCastMembers = new List<ITraktCastMember>
            {
                new TraktCastMember
                {
                    Character = "Character 1",
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
                    Character = "Character 2",
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCastMembers);
                stringWriter.ToString().Should().Be(@"[{""character"":""Character 1"",""person"":{""name"":""Person 1"",""ids"":{""trakt"":0,""slug"":""person-1""}}}," +
                                                    @"{""character"":""Character 2"",""person"":{""name"":""Person 2"",""ids"":{""trakt"":0,""slug"":""person-2""}}}]");
            }
        }
    }
}
