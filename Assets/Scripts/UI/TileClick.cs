using Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
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
			// 턴 확인 후 클릭 진행
			if (GameManager.instance.LeftTurn())
			{
				GameManager.instance.AddTurn(-1);
				BoardManager.instance.CrossDel(tile.posX, tile.posY);
			}
		}
	}
}

