using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 수치
	public	bool				isExist = true;			// 존재 하는 타일인지
	public	int					posX;					// X좌표
	public	int					posY;                   // Y좌표

	// 인스펙터 비노출 변수
	// 일반
	private TileClick			tileClick;				// 타일 클릭 확인 스크립트
	private TileColorManager	tileColorManager;       // 타일 색 설정 스크립트


	// 초기화
	private void Awake()
	{
		tileClick			= GetComponent<TileClick>();
		tileColorManager	= GetComponent<TileColorManager>();
	}

	// 타일 초기화
	public void Initialize(int _posX, int _posY, int index)
	{
		// 색 설정
		tileColorManager.SetColor(index);

		// 위치 설정
		posX = _posX;
		posY = _posY;
	}
}
