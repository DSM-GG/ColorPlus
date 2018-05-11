using Board;
using LevelSelect;
using UnityEngine;

namespace Systems
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;
		
		// 인스펙터 노출 변수
		// 수치
		[SerializeField]
		private bool 			useDefaultLevel = true;			// 디폴트 레벨 ( 0 )을 사용할지 여부
		
		// 인스펙터 비노출 변수
		// 수치
		[HideInInspector]
		public 	int 			originalTurnCount;				// 원래의 턴 카운트
		
		private int 			turnCount; 						// 턴 카운트
		private TileChecker 	tileChecker;					// 타일 체커
		

		// 초기화
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;	
			}
			
			Parser.Init();

			tileChecker = GetComponent<TileChecker>();
		}

		// 시작
		private void Start()
		{
			if (LevelManager.instance != null)
			{
				Parser.instance.Parse(LevelManager.instance.level);
				
				ResetTurn();
			}
			else if (useDefaultLevel)
			{
				Parser.instance.Parse(0);
				
				ResetTurn();
			}
		}
		
		// 타일 체크
		public void CheckTile()
		{
			if (tileChecker.CheckPuzzle())
			{
				Debug.Log("SDF");
			}
		}

		// 턴 조절
		public void AddTurn(int val)
		{
			turnCount += val;
			UIManager.instance.SetText(0, turnCount.ToString());
		}
		
		// 턴 확인
		public bool LeftTurn()
		{
			return turnCount > 0;
		}
		
		// 턴 초기화
		public void ResetTurn()
		{
			turnCount = originalTurnCount;
			UIManager.instance.SetText(0, turnCount.ToString());
		}
	}
}
