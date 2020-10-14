namespace TraktNet.Objects.Post.Builder
{
    internal sealed class PostBuilderObjectWithMetadataAndSeasons<TObject, TSeasons> : PostBuilderObjectWithMetadata<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
