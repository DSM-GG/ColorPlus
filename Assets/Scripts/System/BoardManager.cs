using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public static BoardManager instance;

	// 인스펙터 노출 변수
	// 수치
	public	Sprite[]		tileSprites;			// 타일 스프라이트 모음

	[SerializeField]
	private int				height;					// 세로
	[SerializeField]
	private int				width;					// 가로

	// 인스펙터 비노출 변수
	// 일반
	[HideInInspector]
	public	Tile[,]			tileArray;              // 타일 집합

	private ImageIniter		imageIniter;			// 타일 초기화 스크립트


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
		
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				Debug.Log(i + " " + j);
				Tile targetTile = (imageIniter.tileArray[i, j] as Transform).GetComponent<Tile>();


				tileArray[i, j] = targetTile;
				targetTile.Initialize(j, i, 0);
			}
		}
	}
}
