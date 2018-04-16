using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
	public static Board	instance;

	// 인스펙터 노출 변수
	// 일반
	public	Sprite[]	tileSprites;            // 타일 스프라이트 모음
	public  Tile[,]		existTiles;             // 존재하는 타일들

	[SerializeField]
	private Transform	tilePrefab;             // 슬롯 프리팹

	// 수치
	public  int			width;					// 가로 개수
	public  int			height;                 // 세로 개수
	public  int[]		tileColorType;          // 실제 타일 색 배치

	[SerializeField]
	private float		interval = 0.1f;        // 타일 간격

	// 인스펙터 비노출 변수
	// 일반
	private TileChecker	tileCheck;				// 타일 체커
	

	// 초기화
	private void Awake()
	{
		instance    = this;

		tileCheck = new TileChecker();
	}

	// 타일 배치
	public void SetTile()
	{
		// 타일 생성
		existTiles = new Tile[height, width];

		// 타일 배치
		int colorTypeIndex = 0;

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				// 타일 생성
				Transform newTile = Instantiate(tilePrefab);

				newTile.name = "Tile " + (i + 1) + ":" + (j + 1);
				newTile.SetParent(transform);


				// 타일 배치
				RectTransform tileRect = newTile.GetComponent<RectTransform>();

				tileRect.anchorMax = new Vector2((1f / width) * (j + 1f) - interval, 1f - ((1f / height) * i) - interval);
				tileRect.anchorMin = new Vector2((1f / width) * j + interval, 1f - ((1f / height) * (i + 1f)) + interval);
				tileRect.offsetMin = Vector2.zero;
				tileRect.offsetMax = Vector2.zero;


				// 타일 설정
				Tile targetTile = newTile.GetComponent<Tile>();

				targetTile.SetColorNum(tileColorType[colorTypeIndex++]);
				targetTile.SetPosition(j, i);
				existTiles[i, j] = targetTile;
			}
		}
	}

	// 클릭시 타일 제거
	public void CrossDel(int x, int y)
	{
		if (existTiles[y, x].TileDisable())
		{
			bool[] flag = new bool[4] { true, true, true, true };

			for (int i = 1; flag[0] || flag[1] || flag[2] || flag[3]; i++)
			{
				if (flag[0])
				{
					flag[0] = existTiles[Mathf.Min(height - 1, y + i), x].TileDisable();
				}

				if (flag[1])
				{
					flag[1] = existTiles[Mathf.Max(0, y - i), x].TileDisable();
				}

				if (flag[2])
				{
					flag[2] = existTiles[y, Mathf.Min(width - 1, x + i)].TileDisable();
				}

				if (flag[3])
				{
					flag[3] = existTiles[y, Mathf.Max(0, x - i)].TileDisable();
				}
			}
		}

		Debug.Log(tileCheck.CheckPuzzle());
	}
}
