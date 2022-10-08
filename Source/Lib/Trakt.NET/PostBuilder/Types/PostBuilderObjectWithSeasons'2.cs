namespace TraktNet.PostBuilder
{
    internal sealed class PostBuilderObjectWithSeasons<TObject, TSeasons>
    {
        public TObject Object { get; set; }

        public TSeasons Seasons { get; set; }
    }
}
