namespace TraktNet.Objects.Post.Users.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListPostObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListPost>
    {
        public override async Task<ITraktUserPersonalListPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserPersonalListPost userPersonalListPost = new TraktUserPersonalListPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NAME:
                            userPersonalListPost.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DESCRIPTION:
                            userPersonalListPost.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVACY:
                            userPersonalListPost.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktAccessScope>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DISPLAY_NUMBERS:
                            userPersonalListPost.DisplayNumbers = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ALLOW_COMMENTS:
                            userPersonalListPost.AllowComments = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_BY:
                            userPersonalListPost.SortBy = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_HOW:
                            userPersonalListPost.SortHow = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userPersonalListPost;
            }

            return await Task.FromResult(default(ITraktUserPersonalListPost));
        }
    }
}
