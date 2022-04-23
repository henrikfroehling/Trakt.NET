namespace TraktNet.Objects.Post.Capabilities
{
    using Get.People;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithPersons<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithPersons(IEnumerable<ITraktPerson> persons);
    }
}
