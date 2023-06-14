﻿namespace TestUDP;

public class Vector3Data
{
    public float x;
    public float y;
    public float z;

    public Vector3Data(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vector3Data Zero() => new Vector3Data(0, 0, 0);
}
