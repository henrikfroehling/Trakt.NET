namespace TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncPlaybackProgressItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncPlaybackProgressItem>
    {
        public ITraktObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new TraktSyncPlaybackProgressItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPlaybackProgressItem)} is not supported.");
        }
    }
}
