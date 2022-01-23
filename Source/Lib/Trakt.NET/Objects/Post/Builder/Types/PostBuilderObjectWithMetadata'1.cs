namespace TraktNet.Objects.Post
{
    using Basic;
    using System;

    internal class PostBuilderObjectWithMetadata<TObject>
    {
        public TObject Object { get; set; }

        public ITraktMetadata Metadata { get; set; }

        public DateTime? CollectedAt { get; set; }
    }
}
