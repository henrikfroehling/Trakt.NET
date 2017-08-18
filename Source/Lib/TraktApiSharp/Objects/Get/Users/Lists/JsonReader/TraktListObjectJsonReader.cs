namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader
{
    using Enums;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.JsonReader;

    internal class TraktListObjectJsonReader : IObjectJsonReader<ITraktList>
    {
        private const string PROPERTY_NAME_NAME = "name";
        private const string PROPERTY_NAME_DESCRIPTION = "description";
        private const string PROPERTY_NAME_PRIVACY = "privacy";
        private const string PROPERTY_NAME_DISPLAY_NUMBERS = "display_numbers";
        private const string PROPERTY_NAME_ALLOW_COMMENTS = "allow_comments";
        private const string PROPERTY_NAME_SORT_BY = "sort_by";
        private const string PROPERTY_NAME_SORT_HOW = "sort_how";
        private const string PROPERTY_NAME_CREATED_AT = "created_at";
        private const string PROPERTY_NAME_UDPATED_AT = "updated_at";
        private const string PROPERTY_NAME_ITEM_COUNT = "item_count";
        private const string PROPERTY_NAME_COMMENT_COUNT = "comment_count";
        private const string PROPERTY_NAME_LIKES = "likes";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_USER = "user";

        public Task<ITraktList> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktList));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktList> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktList));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktList> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktList));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsReader = new TraktListIdsObjectJsonReader();
                var userReader = new TraktUserObjectJsonReader();
                ITraktList traktList = new TraktList();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NAME:
                            traktList.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_DESCRIPTION:
                            traktList.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_PRIVACY:
                            traktList.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktAccessScope>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_DISPLAY_NUMBERS:
                            traktList.DisplayNumbers = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_ALLOW_COMMENTS:
                            traktList.AllowComments = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SORT_BY:
                            traktList.SortBy = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SORT_HOW:
                            traktList.SortHow = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktList.CreatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_UDPATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktList.UpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_ITEM_COUNT:
                            traktList.ItemCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMMENT_COUNT:
                            traktList.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_LIKES:
                            traktList.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_IDS:
                            traktList.Ids = await idsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_USER:
                            traktList.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktList;
            }

            return await Task.FromResult(default(ITraktList));
        }
    }
}
