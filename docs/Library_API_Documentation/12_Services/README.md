## Services

The library contains some services which could be helpful additionally.

### Serialization Service

```csharp
using TraktNet.Services;
```

The `TraktSerializationService` provides methods for serializing and deserializing Trakt.NET objects. Objects will be serialized as a JSON string.

### Language Service

```csharp
using TraktNet.Services;
```

The `TraktLanguageService` provides methods for looking up the language and country names for language codes, that are returned by the Trakt API.
