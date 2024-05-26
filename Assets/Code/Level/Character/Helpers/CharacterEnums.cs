namespace Level.Character.Helpers
{
    public enum GravityDirection
    {
        Down,
        Right,
        Up,
        Left
    }

    public enum MovementState
    {
        Stop = 0,
        Left = -1,
        Right = 1,
    }
}