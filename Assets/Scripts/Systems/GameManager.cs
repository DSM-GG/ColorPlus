using System.Collections;
using Board;
using LevelSelect;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;
		
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
			if (LevelManager.instance == null)
			{
				LevelManager.Init();
				LevelManager.instance.level = 0;
			}
			
			Parser.instance.Parse(LevelManager.instance.level);
				
			ResetTurn();
			UIManager.instance.SetText(1, "#" + LevelManager.instance.level);
		}
		
		// 타일 체크
		public void CheckTile()
		{
			if (tileChecker.CheckPuzzle())
			{
				GameOver();
			}
		}
		
		// 게임 종료
		private void GameOver()
		{
			LevelManager.instance.SetLastLevel();
			Debug.Log("GOOG");
			StartCoroutine(GotoNextLevel());
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
		
		// 다음 레벨 루틴
		private IEnumerator GotoNextLevel()
		{
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene("MainScene");
		}
	}
}
