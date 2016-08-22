namespace TraktApiSharp.Enums
{
    /// <summary>Determines the action type for a scroblle post.</summary>
    public sealed class TraktScrobbleActionType : TraktEnumeration
    {
        /// <summary>An invalid action type.</summary>
        public static TraktScrobbleActionType Unspecified { get; } = new TraktScrobbleActionType();

        /// <summary>The scrobble started.</summary>
        public static TraktScrobbleActionType Start { get; } = new TraktScrobbleActionType(1, "start", "start", "Start");

        /// <summary>The scrobble paused.</summary>
        public static TraktScrobbleActionType Pause { get; } = new TraktScrobbleActionType(2, "pause", "pause", "Pause");

        /// <summary>The scrobble stopped.</summary>
        public static TraktScrobbleActionType Stop { get; } = new TraktScrobbleActionType(4, "scrobble", "scrobble", "Stop");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktScrobbleActionType" /> class.<para />
        /// The initialized <see cref="TraktScrobbleActionType" /> is invalid.
        /// </summary>
        public TraktScrobbleActionType() : base() { }

        private TraktScrobbleActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
