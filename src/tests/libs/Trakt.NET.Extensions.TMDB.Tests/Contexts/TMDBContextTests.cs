namespace TraktNET.Contexts
{
    public sealed class TMDBContextTests
    {
        private const string ReadAccessToken = "readAccessToken";

        [Fact]
        public void TestTMDBContextWithReadAccessToken()
        {
            var context = new TMDBContext(ReadAccessToken);

            context.ID.ShouldNotBeNullOrEmpty();
            context.ReadAccessToken.ShouldBe(ReadAccessToken);
        }

        [Fact]
        public void TestTMDBContextHasCorrectBaseUri()
        {
            var context = new TMDBContext(ReadAccessToken);

            context.BaseUri.AbsoluteUri.ShouldBe("https://api.themoviedb.org/3/");
        }

        [Fact]
        public void TestTMDBContextInvalidReadAccessToken()
        {
            Action act = () => _ = new TMDBContext(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TMDBContext("    ");
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TMDBContext(" id ");
            act.ShouldThrow<ArgumentException>();
        }
    }
}
