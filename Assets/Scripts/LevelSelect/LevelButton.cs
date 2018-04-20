using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
	// 수치
	public int level = 0;


	// 마우스 클릭
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (level <= DataBase.lastLevel + 1)
		{
			DataBase.nowLevel = level;

			SceneManager.LoadScene("MainScene");
		}
	}
}
