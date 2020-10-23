namespace TraktNet.Objects.Post.Builder
{
    public sealed class PostBuilderObjectWithSeasons<TObject, TSeasons>
    {
        public TObject Object { get; set; }

        public TSeasons Seasons { get; set; }
    }
}
