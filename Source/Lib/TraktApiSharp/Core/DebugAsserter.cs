namespace TraktNet.Core
{
    using Objects.Json;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Http;

    internal static class DebugAsserter
    {
        internal const string NO_CONTENT_RESPONSE_PRECONDITION_INVALID_STATUS_CODE = "precondition for generating no content response failed: invalid status code";
        internal const string SINGLE_ITEM_RESPONSE_PRECONDITION_INVALID_STATUS_CODE = "precondition for generating single item response failed: invalid status code";
        internal const string LIST_RESPONSE_PRECONDITION_INVALID_STATUS_CODE = "precondition for generating list response failed: invalid status code";
        internal const string PAGED_LIST_RESPONSE_PRECONDITION_INVALID_STATUS_CODE = "precondition for generating paged list response failed: invalid status code";

        internal static void AssertResponseMessageIsNotNull(HttpResponseMessage responseMessage)
            => Debug.Assert(responseMessage != null, "response message is null");

        internal static void AssertHttpResponseCodeIsExpected(HttpStatusCode actualStatusCode, HttpStatusCode expectedStatusCode, string assertionMessage)
            => Debug.Assert(actualStatusCode == expectedStatusCode, assertionMessage);

        internal static void AssertHttpResponseCodeIsNotExpected(HttpStatusCode actualStatusCode, HttpStatusCode expectedStatusCode, string assertionMessage)
            => Debug.Assert(actualStatusCode != expectedStatusCode, assertionMessage);

        internal static void AssertResponseContentStreamIsNotNull(Stream stream)
            => Debug.Assert(stream != null, "precondition for deserializing response content failed: stream is null");

        internal static void AssertObjectJsonReaderIsNotNull<TReturnType>(IObjectJsonReader<TReturnType> objectJsonReader)
            => Debug.Assert(objectJsonReader != null, "precondition for deserializing response content failed: json object reader is null");

        internal static void AssertArrayJsonReaderIsNotNull<TReturnType>(IArrayJsonReader<TReturnType> arrayJsonReader)
            => Debug.Assert(arrayJsonReader != null, "precondition for deserializing response content failed: json array reader is null");
    }
}
