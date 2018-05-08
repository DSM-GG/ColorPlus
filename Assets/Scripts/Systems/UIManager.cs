using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager instance;
		
		// 인스펙터 노출 변수
		[SerializeField]
		private Text[] 		texts;				// 텍스트 집합
		
		
		// 초기화
		private void Awake()
		{
			instance = this;
		}

		// 텍스트 설정
		public void SetText(int index, string str)
		{
			texts[index].text = str;
		}
	}
}

