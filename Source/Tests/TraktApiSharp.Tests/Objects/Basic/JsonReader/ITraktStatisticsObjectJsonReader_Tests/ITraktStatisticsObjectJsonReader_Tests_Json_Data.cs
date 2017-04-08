namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    public partial class ITraktStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watchers"": 129920,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""watchers"": 129920
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""plays"": 3563853
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""collectors"": 49711
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""collected_episodes"": 1310350
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""comments"": 96
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""lists"": 49468
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wa"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watchers"": 129920,
                ""pl"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""col"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""colep"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""cm"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""li"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""vo"": 9274
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""wa"": 129920,
                ""pl"": 3563853,
                ""col"": 49711,
                ""colep"": 1310350,
                ""cm"": 96,
                ""li"": 49468,
                ""vo"": 9274
              }";
    }
}
