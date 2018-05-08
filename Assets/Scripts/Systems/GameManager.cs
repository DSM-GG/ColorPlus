using UnityEngine;

namespace Systems
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;
		
		// 인스펙터 비노출 변수
		// 수치
		[HideInInspector]
		public 	int 	originalTurnCount = 0;				// 원래의 턴 카운트
		
		private int 	turnCount = 0; 						// 턴 카운트


		// 초기화
		private void Awake()
		{
			instance = this;
			
			new Parser();
		}

		// 시작
		private void Start()
		{
			Parser.instance.Parse(1);

			ResetTurn();
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
