namespace TraktApiSharp.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowRequestArrayJsonWriter : AArrayJsonWriter<ITraktUserFollowRequest>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktUserFollowRequest> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var userFollowRequestObjectJsonWriter = new UserFollowRequestObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktUserFollowRequest traktUserFollowRequest in objects)
                writerTasks.Add(userFollowRequestObjectJsonWriter.WriteObjectAsync(jsonWriter, traktUserFollowRequest, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
