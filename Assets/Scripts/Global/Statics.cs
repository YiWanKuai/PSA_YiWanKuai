using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statics {
    private static float rawAngle = 17.5f;
    private static float convertToRad = 0.0174533f;

    public static int stageNumber = 1;
    public static Vector2 axis = new Vector2(Mathf.Cos(rawAngle * convertToRad), Mathf.Sin(-rawAngle * convertToRad));

	public static int lastClearedStage = (PlayerPrefs.HasKey("lastClearedStage")) ? PlayerPrefs.GetInt("lastClearedStage") : 1;
    public static int freezeLevel = (PlayerPrefs.HasKey("freezeLevel")) ? PlayerPrefs.GetInt("freezeLevel") : 1;
	public static int standardizeLevel = (PlayerPrefs.HasKey("standardizeLevel")) ? PlayerPrefs.GetInt("standardizeLevel") : 1;

    public static void updateLastClearedStage() {
		lastClearedStage = PlayerPrefs.GetInt ("lastClearedStage");
    }
    public static void updateFreezeLevel() {
        freezeLevel = PlayerPrefs.GetInt("freezeLevel");
    }
	public static void updateStandardizeLevel() {
		standardizeLevel = PlayerPrefs.GetInt ("standardizeLevel");
	}
}
