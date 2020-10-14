namespace TraktNet.Objects.Post.Builder
{
    internal sealed class PostBuilderObjectWithSeasons<TObject, TSeasons>
    {
        public TObject Object { get; set; }

        public TSeasons Seasons { get; set; }
    }
}
