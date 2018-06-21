namespace TraktNet.Objects.Basic
{
    using Get.People;

    /// <summary>A Trakt crew member.</summary>
    public class TraktCrewMember : ITraktCrewMember
    {
        /// <summary>Gets or sets the job name of the crew member.<para>Nullable</para></summary>
        public string Job { get; set; }

        /// <summary>Gets or sets the crew member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        public ITraktPerson Person { get; set; }

        public override string ToString()
        {
            var job = !string.IsNullOrEmpty(Job) ? Job : "job not set";
            var person = Person != null ? Person.ToString() : "no person set";
            return $"{job}, {person}";
        }
    }
}
