using System;

public class Fraction
{
    public int Top { get; set; }
    public int Bottom { get; set; }

    public Fraction()
    {
        Top = 1;
        Bottom = 1;
    }

    public Fraction(int top)
    {
        Top = top;
        Bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        Top = top;
        Bottom = bottom;
    }
}
