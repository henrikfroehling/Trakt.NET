namespace TraktNet.Objects.Post.Builder
{
    public sealed class PostBuilderObjectWithMetadataAndSeasons<TObject, TSeasons> : PostBuilderObjectWithMetadata<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
