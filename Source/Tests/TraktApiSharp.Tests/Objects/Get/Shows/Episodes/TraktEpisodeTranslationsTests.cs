namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeTranslationsTests
    {
        [TestMethod]
        public void TestTraktEpisodeTranslationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeTranslations.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translations = JsonConvert.DeserializeObject<IEnumerable<TraktEpisodeTranslation>>(jsonFile);

            translations.Should().NotBeNull();
            translations.Should().HaveCount(3);

            var translationsArray = translations.ToArray();

            translationsArray[0].Title.Should().Be("Winter Is Coming");
            translationsArray[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translationsArray[0].LanguageCode.Should().Be("en");

            translationsArray[1].Title.Should().Be("Se acerca el invierno");
            translationsArray[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translationsArray[1].LanguageCode.Should().Be("es");

            translationsArray[2].Title.Should().Be("凛冬将至");
            translationsArray[2].Overview.Should().Be("一名守夜人军团的逃兵在临冬城外被抓获，领主艾德（奈德）·史塔克下令将其处斩。奈德对绝境长城之外的形势忧心忡忡。行刑结束后，奈德回到城中，他的夫人凯特琳带来一个令人震惊的消息：奈德的良师益友、现任首相琼恩·艾林在都城离奇死亡，罗伯特国王正启程赶往北方，希望奈德接替琼恩·艾林出任国王之手。与此同时，在狭海对岸的潘托斯，韦赛里斯·坦格利安正计划与多斯拉克游牧民族的一位重要首领卓戈卡奥结盟，凭借多斯拉克人的力量夺回本属于他的铁王座。他妹妹丹妮莉斯的终身幸福成了他手中最重要的筹码。罗伯特国王带着瑟曦·兰尼斯特王后及兰尼斯特家族的重要成员抵达临冬城。他的随行人员包括：王后的弟弟詹姆和提力昂，他们一个英俊潇洒，一个却是侏儒；12岁的乔佛里王子，王位的继承人。奈德无法拒绝国王的盛情邀请，决定南下君临城帮助国王稳定国内局势。就在罗伯特和奈德动身之前，奈德的私生子琼恩·雪诺决定北上黑城堡加盟守夜人军团，对守夜人颇为好奇的提力昂打算和雪诺一同前往。厄运突然降临到奈德的次子布兰身上，奈德和琼恩都被迫推迟了行程。");
            translationsArray[2].LanguageCode.Should().Be("zh");
        }
    }
}
