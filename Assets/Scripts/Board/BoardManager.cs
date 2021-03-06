﻿using System.Collections.Generic;
using Systems;
using UI.Effect;
using UnityEngine;

namespace Board
{
	public class BoardManager : MonoBehaviour
	{
		public static BoardManager instance;

		// 인스펙터 노출 변수
		// 수치
		public	Sprite[]		tileSprites;			// 타일 스프라이트 종류 모음

		[SerializeField]
		private bool 			useStartInit;			// 시작 초기화를 사용할지
		
		// 인스펙터 비노출 변수
		// 일반
		public int				height;					// 세로
		public int				width;					// 가로
		
		[HideInInspector]
		public	Tile.Tile[,]	tileArray;             	// 타일 집합
		[HideInInspector]
		public	int[]			tileSpriteIndArr;		// 타일들의 스프라이트 인덱스 배열
		
		private ImageIniter		imageIniter;           	// 타일 초기화 스크립트
		private Stack<bool[,]> 	tileHistory;			// 타일 히스토리


		// 초기화
		private void Awake()
		{
			instance = this;

			imageIniter = GetComponent<ImageIniter>();
			tileHistory = new Stack<bool[,]>();
		}

		// 시작
		private void Start()
		{
			if (useStartInit)
			{
				Initialize();
			}
		}

		// 가로 세로 크기 설정
		public void SetSize(int newHeight, int newWidth)
		{
			height	= newHeight;
			width	= newWidth;
		}
		
		// 초기화
		public void Initialize()
		{
			// 타일 초기화
			imageIniter.SetSize(height, width);
			imageIniter.TileInitialize();

			tileArray = new Tile.Tile[height, width];

			int ind = 0;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Tile.Tile targetTile = (imageIniter.tileArray[i, j] as Transform).GetComponent<Tile.Tile>();


					tileArray[i, j] = targetTile;
					targetTile.Initialize(j, i, tileSpriteIndArr[ind++]);
				}
			}
		}

		// 타일 제거 루틴
		public void CrossDel(int x, int y)
		{
			int timeIndex = 1;

			
			SaveTileState();
			
			if (tileArray[y, x].TileDisable(0))
			{
				bool[] flag = { true, true, true, true };

				for (int i = 1; flag[0] || flag[1] || flag[2] || flag[3]; i++)
				{
					if (flag[0])
					{
						flag[0] = tileArray[Mathf.Min(height - 1, y + i), x].TileDisable(timeIndex);
					}

					if (flag[1])
					{
						flag[1] = tileArray[Mathf.Max(0, y - i), x].TileDisable(timeIndex);
					}

					if (flag[2])
					{
						flag[2] = tileArray[y, Mathf.Min(width - 1, x + i)].TileDisable(timeIndex);
					}

					if (flag[3])
					{
						flag[3] = tileArray[y, Mathf.Max(0, x - i)].TileDisable(timeIndex);
					}

					timeIndex++;
				}
			}
			
			GameManager.instance.CheckTile();
		}
		
		// 타일 상태를 히스토리에 저장
		private void SaveTileState()
		{
			bool[,] result = new bool[height, width];

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					result[i, j] = tileArray[i, j].isExist;
				}
			}

			tileHistory.Push(result);
		}
		
		// 되돌리기
		public void Restore()
		{
			if (tileHistory.Count > 0)
			{
				bool[,] history = tileHistory.Pop();

				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						if (history[i, j])
						{
							tileArray[i, j].TileEnable();
						}
					}
				}
				
				GameManager.instance.AddTurn(1);
			}
			else
			{
				Debug.Log("History is empty!");
			}
		}
		
		// 초기화 
		public void ResetTile()
		{
			Debug.Log("ASD");
			
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					tileArray[i, j].TileEnable();
				}
			}
			
			tileHistory.Clear();
			GameManager.instance.ResetTurn();
		}
	}
}
