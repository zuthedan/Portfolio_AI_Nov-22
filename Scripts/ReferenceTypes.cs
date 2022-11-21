using System;

[Serializable]
public class Float
{
    public float Value;

    public Float(float value) => Value = value;

    public static implicit operator float(Float f)=> f.Value;
}

[Serializable]
public class Bool
{
    public bool Value;

    public Bool(bool value) => Value = value;

    public static implicit operator bool(Bool b) => b.Value;
}