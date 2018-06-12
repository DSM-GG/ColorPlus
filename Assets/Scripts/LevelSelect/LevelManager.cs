using Systems;
using UI.Effect;
using UnityEngine;

namespace LevelSelect
{
	public class LevelManager
	{
		public static LevelManager instance;
		
		// 일반
		private ImageIniter 	imageIniter;			// 타일 초기화 스크립트
		
		// 수치
		public 	int 			level;					// 레벨
		public  int 			lastLevel;              // 마지막 레벨
		public	int				maxLevel = 100;			// 최종 레벨
		
		private int 			height = 20;			// 세로
		private int 			width = 5;				// 가로
		
		
		// 생성자
		private LevelManager()
		{
		}
		
		// 싱글톤 초기화
		public static void Init()
		{
			if (instance == null)
			{
				instance = new LevelManager();
			}
		}
		
		// 레벨 셀렉터 초기화
		public void InitLevelSelecter(ImageIniter targetIminiter)
		{
			imageIniter = targetIminiter;
			lastLevel = PlayerPrefs.GetInt("LastLevel", 1);
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
		
		// 마지막 레벨 재설정
		public void SetLastLevel()
		{
			level++;
			lastLevel = Mathf.Max(level, lastLevel);
			
			PlayerPrefs.SetInt("LastLevel", lastLevel);

			if (lastLevel > maxLevel)
			{
				GameManager.instance.targetScene = "CreditScene";
			}
		}
	}
}
