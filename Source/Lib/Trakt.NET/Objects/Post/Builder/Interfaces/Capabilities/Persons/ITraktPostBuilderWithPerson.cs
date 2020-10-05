namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.People;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithPerson<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithPerson(ITraktPerson person);

        TPostBuilder WithPersons(IEnumerable<ITraktPerson> persons);
    }
}
