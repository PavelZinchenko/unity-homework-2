using UnityEngine;
using UnityEngine.Assertions;

public struct PlayerHealth
{
    public float Percentage => (float)Value / Max;
    public int Value { get; }
    public int Max { get; }

    public PlayerHealth(int max) 
        : this(max, max)
    {
    }

    public PlayerHealth(int max, int value)
    {
        Assert.IsTrue(max > 0);

        Max = max;
        Value = Mathf.Clamp(value, 0, Max);
    }

    public static PlayerHealth operator +(PlayerHealth hp, int value)
        => new(hp.Max, hp.Value + value);
    public static PlayerHealth operator -(PlayerHealth hp, int value)
        => new(hp.Max, hp.Value - value);

    public override string ToString()
        => $"{Value} / {Max}";
}
