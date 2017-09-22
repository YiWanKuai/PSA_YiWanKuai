using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statics {
    private static float rawAngle = 15f;
    private static float convertToRad = 0.0174533f;

    public static int stageNumber;
    public static Vector2 axis = new Vector2(Mathf.Cos(rawAngle * convertToRad), Mathf.Sin(-rawAngle * convertToRad));
}
