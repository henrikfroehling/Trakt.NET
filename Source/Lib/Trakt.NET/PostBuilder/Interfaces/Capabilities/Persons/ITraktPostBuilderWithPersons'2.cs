namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.People;

    public interface ITraktPostBuilderWithPersons<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithPersons(IEnumerable<ITraktPerson> persons);
    }
}
