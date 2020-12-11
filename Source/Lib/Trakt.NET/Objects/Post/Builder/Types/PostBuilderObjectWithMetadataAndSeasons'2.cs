namespace TraktNet.Objects.Post
{
    public sealed class PostBuilderObjectWithMetadataAndSeasons<TObject, TSeasons> : PostBuilderObjectWithMetadata<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
