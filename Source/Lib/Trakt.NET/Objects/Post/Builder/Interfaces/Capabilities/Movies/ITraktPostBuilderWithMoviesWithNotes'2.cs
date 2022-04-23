namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithMoviesWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMoviesWithNotes(IEnumerable<Tuple<ITraktMovie, string>> movies);
    }
}
