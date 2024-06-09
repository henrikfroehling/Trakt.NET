namespace TraktNET.Enums
{
    public sealed class TraktKnownForDepartmentTests
    {
        [Fact]
        public void TestTraktKnownForDepartmentToJson()
        {
            TraktKnownForDepartment.Unspecified.ToJson().Should().BeNull();
            TraktKnownForDepartment.Acting.ToJson().Should().Be("acting");
            TraktKnownForDepartment.Directing.ToJson().Should().Be("directing");
            TraktKnownForDepartment.Writing.ToJson().Should().Be("writing");
            TraktKnownForDepartment.Production.ToJson().Should().Be("production");
            TraktKnownForDepartment.VisualEffects.ToJson().Should().Be("visual effects");
            TraktKnownForDepartment.CostumeMakeup.ToJson().Should().Be("costume & make-up");
            TraktKnownForDepartment.Camera.ToJson().Should().Be("camera");
            TraktKnownForDepartment.Sound.ToJson().Should().Be("sound");
            TraktKnownForDepartment.Editing.ToJson().Should().Be("editing");
            TraktKnownForDepartment.Art.ToJson().Should().Be("art");
            TraktKnownForDepartment.Lighting.ToJson().Should().Be("lighting");
            TraktKnownForDepartment.Crew.ToJson().Should().Be("crew");
        }

        [Fact]
        public void TestTraktKnownForDepartmentFromJson()
        {
            "unspecified".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Unspecified);
            "acting".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Acting);
            "directing".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Directing);
            "writing".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Writing);
            "production".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Production);
            "visual effects".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.VisualEffects);
            "costume & make-up".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.CostumeMakeup);
            "camera".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Camera);
            "sound".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Sound);
            "editing".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Editing);
            "art".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Art);
            "lighting".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Lighting);
            "crew".ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Crew);

            string? nullValue = null;
            nullValue.ToTraktKnownForDepartment().Should().Be(TraktKnownForDepartment.Unspecified);
        }

        [Fact]
        public void TestTraktKnownForDepartmentDisplayName()
        {
            TraktKnownForDepartment.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktKnownForDepartment.Acting.DisplayName().Should().Be("Acting");
            TraktKnownForDepartment.Directing.DisplayName().Should().Be("Directing");
            TraktKnownForDepartment.Writing.DisplayName().Should().Be("Writing");
            TraktKnownForDepartment.Production.DisplayName().Should().Be("Production");
            TraktKnownForDepartment.VisualEffects.DisplayName().Should().Be("Visual Effects");
            TraktKnownForDepartment.CostumeMakeup.DisplayName().Should().Be("Costume & Make-Up");
            TraktKnownForDepartment.Camera.DisplayName().Should().Be("Camera");
            TraktKnownForDepartment.Sound.DisplayName().Should().Be("Sound");
            TraktKnownForDepartment.Editing.DisplayName().Should().Be("Editing");
            TraktKnownForDepartment.Art.DisplayName().Should().Be("Art");
            TraktKnownForDepartment.Lighting.DisplayName().Should().Be("Lighting");
            TraktKnownForDepartment.Crew.DisplayName().Should().Be("Crew");
        }
    }
}
