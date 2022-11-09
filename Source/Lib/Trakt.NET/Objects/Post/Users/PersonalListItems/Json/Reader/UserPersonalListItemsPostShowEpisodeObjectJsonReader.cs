namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class UserPersonalListItemsPostShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostShowEpisode>
    {
        public override async Task<ITraktUserPersonalListItemsPostShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserPersonalListItemsPostShowEpisode customListItemsPostShowEpisode = new TraktUserPersonalListItemsPostShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    customListItemsPostShowEpisode.Number = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostShowEpisode;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostShowEpisode));
        }
    }
}
