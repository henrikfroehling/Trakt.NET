namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CheckinPostErrorResponseArrayJsonReader : ArrayJsonReader<ITraktCheckinPostErrorResponse>
    {
        public override async Task<IEnumerable<ITraktCheckinPostErrorResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCheckinPostErrorResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var checkinPostErrorResponseReader = new CheckinPostErrorResponseObjectJsonReader();
                var checkinPostErrorResponses = new List<ITraktCheckinPostErrorResponse>();
                ITraktCheckinPostErrorResponse checkinPostErrorResponse = await checkinPostErrorResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (checkinPostErrorResponse != null)
                {
                    checkinPostErrorResponses.Add(checkinPostErrorResponse);
                    checkinPostErrorResponse = await checkinPostErrorResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return checkinPostErrorResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCheckinPostErrorResponse>));
        }
    }
}
