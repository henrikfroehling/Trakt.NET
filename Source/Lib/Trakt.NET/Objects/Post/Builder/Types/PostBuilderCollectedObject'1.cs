namespace TraktNet.Objects.Post
{
    using System;

    public class PostBuilderCollectedObject<TObject>
    {
        public TObject Object { get; set; }

        public DateTime CollectedAt { get; set; }
    }
}
