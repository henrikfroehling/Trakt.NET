# Serialize Authorization

This example shows how we can serialize a given authorization as JSON data and deserialize the JSON data back to an authorization.

For this example we simply create a fake authorization.

[!code-csharp[](../../codesnippets/examples/serialization/Serialization.cs#L10-L10)]

We use the [`TraktSerializationService`](xref:TraktNet.Services.TraktSerializationService) to serialize the previously created authorization as JSON data.

[!code-csharp[](../../codesnippets/examples/serialization/Serialization.cs#L12-L15)]

Then, we use the [`TraktSerializationService`](xref:TraktNet.Services.TraktSerializationService) to deserialize the JSON data back to an authorization object.

[!code-csharp[](../../codesnippets/examples/serialization/Serialization.cs#L17-L31)]
