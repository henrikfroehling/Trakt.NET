namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Get.Users.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCommentObjectJsonReader : IObjectJsonReader<ITraktComment>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_PARENT_ID = "parent_id";
        private const string PROPERTY_NAME_CREATED_AT = "created_at";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_COMMENT = "comment";
        private const string PROPERTY_NAME_SPOILER = "spoiler";
        private const string PROPERTY_NAME_REVIEW = "review";
        private const string PROPERTY_NAME_REPLIES = "replies";
        private const string PROPERTY_NAME_LIKES = "likes";
        private const string PROPERTY_NAME_USER_RATING = "user_rating";
        private const string PROPERTY_NAME_USER = "user";

        public Task<ITraktComment> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktComment));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktComment> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktComment));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktComment> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktComment));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new TraktUserObjectJsonReader();
                ITraktComment traktComment = new TraktComment();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_PARENT_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.ParentId = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.CreatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.UpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_COMMENT:
                            traktComment.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SPOILER:
                            traktComment.Spoiler = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_REVIEW:
                            traktComment.Review = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_REPLIES:
                            traktComment.Replies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_LIKES:
                            traktComment.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_USER_RATING:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.UserRating = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_USER:
                            traktComment.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktComment;
            }

            return await Task.FromResult(default(ITraktComment));
        }
    }
}
