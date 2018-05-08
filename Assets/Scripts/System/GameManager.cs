using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// 초기화
	private void Awake()
	{
		new Parser();
	}

	// 시작
	private void Start()
	{
		Parser.instance.Parse(1);
	}
}
