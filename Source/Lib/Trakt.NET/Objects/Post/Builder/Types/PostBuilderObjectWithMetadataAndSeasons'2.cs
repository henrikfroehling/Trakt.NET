namespace TraktNet.Objects.Post
{
    internal sealed class PostBuilderObjectWithMetadataAndSeasons<TObject, TSeasons> : PostBuilderObjectWithMetadata<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
