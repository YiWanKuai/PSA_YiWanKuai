using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statics {
    private static float rawAngle = 17.5f;
    private static float convertToRad = 0.0174533f;

    public static int stageNumber = 1;
    public static Vector2 axis = new Vector2(Mathf.Cos(rawAngle * convertToRad), Mathf.Sin(-rawAngle * convertToRad));
}
