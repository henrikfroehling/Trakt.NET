namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentReplyPostObjectJsonReader : AObjectJsonReader<ITraktCommentReplyPost>
    {
        public override async Task<ITraktCommentReplyPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCommentReplyPost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCommentReplyPost commentReplyPost = new TraktCommentReplyPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            commentReplyPost.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            {
                                bool? value = await jsonReader.ReadAsBooleanAsync(cancellationToken);

                                if (value.HasValue)
                                    commentReplyPost.Spoiler = value.Value;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return commentReplyPost;
            }

            return await Task.FromResult(default(ITraktCommentReplyPost));
        }
    }
}
