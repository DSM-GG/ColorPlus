using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerClickHandler
{
	// 인스펙터 비노출 변수
	// 일반
	private Tile	tile;                // 타일


	// 초기화
	private void Awake()
	{
		tile = GetComponent<Tile>();
	}

	// 마우스 클릭
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		BoardManager.instance.CrossDel(tile.posX, tile.posY);
	}
}
