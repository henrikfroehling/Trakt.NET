namespace TraktNET.Internal.Requests
{
    // TODO Remove this file!!!
    //      This is just for debugging.
    // TODO Add source generater tests.

    [TraktGetRequest("notes/{id:string}/item", SupportsExtendedInfo = true, SupportsPagination = true, OAuthRequirement = TraktOAuthRequirement.Required)]
    internal sealed partial class TraktGetRequest
    {
        // source generator creates a sealed partial class TraktGetRequest : HttpRequestMessage
        // "id" gets an automatically generated "string" property by source generator
        // "extended" gets automatically appended to URI template by source generator
        // "extended" gets an automatically generated "TraktExtendedInfo" property by source generator
        // "page" gets automatically appended to URI template by source generator
        // "page" gets an automatically generated "int" property by source generator
        // "limit" gets automatically appended to URI template by source generator
        // "limit" gets an automatically generated "int" property by source generator
    }

    [TraktPostRequest("notes")]
    internal sealed partial class TraktPostRequest
    {
        // source generator creates a sealed partial class TraktPostRequest : HttpRequestMessage
    }

    [TraktPutRequest("notes")]
    internal sealed partial class TraktPutRequest
    {
        // source generator creates a sealed partial class TraktPutRequest : HttpRequestMessage
    }

    [TraktDeleteRequest("notes/{id}")]
    internal sealed partial class TraktDeleteRequest
    {
        // source generator creates a sealed partial class TraktDeleteRequest : HttpRequestMessage
        // "id" gets an automatically generated "string" property by source generator
    }
}
