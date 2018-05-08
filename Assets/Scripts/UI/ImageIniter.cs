﻿using UnityEngine;

namespace UI
{
	public class ImageIniter : MonoBehaviour
	{
		// 인스펙터 노출 변수
		// 일반
		[SerializeField]
		private Transform 	tile;                   	// 배치될 타일

		// 수치
		[SerializeField]
		private string 		tileName = "Tile";       	// 타일 이름
		[SerializeField]
		private int 		height = 1;             	// 세로
		[SerializeField]
		private int 		width = 1;              	// 가로
		[SerializeField]
		private float 		gap = 0.1f;              	// 간격

		// 인스펙터 비노출 변수
		// 일반
		[HideInInspector]
		public Object[,] 	tileArray;               	// 생성된 타일 집합


		// 가로 세로 설정
		public void SetSize(int _height, int _width)
		{
			height = _height;
			width = _width;
		}

		// 타일 초기화
		public void TileInitialize()
		{
			tileArray = new Object[height, width];

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					// 타일 생성
					Transform newTile = Instantiate(tile);

					newTile.name = tileName + " " + (i + 1) + " / " + (j + 1);
					newTile.SetParent(transform);


					// 타일 배치
					RectTransform tileRect = newTile.GetComponent<RectTransform>();

					tileRect.anchorMax = new Vector2((1f / width) * (j + 1f) - gap, 1f - ((1f / height) * i) - gap);
					tileRect.anchorMin = new Vector2((1f / width) * j + gap, 1f - ((1f / height) * (i + 1f)) + gap);
					tileRect.offsetMin = Vector2.zero;
					tileRect.offsetMax = Vector2.zero;

					tileArray[i, j] = newTile;
				}
			}
		}
	}
}
