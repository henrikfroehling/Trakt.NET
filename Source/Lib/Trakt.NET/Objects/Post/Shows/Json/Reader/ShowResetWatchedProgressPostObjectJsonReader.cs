namespace TraktNet.Objects.Post.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class ShowResetWatchedProgressPostObjectJsonReader : AObjectJsonReader<ITraktShowResetWatchedProgressPost>
    {
        public override async Task<ITraktShowResetWatchedProgressPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RESET_AT:
                            {
                                Pair<bool, System.DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowResetWatchedProgressPost.ResetAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowResetWatchedProgressPost;
            }

            return await Task.FromResult(default(ITraktShowResetWatchedProgressPost));
        }
    }
}
