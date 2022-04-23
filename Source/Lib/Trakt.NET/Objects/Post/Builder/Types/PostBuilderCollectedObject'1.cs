namespace TraktNet.Objects.Post
{
    using System;

    internal class PostBuilderCollectedObject<TObject>
    {
        public TObject Object { get; set; }

        public DateTime CollectedAt { get; set; }
    }
}
