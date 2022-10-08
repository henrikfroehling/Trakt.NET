namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderWithShows<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShows(IEnumerable<ITraktShow> shows);
    }
}
