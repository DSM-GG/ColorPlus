using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	// 인스펙터 노출 변수
	// 일반
	public  int				turn;                   // 남은 턴수
	public  int			    level = 1;				// 현재 레벨

	// 인스펙터 비노출 변수
	// 일반
	private LevelParser		levelParser;            // 레벨데이터 파싱객체	


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

		// 타일 세팅
		Board.instance.SetTile();

		// UI 설정
		UIManager.instance.SetTurnText(turn);
	}

	// 타일 클릭
	public bool TileClick()
	{
		return true;

		// 클릭 가능
		if (turn > 0)
		{
			DownTurn();

			return true;
		}
		// 클릭 불가능
		else
		{
			return false;
		}
	}

	// 턴 감소
	private void DownTurn()
	{
		turn--;

		UIManager.instance.SetTurnText(turn);
	}
}
