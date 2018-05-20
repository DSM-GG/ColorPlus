using UnityEngine;

namespace Board.Tile
{
	public class Tile : MonoBehaviour
	{
		// 인스펙터 노출 변수
		// 수치
		public	bool				isExist = true;			// 존재 하는 타일인지
		public	int					posX;					// X좌표
		public	int					posY;                   // Y좌표
		public	int					colorNum;				// 색 번호

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
		public void Initialize(int posX, int posY, int index)
		{
			// 색 설정
			colorNum = index;
			tileColorManager.SetColor(colorNum);

			if (colorNum == 0)
			{
				isExist = false;
				tileClick.enabled = false;
			}

			// 위치 설정
			this.posX = posX;
			this.posY = posY;
		}

		// 타일 비활성화
		public bool TileDisable()
		{
			if (isExist)
			{
				isExist = false;
				tileColorManager.SetColor(0);
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
			if (colorNum != 0)
			{
				if (!isExist)
				{
					isExist = true;
					tileColorManager.SetColor(colorNum);
					tileClick.enabled = true;
				}
			}
		}
	}
}
