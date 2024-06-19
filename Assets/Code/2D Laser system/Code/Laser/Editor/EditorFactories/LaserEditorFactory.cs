using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorFactories
{
    public class LaserEditorFactory : BaseLaserEditorFactory
    {
        protected override IDrawable CreateFirstElement()
        {
            return new Section("Raycast", Space, new IDrawable[]
            {
                new Property(FindPropertyInData("_raycastData", "_mask")),
                new Property(FindPropertyInData("_raycastData", "_shootingSpeed")),
                new Property(FindPropertyInData("_raycastData", "_nonHitDistance")),
            });
        }

        protected override IDrawable EnableNonHitEffect => new Property(FindPropertyInData("_viewData", "_enableNonHitEffect"));
        protected override IDrawable MaxPoints => new Property(FindPropertyInData("_line", "MaxPoints"));
    }
}