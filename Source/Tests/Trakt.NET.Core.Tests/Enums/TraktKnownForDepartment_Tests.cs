namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktKnownForDepartment_Tests
    {
        [Fact]
        public void Test_TraktKnownForDepartment_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktKnownForDepartment>();

            allValues.Should().NotBeNull().And.HaveCount(13);
            allValues.Should().Contain(new List<TraktKnownForDepartment>() { TraktKnownForDepartment.Unspecified, TraktKnownForDepartment.Production,
                                                                             TraktKnownForDepartment.Art, TraktKnownForDepartment.Crew,
                                                                             TraktKnownForDepartment.CostumeAndMakeUp, TraktKnownForDepartment.Directing,
                                                                             TraktKnownForDepartment.Writing, TraktKnownForDepartment.Sound,
                                                                             TraktKnownForDepartment.Camera, TraktKnownForDepartment.VisualEffects,
                                                                             TraktKnownForDepartment.Lighting, TraktKnownForDepartment.Editing,
                                                                             TraktKnownForDepartment.Acting });
        }

        [Fact]
        public void Test_TraktKnownForDepartment_Properties()
        {
            TraktKnownForDepartment.Production.Value.Should().Be(1);
            TraktKnownForDepartment.Production.ObjectName.Should().Be("production");
            TraktKnownForDepartment.Production.UriName.Should().Be("production");
            TraktKnownForDepartment.Production.DisplayName.Should().Be("Production");

            TraktKnownForDepartment.Art.Value.Should().Be(2);
            TraktKnownForDepartment.Art.ObjectName.Should().Be("art");
            TraktKnownForDepartment.Art.UriName.Should().Be("art");
            TraktKnownForDepartment.Art.DisplayName.Should().Be("Art");

            TraktKnownForDepartment.Crew.Value.Should().Be(4);
            TraktKnownForDepartment.Crew.ObjectName.Should().Be("crew");
            TraktKnownForDepartment.Crew.UriName.Should().Be("crew");
            TraktKnownForDepartment.Crew.DisplayName.Should().Be("Crew");

            TraktKnownForDepartment.CostumeAndMakeUp.Value.Should().Be(8);
            TraktKnownForDepartment.CostumeAndMakeUp.ObjectName.Should().Be("costume & make-up");
            TraktKnownForDepartment.CostumeAndMakeUp.UriName.Should().Be("costume & make-up");
            TraktKnownForDepartment.CostumeAndMakeUp.DisplayName.Should().Be("Costume & Make-Up");

            TraktKnownForDepartment.Directing.Value.Should().Be(16);
            TraktKnownForDepartment.Directing.ObjectName.Should().Be("directing");
            TraktKnownForDepartment.Directing.UriName.Should().Be("directing");
            TraktKnownForDepartment.Directing.DisplayName.Should().Be("Directing");

            TraktKnownForDepartment.Writing.Value.Should().Be(32);
            TraktKnownForDepartment.Writing.ObjectName.Should().Be("writing");
            TraktKnownForDepartment.Writing.UriName.Should().Be("writing");
            TraktKnownForDepartment.Writing.DisplayName.Should().Be("Writing");

            TraktKnownForDepartment.Sound.Value.Should().Be(64);
            TraktKnownForDepartment.Sound.ObjectName.Should().Be("sound");
            TraktKnownForDepartment.Sound.UriName.Should().Be("sound");
            TraktKnownForDepartment.Sound.DisplayName.Should().Be("Sound");

            TraktKnownForDepartment.Camera.Value.Should().Be(128);
            TraktKnownForDepartment.Camera.ObjectName.Should().Be("camera");
            TraktKnownForDepartment.Camera.UriName.Should().Be("camera");
            TraktKnownForDepartment.Camera.DisplayName.Should().Be("Camera");

            TraktKnownForDepartment.VisualEffects.Value.Should().Be(256);
            TraktKnownForDepartment.VisualEffects.ObjectName.Should().Be("visual effects");
            TraktKnownForDepartment.VisualEffects.UriName.Should().Be("visual effects");
            TraktKnownForDepartment.VisualEffects.DisplayName.Should().Be("Visual Effects");

            TraktKnownForDepartment.Lighting.Value.Should().Be(512);
            TraktKnownForDepartment.Lighting.ObjectName.Should().Be("lighting");
            TraktKnownForDepartment.Lighting.UriName.Should().Be("lighting");
            TraktKnownForDepartment.Lighting.DisplayName.Should().Be("Lighting");

            TraktKnownForDepartment.Editing.Value.Should().Be(1024);
            TraktKnownForDepartment.Editing.ObjectName.Should().Be("editing");
            TraktKnownForDepartment.Editing.UriName.Should().Be("editing");
            TraktKnownForDepartment.Editing.DisplayName.Should().Be("Editing");

            TraktKnownForDepartment.Acting.Value.Should().Be(2048);
            TraktKnownForDepartment.Acting.ObjectName.Should().Be("acting");
            TraktKnownForDepartment.Acting.UriName.Should().Be("acting");
            TraktKnownForDepartment.Acting.DisplayName.Should().Be("Acting");
        }
    }
}
