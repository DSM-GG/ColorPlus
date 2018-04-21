using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{
	// 수치
	public static int nowLevel = 1;         // 현재 레벨
	public static int lastLevel = 1;		// 마지막으로 클리어한 레벨


	// 클리어 레벨 초기화
	public static void ResetLastLevel()
	{
		lastLevel = PlayerPrefs.GetInt("LastLevel", 1);
	}

	// 클리어 레벨 갱신
	public static void SetLastLevel(int level)
	{
		lastLevel = Mathf.Max(level, lastLevel);

		PlayerPrefs.SetInt("LastLevel", lastLevel);
		PlayerPrefs.Save();
	}
}