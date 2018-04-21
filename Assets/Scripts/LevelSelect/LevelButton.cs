using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
	// 수치
	public int level = 0;


	// 시작
	private void Start()
	{
		if (level > DataBase.lastLevel + 1)
		{
			DisableButton();
		}
	}

	// 마우스 클릭
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		DataBase.nowLevel = level;

		SceneManager.LoadScene("MainScene");
	}

	// 버튼 비활성화
	private void DisableButton()
	{
		Destroy(gameObject);
	}
}
