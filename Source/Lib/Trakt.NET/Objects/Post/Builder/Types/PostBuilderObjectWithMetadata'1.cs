namespace TraktNet.Objects.Post.Builder
{
    using Basic;
    using System;

    public class PostBuilderObjectWithMetadata<TObject>
    {
        public TObject Object { get; set; }

        public ITraktMetadata Metadata { get; set; }

        public DateTime? CollectedAt { get; set; }
    }
}
