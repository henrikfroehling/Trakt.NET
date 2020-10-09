namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        internal TraktPostBuilderShowAddedCollectedAtWithSeasonsCollection()
        {
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }
    }
}
