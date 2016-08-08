namespace TraktApiSharp.Enums
{
    public sealed class TraktScrobbleActionType : TraktEnumeration
    {
        public static TraktScrobbleActionType Unspecified { get; } = new TraktScrobbleActionType();
        public static TraktScrobbleActionType Start { get; } = new TraktScrobbleActionType(1, "start", "start", "Start");
        public static TraktScrobbleActionType Pause { get; } = new TraktScrobbleActionType(2, "pause", "pause", "Pause");
        public static TraktScrobbleActionType Stop { get; } = new TraktScrobbleActionType(4, "scrobble", "scrobble", "Stop");

        public TraktScrobbleActionType() : base() { }

        private TraktScrobbleActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
