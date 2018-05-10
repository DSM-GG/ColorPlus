using UnityEngine;
using UnityEngine.UI;

namespace Board.Tile
{
	public class TileColorManager : MonoBehaviour
	{
		// 인스펙터 비노출 변수
		// 일반
		private Image	image;               // 이 타일의 이미지


		// 초기화
		private void Awake()
		{
			image = GetComponent<Image>();
		}

		// 색 설정
		public void SetColor(int index)
		{
			image.sprite = BoardManager.instance.tileSprites[index];
		}
	}
}
