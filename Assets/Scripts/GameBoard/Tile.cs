using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 수치
	public  int			colorNum;               // 실제 사용되는 색 번호
	public  bool		isExist = true;         // 존재 하는 타일인지
	public  int			posX;					// X좌표
	public  int			posY;					// Y좌표

	// 인스펙터 비노출 변수
	// 일반
	private Image		thisImg;                // 해당 타일 이미지
	private TileClick	tileClick;              // 타일 클릭객체

	// 수치
	private int			originalColorNum;       // 실제 사용되는 색 번호


	// 초기화
	private void Awake()
	{
		thisImg   = GetComponent<Image>();
		tileClick = GetComponent<TileClick>();
	}

	// 타일 위치 설정
	public void SetPosition(int x, int y)
	{
		posX = x;
		posY = y;
	}

	// 타일 색 변경 검사
	public void SetColorNum(int index)
	{
		if (index <= 0)
		{
			Debug.Log("in SetColorNum parameter is zero");
		}
		else
		{
			SetColorNum_unsafe(index);
		}
	}

	// 타일 색 원시값 변경
	public void SetOriginalColorNum(int index)
	{
		if (index > 0)
		{
			originalColorNum = index;

			SetColorNum(index);
		}
	}

	// 타일 색 변경
	private void SetColorNum_unsafe (int index)
	{
		colorNum = index;

		thisImg.sprite = Board.instance.tileSprites[index];
	}

	// 타일 비활성화
	public bool TileDisable()
	{
		if (isExist)
		{
			isExist = false;
			SetColorNum_unsafe(0);
			tileClick.enabled = false;
			
			return true;
		}
		else
		{
			return false;
		}
	}

	// 타일 활성화
	public void TileEnable()
	{
		if (!isExist)
		{
			isExist = true;
			SetColorNum_unsafe(originalColorNum);
			tileClick.enabled = true;
		}
	}
}
