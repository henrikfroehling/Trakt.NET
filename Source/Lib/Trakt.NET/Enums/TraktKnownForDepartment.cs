namespace TraktNet.Enums
{
    /// <summary>Determines the department of a person.</summary>
    public sealed class TraktKnownForDepartment : TraktEnumeration
    {
        /// <summary>An invalid department type.</summary>
        public static TraktKnownForDepartment Unspecified { get; } = new TraktKnownForDepartment();

        /// <summary>The production department.</summary>
        public static TraktKnownForDepartment Production { get; } = new TraktKnownForDepartment(1, "production", "production", "Production");

        /// <summary>The art department.</summary>
        public static TraktKnownForDepartment Art { get; } = new TraktKnownForDepartment(2, "art", "art", "Art");

        /// <summary>The crew department.</summary>
        public static TraktKnownForDepartment Crew { get; } = new TraktKnownForDepartment(4, "crew", "crew", "Crew");

        /// <summary>The costume and make-up department.</summary>
        public static TraktKnownForDepartment CostumeAndMakeUp { get; } = new TraktKnownForDepartment(8, "costume & make-up", "costume & make-up", "Costume & Make-Up");

        /// <summary>The directing department.</summary>
        public static TraktKnownForDepartment Directing { get; } = new TraktKnownForDepartment(16, "directing", "directing", "Directing");

        /// <summary>The writing department.</summary>
        public static TraktKnownForDepartment Writing { get; } = new TraktKnownForDepartment(32, "writing", "writing", "Writing");

        /// <summary>The sound department.</summary>
        public static TraktKnownForDepartment Sound { get; } = new TraktKnownForDepartment(64, "sound", "sound", "Sound");

        /// <summary>The camera department.</summary>
        public static TraktKnownForDepartment Camera { get; } = new TraktKnownForDepartment(128, "camera", "camera", "Camera");

        /// <summary>The visual effects department.</summary>
        public static TraktKnownForDepartment VisualEffects { get; } = new TraktKnownForDepartment(256, "visual effects", "visual effects", "Visual Effects");

        /// <summary>The lighting department.</summary>
        public static TraktKnownForDepartment Lighting { get; } = new TraktKnownForDepartment(512, "lighting", "lighting", "Lighting");

        /// <summary>The editing department.</summary>
        public static TraktKnownForDepartment Editing { get; } = new TraktKnownForDepartment(1024, "editing", "editing", "Editing");

        /// <summary>The acting department.</summary>
        public static TraktKnownForDepartment Acting { get; } = new TraktKnownForDepartment(2048, "acting", "acting", "Acting");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktKnownForDepartment" /> class.<para />
        /// The initialized <see cref="TraktKnownForDepartment" /> is invalid.
        /// </summary>
        public TraktKnownForDepartment()
        {
        }

        private TraktKnownForDepartment(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
