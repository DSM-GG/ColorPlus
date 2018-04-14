using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	// 인스펙터 노출 변수
	[SerializeField]
	private Text	turnText;					// 턴 텍스트


	// 초기화
	private void Awake()
	{
		instance = this;
	}

	// 턴 텍스트 설정
	public void SetTurnText(int value)
	{
		turnText.text = value.ToString();
	}
}
