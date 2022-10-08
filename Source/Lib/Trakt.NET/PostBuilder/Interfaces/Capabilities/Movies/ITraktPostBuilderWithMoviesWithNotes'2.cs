namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderWithMoviesWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMoviesWithNotes(IEnumerable<Tuple<ITraktMovie, string>> movies);
    }
}
