using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	// 인스펙터 노출 변수
	// 수치
	public  int				originalTurn;           // 남은 턴수
	public  int			    level = 1;				// 현재 레벨

	// 인스펙터 비노출 변수
	// 일반
	private LevelParser		levelParser;            // 레벨데이터 파싱객체	
	private int				turn;					// 실제 남은 턴수


	// 초기화
	private void Awake()
	{
		instance    = this;

		levelParser = new LevelParser();
	}

	// 시작
	private void Start()
	{
		// 데이터 파싱
		levelParser.Parse(1);
		ResetTurn();

		// 타일 세팅
		Board.instance.SetTile();
	}

	// 타일 클릭
	public bool TileClick()
	{
		return true;

		// 클릭 가능
		if (turn > 0)
		{
			AddTurn(-1);

			return true;
		}
		// 클릭 불가능
		else
		{
			return false;
		}
	}

	// 턴 초기화
	public void ResetTurn()
	{
		turn = originalTurn;

		UIManager.instance.SetTurnText(turn);
	}

	// 턴 감소
	public void AddTurn(int value)
	{
		turn += value;

		UIManager.instance.SetTurnText(turn);
	}
}
