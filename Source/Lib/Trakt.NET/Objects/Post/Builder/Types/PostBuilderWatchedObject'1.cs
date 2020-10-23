namespace TraktNet.Objects.Post.Builder
{
    using System;

    public class PostBuilderWatchedObject<TObject>
    {
        public TObject Object { get; set; }

        public DateTime WatchedAt { get; set; }
    }
}
