﻿namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostShowEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktUserPersonalListItemsPostShowEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserPersonalListItemsPostShowEpisode obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
