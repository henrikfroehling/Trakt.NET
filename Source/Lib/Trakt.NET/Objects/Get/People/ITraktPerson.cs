namespace TraktNet.Objects.Get.People
{
    using System;

    public interface ITraktPerson
    {
        string Name { get; set; }

        ITraktPersonIds Ids { get; set; }

        string Biography { get; set; }

        DateTime? Birthday { get; set; }

        DateTime? Death { get; set; }

        int Age { get; }

        string Birthplace { get; set; }

        string Homepage { get; set; }
    }
}
