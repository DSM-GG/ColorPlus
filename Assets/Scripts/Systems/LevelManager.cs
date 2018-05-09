using UI;
using UnityEngine;

namespace Systems
{
	public class LevelManager
	{
		public static LevelManager instance;
		
		// 일반
		private ImageIniter 	imageIniter;			// 타일 초기화 스크립트
		
		// 수치
		private int 			level;					// 레벨
		private int 			height = 10;			// 세로
		private int 			width = 5;				// 가로
		
		
		// 싱글톤 초기화
		public static void Init()
		{
			if (instance == null)
			{
				instance = new LevelManager();
			}
		}
		
		// 생성자
		private LevelManager()
		{
		}
		
		// 레벨 셀렉터 초기화
		public void InitLevelSelecter(ImageIniter targetIminiter)
		{
			imageIniter = targetIminiter;
			level = 0;
			
			// 타일 초기화
			imageIniter.SetSize(height, width);
			imageIniter.TileInitialize();
			
			int lev = 1;
			
			
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					LevelSelecter targetSelecter = (imageIniter.tileArray[i, j] as Transform).GetComponent<LevelSelecter>();
					
					
					targetSelecter.SetLevel(lev++);
				}
			}
		}
		
		// 레벨 설정
		public void SetLevel(int value)
		{
			level = value;
		}
	}
}
