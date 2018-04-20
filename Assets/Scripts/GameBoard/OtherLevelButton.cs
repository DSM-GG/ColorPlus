using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OtherLevelButton : MonoBehaviour, IPointerClickHandler
{
	// 인스펙터 노출 변수
	// 수치
	[SerializeField]
	private int		levelValue;                 // 여기서 몇번째 레벨로 갈지


	// 시작
	private void Start()
	{
		if (DataBase.nowLevel + levelValue <= 0 || DataBase.nowLevel + levelValue >= DataBase.lastLevel)
		{
			Destroy(gameObject);
		}
	}

	// 클릭
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		UIManager.instance.AnotherLevel(levelValue);
	}
}
