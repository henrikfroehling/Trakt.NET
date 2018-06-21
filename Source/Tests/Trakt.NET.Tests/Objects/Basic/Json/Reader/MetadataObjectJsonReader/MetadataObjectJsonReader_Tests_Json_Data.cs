namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class MetadataObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""media_type"": ""digital"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""media_type"": ""digital""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""resolution"": ""hd_720p""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""audio"": ""aac""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""audio_channels"": ""5.1""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""mt"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""media_type"": ""digital"",
                ""res"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""aud"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""ac"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""d"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""mt"": ""digital"",
                ""res"": ""hd_720p"",
                ""aud"": ""aac"",
                ""ac"": ""5.1"",
                ""d"": true
              }";
    }
}
