namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    public partial class CollectionShowEpisodeObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 1,
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 1,
                ""collected_at"": ""2014-07-14T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 1
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""collected_at"": ""2014-07-14T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""ca"": ""2014-07-14T01:00:00.000Z"",
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 1,
                ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                ""meta"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""nu"": 1,
                ""ca"": ""2014-07-14T01:00:00.000Z"",
                ""meta"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";
    }
}
