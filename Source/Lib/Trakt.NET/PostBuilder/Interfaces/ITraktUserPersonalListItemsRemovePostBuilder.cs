namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Post.Users.PersonalListItems;

    public interface ITraktUserPersonalListItemsRemovePostBuilder
        : ITraktRemovePostBuilder<ITraktUserPersonalListItemsRemovePostBuilder, ITraktUserPersonalListItemsRemovePost>
    {
        /// <summary>Adds the given <paramref name="person"/> to the builder.</summary>
        /// <param name="person">The <see cref="ITraktPerson"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="person"/> is null.</exception>
        ITraktUserPersonalListItemsRemovePostBuilder WithPerson(ITraktPerson person);

        /// <summary>Adds the given <paramref name="personIds"/> to the builder.</summary>
        /// <param name="personIds">The <see cref="ITraktPersonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        ITraktUserPersonalListItemsRemovePostBuilder WithPerson(ITraktPersonIds personIds);

        /// <summary>Adds the given <paramref name="persons"/> collection to the builder.</summary>
        /// <param name="persons">A collection of <see cref="ITraktPerson"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="persons"/> is null.</exception>
        ITraktUserPersonalListItemsRemovePostBuilder WithPersons(IEnumerable<ITraktPerson> persons);

        /// <summary>Adds the given <paramref name="personIds"/> collection to the builder.</summary>
        /// <param name="personIds">A collection of <see cref="ITraktPersonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktUserPersonalListItemsRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        ITraktUserPersonalListItemsRemovePostBuilder WithPersons(IEnumerable<ITraktPersonIds> personIds);
    }
}
