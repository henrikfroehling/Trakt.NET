namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;

    internal class TraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        internal TraktPostBuilderShowAddedSeasonsCollection()
        {
        }

        public TPostBuilderAddShow WithSeasons(TSeasonCollection seasons)
        {
            throw new System.NotImplementedException();
        }
    }
}
