namespace TraktNet.Objects.Post
{
    using System;

    public class PostBuilderWatchedObject<TObject>
    {
        public TObject Object { get; set; }

        public DateTime WatchedAt { get; set; }
    }
}
