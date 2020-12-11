namespace TraktNet.Objects.Post
{
    public sealed class PostBuilderObjectWithSeasons<TObject, TSeasons>
    {
        public TObject Object { get; set; }

        public TSeasons Seasons { get; set; }
    }
}
