using System.Collections;
using Systems;
using UI;
using UnityEngine;

namespace Board.Tile
{
	public class Tile : MonoBehaviour
	{
		// 인스펙터 노출 변수
		// 일반
		public GameObject 			desEffect;				// 파괴 이펙트
		
		// 수치
		public	bool				isExist = true;			// 존재 하는 타일인지
		public	int					posX;					// X좌표
		public	int					posY;                   // Y좌표
		public	int					colorNum;				// 색 번호
		public 	float 				fadeTime;				// 페이드 시간

		// 인스펙터 비노출 변수
		// 일반
		private TileClick			tileClick;				// 타일 클릭 확인 스크립트
		private TileColorManager	tileColorManager;       // 타일 색 설정 스크립트
		private RectTransform 		thisRect;				// 타일 이미지 렉트트랜스폼


		// 초기화
		private void Awake()
		{
			tileClick			= GetComponent<TileClick>();
			tileColorManager	= GetComponent<TileColorManager>();
			thisRect 			= GetComponent<RectTransform>();
		}

		// 타일 초기화
		public void Initialize(int newPosX, int newPosY, int index)
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
			posX = newPosX;
			posY = newPosY;
		}

		// 타일 비활성화
		public bool TileDisable(int time)
		{
			if (isExist)
			{
				isExist = false;
				StartCoroutine("DisableEffect", time);
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
					thisRect.localScale = Vector2.one;
					isExist = true;
					tileColorManager.SetColor(colorNum);
					tileClick.enabled = true;
				}
			}
		}

		// 비활성화 이펙트
		private IEnumerator DisableEffect(int time)
		{
			GameManager.instance.clickCover.AddCoverCount(1);
			
			yield return new WaitForSeconds(time * 0.1f);
			
			GameObject particle = Instantiate(desEffect, transform.position, Quaternion.identity);
			StartCoroutine(UIManager.instance.FadeScale(thisRect, Vector2.zero, fadeTime));
			
			yield return new WaitForSeconds(fadeTime);
			
			tileColorManager.SetColor(0);
			thisRect.localScale = Vector2.one;
			
			GameManager.instance.clickCover.AddCoverCount(-1);
			
			yield return new WaitForSeconds(1f);
			
			Destroy(particle);
		}
	}
}
