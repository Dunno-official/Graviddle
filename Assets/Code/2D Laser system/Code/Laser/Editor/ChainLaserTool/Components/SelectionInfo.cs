
namespace Code._2D_Laser_system.Code.Laser.Editor.ChainLaserTool.Components
{
    public class SelectionInfo
    {
        public bool IsSelected;
        public bool IsHovered;
        public int Index = -1;

        public void Unselect()
        {
            IsSelected = false;
            Index = -1;
        }

        public bool IsNotSelected => IsSelected == false && IsHovered == false;
    }
}