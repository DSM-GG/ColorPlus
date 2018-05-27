using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class StartButton : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 노출 변수
        // 일반
        [SerializeField]
        private Image coverImage;                  // 커버 이미지
        
        // 인스펙터 비노출 변수
        // 수치
        private float timer = 0.4f;                // 패널 움직임 속도
        
        
        // 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            UIManager.instance.FadePositionFunc(0, new Vector2(-1280, 1280), timer);

            StartCoroutine(SetSelectPanel());
        }
        
        // 선택창 UI 켜기
        private IEnumerator SetSelectPanel()
        {
            yield return new WaitForSeconds(timer);
            
            UIManager.instance.FadeAlphaFunc(0, 1, 0, 0.3f);

            coverImage.raycastTarget = false;
        }
    }
}
