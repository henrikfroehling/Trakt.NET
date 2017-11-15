namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Json
{
    public partial class UserCustomListItemsPostResponseGroupObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""movies"": 1,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""people"": 5
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""movies"": 1
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""shows"": 2
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""seasons"": 3
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""episodes"": 4
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""people"": 5
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""mov"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""movies"": 1,
                ""sh"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""sea"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""eps"": 4,
                ""people"": 5
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""ppl"": 5
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""mov"": 1,
                ""sh"": 2,
                ""sea"": 3,
                ""eps"": 4,
                ""ppl"": 5
              }";
    }
}
