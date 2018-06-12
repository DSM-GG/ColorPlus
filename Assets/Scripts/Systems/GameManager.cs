using System.Collections;
using Board;
using LevelSelect;
using UI;
using UI.Effect;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;

		// 인스펙터 노출 변수
		// 일반
		public ClickCover 				clickCover;						// 클릭 커버
		public ImageEffectController 	imageEffectController;			// 이미지 이펙트 컨트롤러
		
		// 인스펙터 비노출 변수
		// 수치
		[HideInInspector]
		public 	int 					originalTurnCount;				// 원래의 턴 카운트
		[HideInInspector]
		public string 					targetScene;					// 다음 넘어갈 씬
		
		private int 					turnCount; 						// 턴 카운트
		private TileChecker 			tileChecker;					// 타일 체커
		

		// 초기화
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;	
			}
			
			Parser.Init();
			
			targetScene = "MainScene";
			
			tileChecker = GetComponent<TileChecker>();
		}

		// 시작
		private void Start()
		{
			UIManager.instance.FadeAlphaFunc(0, 1, 0, 0.2f);
		
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
			AudioManager.instance.StartAudio(1);
			
			if (tileChecker.CheckPuzzle())
			{
				GameOver();
			}
		}
		
		// 게임 종료
		private void GameOver()
		{
			// 클릭 제어
			clickCover.AddCoverCount(1);
			
			// 레벨 설정 및 다음 레벨 진행
			LevelManager.instance.SetLastLevel();
			StartCoroutine(GotoNextLevel());
		}
		
		// 턴 조절
		public void AddTurn(int val)
		{
			turnCount += val;
			UIManager.instance.SetText(2, turnCount.ToString());
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
			UIManager.instance.SetText(2, turnCount.ToString());
		}
		
		// 다음 레벨 루틴
		private IEnumerator GotoNextLevel()
		{
			yield return new WaitForSeconds(2f);
			
			// 효과음
			AudioManager.instance.StartAudio(2);
			
			imageEffectController.Initilize();
			imageEffectController.FadeAllImage(Vector2.zero);
			
			yield return new WaitForSeconds(1f);
			
			SceneManager.LoadScene(targetScene);
		}
	}
}
