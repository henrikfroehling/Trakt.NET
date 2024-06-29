namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktPostRequestGeneratorTests
    {
        [Fact]
        public Task TestGeneratePostRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequest", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsExtendedInfo = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestExtendedInfo", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestPagination", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestOAuth", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestAll", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameter", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithNullableParameter()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string?}")]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestNullableParameter", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterExtendedInfo()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsExtendedInfo = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterExtendedInfo", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterPagination()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsPagination = true)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterPagination", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterOAuthRequirement()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterOAuth", source, RequestTestType.PostRequest);
        }

        [Fact]
        public Task TestGeneratePostRequestWithParameterAll()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktPostRequest("notes/{id:string}", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
                    public sealed partial class TestPostRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktPostRequestSourceGenerator>("Requests", "SourceGeneration.PostRequestParameterAll", source, RequestTestType.PostRequest);
        }
    }
}
