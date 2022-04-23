﻿namespace TraktNet.Objects.Post.Comments.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentPostResponseObjectJsonWriter : ACommentObjectJsonWriter<ITraktCommentPostResponse>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktCommentPostResponse obj, CancellationToken cancellationToken = default)
        {
            await base.WriteCommentObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
