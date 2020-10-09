namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;

    internal class TraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedSeasons()
        {
        }
        
        public TPostBuilderAddShow WithSeasons(int[] seasons)
        {
            throw new System.NotImplementedException();
        }

        public TPostBuilderAddShow WithSeasons(int season, params int[] seasons)
        {
            throw new System.NotImplementedException();
        }
    }
}
