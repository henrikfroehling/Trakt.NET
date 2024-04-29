namespace TraktNet.Modules.Tests.TraktNotesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Notes")]
    public partial class TraktNotesModule_Tests
    {
        private string GET_NOTE_ITEM_URI = $"notes/{NOTE_ID}/item";

        [Fact]
        public async Task Test_TraktNotesModule_GetNoteItem()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NOTE_ITEM_URI, NOTE_ITEM_POST_RESPONSE_JSON);
            TraktResponse<ITraktNoteItem> response = await client.Notes.GetNoteItemAsync(NOTE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktNotesModule_GetNoteItem_With_ExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TraktClient client = TestUtility.GetMockClient($"{GET_NOTE_ITEM_URI}?extended={extendedInfo}", NOTE_ITEM_POST_RESPONSE_JSON);
            TraktResponse <ITraktNoteItem> response = await client.Notes.GetNoteItemAsync(NOTE_ID, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData((HttpStatusCode)426, typeof(TraktFailedVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktNotesModule_GetNoteItem_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_NOTE_ITEM_URI, statusCode);

            try
            {
                await client.Notes.GetNoteItemAsync(NOTE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
