using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private RectTransform	rectTransform;          // 타겟 사각 트랜스폼

	// 인스펙터 비노출 변수
	// 수치
	private float			startPos;               // 시작할 때의 위치값
	private Vector2			previousPos;			// 이전 마우스 위치
	

	// 초기화
	private void Awake()
	{
		startPos = rectTransform.anchoredPosition.y;
	}

	// 드래그 중
	public void OnDrag(PointerEventData pointerEventData)
	{
		Vector2 nowPos = pointerEventData.position;
		Vector2 nextPos = new Vector2(0, rectTransform.anchoredPosition.y - (previousPos.y - nowPos.y));

		if (nextPos.y > startPos && nextPos.y < -startPos)
		{
			rectTransform.anchoredPosition = nextPos;
			previousPos = pointerEventData.position;
		}
	}

	// 드래그 시작
	public void OnBeginDrag(PointerEventData pointerEventData)
	{
		previousPos = pointerEventData.position;
	}
	
	// 드래그 종료
	public void OnEndDrag(PointerEventData pointerEventData)
	{

	}
}
