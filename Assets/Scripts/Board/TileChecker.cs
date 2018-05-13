using UnityEngine;

namespace Board
{
    public class TileChecker : MonoBehaviour
    {
        // 일반
        private Tile.Tile[,]	existTiles;	    					    // 존재하는 타일들
        private bool[,]		    checkArray;	    					    // 체크용 배열
        private int            height;                                // 높이
        private int            width;                                 // 너비
        private readonly int[] moveX = { 1, -1, 0, 0 };               // 이동용 배열 X
        private readonly int[] moveY = { 0, 0, 1, -1 };               // 이동용 배열 Y


        // 성공 여부 체크
        public bool CheckPuzzle()
        {
            existTiles = BoardManager.instance.tileArray;
            height     = BoardManager.instance.height;
            width      = BoardManager.instance.width;
            checkArray = new bool[height, width];
		
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (existTiles[i, j].isExist && !checkArray[i, j])
                    {
                        if (!Dfs(j, i, existTiles[i, j].colorNum))
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
            if (colorNum != existTiles[nowY, nowX].colorNum)
            {
                return false;
            }
            
            checkArray[nowY, nowX] = true;

            for (int i = 0; i < 4; i++)
            {
                int nextX = nowX + moveX[i];
                int nextY = nowY + moveY[i];

                if (nextX >= 0 && nextX < width && nextY >= 0 && nextY < height)
                {
                    if (existTiles[nextY, nextX].isExist && !checkArray[nextY, nextX])
                    {
                        if (!Dfs(nextX, nextY, colorNum))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
