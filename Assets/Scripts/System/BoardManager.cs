using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public static BoardManager instance;

	// 인스펙터 노출 변수
	// 수치
	public	Sprite[]		tileSprites;			// 타일 스프라이트 종류 모음

	[SerializeField]
	private int				height;					// 세로
	[SerializeField]
	private int				width;					// 가로

	// 인스펙터 비노출 변수
	// 일반
	[HideInInspector]
	public	Tile[,]			tileArray;              // 타일 집합
	[HideInInspector]
	public	int[]			tileSpriteIndArr;		// 타일들의 스프라이트 인덱스 배열

	private ImageIniter		imageIniter;            // 타일 초기화 스크립트


	// 초기화
	private void Awake()
	{
		instance = this;

		imageIniter = GetComponent<ImageIniter>();
	}

	// 시작
	private void Start()
	{
		// 타일 초기화
		imageIniter.SetSize(height, width);
		imageIniter.TileInitialize();

		tileArray = new Tile[height, width];

		int ind = 0;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				Debug.Log(i + " " + j);
				Tile targetTile = (imageIniter.tileArray[i, j] as Transform).GetComponent<Tile>();


				tileArray[i, j] = targetTile;
				targetTile.Initialize(j, i, tileSpriteIndArr[ind++]);
			}
		}
	}

	// 가로 세로 크기 설정
	public void SetSize(int _height, int _width)
	{
		height	= _height;
		width	= _width;
	}

	// 타일 제거 루틴
	public void CrossDel(int x, int y)
	{
		if (tileArray[y, x].TileDisable())
		{
			bool[] flag = new bool[4] { true, true, true, true };

			for (int i = 1; flag[0] || flag[1] || flag[2] || flag[3]; i++)
			{
				if (flag[0])
				{
					flag[0] = tileArray[Mathf.Min(height - 1, y + i), x].TileDisable();
				}

				if (flag[1])
				{
					flag[1] = tileArray[Mathf.Max(0, y - i), x].TileDisable();
				}

				if (flag[2])
				{
					flag[2] = tileArray[y, Mathf.Min(width - 1, x + i)].TileDisable();
				}

				if (flag[3])
				{
					flag[3] = tileArray[y, Mathf.Max(0, x - i)].TileDisable();
				}
			}
		}
	}
}
