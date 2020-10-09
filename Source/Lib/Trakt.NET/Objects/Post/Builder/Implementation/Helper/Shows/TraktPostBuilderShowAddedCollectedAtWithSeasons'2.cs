namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedCollectedAtWithSeasons()
        {
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }
    }
}
