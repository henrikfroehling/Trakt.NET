namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class GenreObjectJsonReader_Tests
    {
        [Fact]
        public void Test_GenreObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(GenreObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktGenre>));
        }
    }
}
