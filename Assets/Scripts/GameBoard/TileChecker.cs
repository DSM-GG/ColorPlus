using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker
{
	// 일반
	private Tile[,]		m_existTiles;						// 존재하는 타일들
	private bool[,]		m_checkArray;						// 체크용 배열
	private int[]		moveX = new int[4] { 1, -1, 0, 0 };	// 이동용 배열 X
	private int[]		moveY = new int[4] { 0, 0, 1, -1 }; // 이동용 배열 Y


	// 성공 여부 체크
	public bool CheckPuzzle()
	{
		m_existTiles = Board.instance.existTiles;
		m_checkArray = new bool[Board.instance.height, Board.instance.width];

		for (int i = 0; i < Board.instance.height; i++)
		{
			for (int j = 0; j < Board.instance.width; j++)
			{
				if (m_existTiles[i, j].isExist && !m_checkArray[i, j])
				{
					if (!Dfs(j, i, m_existTiles[i, j].colorNum))
					{
						return false;
					}
				}
			}
		}

		return true;
	}

	// 탐색
	private bool Dfs(int nowX, int nowY, int colorNum)
	{
		m_checkArray[nowY, nowX] = true;

		for (int i = 0; i < 4; i++)
		{
			int nextX = nowX + moveX[i];
			int nextY = nowY + moveY[i];

			if (nextX >= 0 && nextX < Board.instance.width && nextY >= 0 && nextY < Board.instance.height)
			{
				if (m_existTiles[nextY, nextX].isExist && !m_checkArray[nextY, nextX])
				{
					if (colorNum != m_existTiles[nextY, nextX].colorNum)
					{
						return false;
					}

					Dfs(nextX, nextY, colorNum);
				}
			}
		}

		return true;
	}
}
