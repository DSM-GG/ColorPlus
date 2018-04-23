using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelList : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private Transform	tilePrefab;				// 타일 프리팹

	// 수치
	[SerializeField]
	private int			height;					// 높이
	[SerializeField]
	private int			width;                  // 가로
	[SerializeField]
	private float		intervalX = 0.02f;      // 가로 간격
	[SerializeField]
	private float		intervalY = 0.002f;     // 세로 간격


	// 시작
	private void Start()
	{
		int levelCount = 1;

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				// 타일 생성
				Transform newTile = Instantiate(tilePrefab);

				newTile.name = "Level :" + levelCount;
				newTile.SetParent(transform);


				// 타일 배치
				RectTransform tileRect = newTile.GetComponent<RectTransform>();

				tileRect.anchorMin = new Vector2((1f / width) * j + intervalX, 1f - ((1f / height) * (i + 1f)) + intervalY);
				tileRect.anchorMax = new Vector2((1f / width) * (j + 1f) - intervalX, 1f - ((1f / height) * i) - intervalY);
				tileRect.offsetMin = Vector2.zero;
				tileRect.offsetMax = Vector2.zero;


				// 레벨 설정
				LevelButton targetLevel = newTile.GetComponent<LevelButton>();

				targetLevel.level = levelCount++;
			}
		}
	}
}
