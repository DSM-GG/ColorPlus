using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public static BoardManager instance;

	// 인스펙터 노출 변수
	// 수치
	[SerializeField]
	private int				height;					// 세로
	[SerializeField]
	private int				width;					// 가로

	// 인스펙터 비노출 변수
	// 일반
	[HideInInspector]
	public	Tile[,]			tileArray;				// 타일 집합

	private ImageIniter		imageIniter;			// 타일 초기화 스크립트


	// 초기화
	private void Awake()
	{
		imageIniter = GetComponent<ImageIniter>();
	}

	// 시작
	private void Start()
	{
		// 타일 초기화
		imageIniter.SetSize(height, width);
		imageIniter.TileInitialize();

		Transform[,] tempArray = imageIniter.tileArray as Transform[,];

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				Debug.Log(i + " " + j);
				tileArray[i, j] = tempArray[i, j].GetComponent<Tile>();
			}
		}
	}
}
