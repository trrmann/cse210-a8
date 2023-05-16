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

    public string GetFractionString()
    {
        return $"{Top}/{Bottom}";
    }

    public double GetDecimalValue()
    {
        if (Bottom == 0)
        {
            return 0.0;
        }
        else
        {
            return Convert.ToDouble(Top) / Convert.ToDouble(Bottom);
        }
    }
}
