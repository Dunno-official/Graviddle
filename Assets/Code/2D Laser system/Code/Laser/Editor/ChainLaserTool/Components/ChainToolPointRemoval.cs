using _2D_Laser_system.Code.Laser.Utils;
using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.ChainLaserTool.Components
{
    public class ChainToolPointRemoval
    {
        private readonly ObservableList<Vector2> _keyPoints;
        private readonly SelectionInfo _selectionInfo;
        private readonly MouseState _mouseState;

        public ChainToolPointRemoval(ObservableList<Vector2> keyPoints, MouseState mouseState, SelectionInfo selectionInfo)
        {
            _selectionInfo = selectionInfo;
            _mouseState = mouseState;
            _keyPoints = keyPoints;
        }

        public void TryRemove()
        {
            if (_mouseState.CheckRightClick() && _selectionInfo.IsHovered)
            {
                _keyPoints.RemoveAt(_selectionInfo.Index);
            }
        }
    }
}