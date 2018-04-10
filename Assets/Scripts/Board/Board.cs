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

	[SerializeField]
	private Transform	tilePrefab;             // 슬롯 프리팹

	// 수치
	public  int			width;					// 가로 개수
	public  int			height;                 // 세로 개수
	public  int[]		tileColorType;          // 실제 타일 색 배치

	// 인스펙터 비노출 변수
	// 일반
	private Tile[,]		existTiles;				// 존재하는 타일들


	// 초기화
	private void Awake()
	{
		instance   = this;

		existTiles = new Tile[height, width];
	}

	// 타일 배치
	private void Start()
	{
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

				tileRect.anchorMin = new Vector2((1f / width) * j, 1f - ((1f / height) * (i + 1f)));
				tileRect.anchorMax = new Vector2((1f / width) * (j + 1f), 1f - ((1f / height) * i));
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
		for (int i = 0; i < width; i++)
		{
			existTiles[y, i].TileDisable();
			existTiles[i, x].TileDisable();
		}
	}
}
