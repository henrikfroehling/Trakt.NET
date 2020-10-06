namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithShows<TPostBuilder, TPostObject>
        : ITraktPostBuilderWithShow<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShows(IEnumerable<ITraktShow> shows);
    }
}
