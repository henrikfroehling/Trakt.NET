namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class MetadataArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""mt"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""mediaaa_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""mt"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                },
                {
                  ""mediaaa_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""hdr"": ""dolby_vision"",
                  ""3d"": true
                }
              ]";
    }
}
