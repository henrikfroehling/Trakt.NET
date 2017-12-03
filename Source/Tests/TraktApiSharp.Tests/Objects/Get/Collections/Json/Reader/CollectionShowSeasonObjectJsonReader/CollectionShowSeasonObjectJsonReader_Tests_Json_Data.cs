namespace TraktApiSharp.Tests.Objects.Get.Collections.Json.Reader
{
    public partial class CollectionShowSeasonObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 1
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nu"": 1,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""eps"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""nu"": 1,
                ""eps"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";
    }
}
