using System;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{ 
    public class DrawableIf : IDrawable
    {
        private readonly IDrawable _conditionalDrawable;
        
        public DrawableIf(IDrawable drawable, Func<bool> drawCondition)
        {
            _conditionalDrawable = new ConditionalDraw(drawable, new DrawableDummy(), drawCondition);
        }
        
        public void Draw()
        {
            _conditionalDrawable.Draw();
        }
    }
}