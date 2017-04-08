﻿namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class ITraktBoxOfficeMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktBoxOfficeMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktBoxOfficeMovie>));
        }
    }
}
