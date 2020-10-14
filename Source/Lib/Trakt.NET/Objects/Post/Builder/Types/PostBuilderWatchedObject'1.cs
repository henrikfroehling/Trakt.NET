namespace TraktNet.Objects.Post.Builder
{
    using System;

    internal class PostBuilderWatchedObject<TObject>
    {
        public TObject Object { get; set; }

        public DateTime WatchedAt { get; set; }
    }
}
