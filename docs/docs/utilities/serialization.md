# Serialization

The [`TraktSerializationService`](xref:TraktNet.Services.TraktSerializationService) provides methods for serializing and deserializing **Trakt.NET** objects. Objects will be serialized as a JSON string.

## Serialize

The serialized JSON string can optionally be indented by setting the parameter `indentation` to `true`. Indentation is disabled by default.

### Single JSON Object
```csharp
using System;
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Services;

var client = new TraktClient("Your Trakt Client ID");

// Get basic info about a show
TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us");

// Serialize the show object as JSON string with indentation
string showJson = await TraktSerializationService.SerializeAsync(showResponse.Value, indentation: true);
Console.WriteLine(showJson);
```

### Collection of JSON Objects
```csharp
using System;
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Services;

var client = new TraktClient("Your Trakt Client ID");

// Get first page of trending shows
TraktPagedResponse<ITraktTrendingShow> trendingShowResponse = await client.Shows.GetTrendingShowsAsync();

// Serialize the trending shows as JSON string with indentation
string trendingShowsJson = await TraktSerializationService.SerializeCollectionAsync(trendingShowResponse, indentation: true);
Console.WriteLine(trendingShowsJson);
```

## Deserialize

### Single JSON Object
```csharp
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Services;

// NOTE: Using the serialized JSON from the previous section.

// Serialize a show object from a JSON string
ITraktShow = await TraktSerializationService.DeserializeAsync<ITraktShow>(showJson);
```

### Collection of JSON Objects
```csharp
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Services;

// NOTE: Using the serialized JSON from the previous section.

// Serialize trending shows from a JSON string
IList<ITraktTrendingShow> trendingShows = await TraktSerializationService.DeserializeCollectionAsync<ITraktTrendingShow>(trendingShowsJson);

// Since ITraktTrendingShow and ITraktShow share some properties,
// this is also possible:
IList<ITraktShow> shows = await TraktSerializationService.DeserializeCollectionAsync<ITraktShow>(trendingShowsJson);
```
