﻿
public class CameraBorders
{
    public readonly float Top;
    public readonly float Down;
    public readonly float Left;
    public readonly float Right;

    public readonly float HorizontalCentre;
    public readonly float VerticalCentre;


    public CameraBorders(float topBorder, float downBorder, float leftBorder, float rightBorder)
    {
        Top = topBorder;
        Down = downBorder;
        Left = leftBorder;
        Right = rightBorder;

        HorizontalCentre = (leftBorder + rightBorder) / 2f;
        VerticalCentre = (topBorder + downBorder) / 2f;
    }
}