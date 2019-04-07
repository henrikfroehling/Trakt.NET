namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class StatisticsArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""wt"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""watchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""waatchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""wt"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                },
                {
                  ""waatchers"": 129920,
                  ""plays"": 3563853,
                  ""collectors"": 49711,
                  ""collected_episodes"": 1310350,
                  ""comments"": 96,
                  ""lists"": 49468,
                  ""votes"": 9274
                }
              ]";
    }
}
