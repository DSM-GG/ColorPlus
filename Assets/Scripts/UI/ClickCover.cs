using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClickCover : MonoBehaviour
    {
        // 인스펙터 비노출 변수
        // 일반
        private Image      thisImage;             // 커버 이미지
        
        // 수치
        [HideInInspector]
        public int         coverCount;            // 커버 카운트 ( 0이 되면 커버 없음 )
        
        
        // 초기화 
        private void Awake()
        {
            thisImage = GetComponent<Image>();
            
            RefreshCover();
        }

        // 커버 카운트 증가
        public void AddCoverCount(int value)
        {
            coverCount += value;
            
            RefreshCover();
        }
        
        // 커버 상태 새로고침
        public void RefreshCover()
        {
            if (coverCount <= 0)
            {
                thisImage.raycastTarget = false;
            }
            else
            {
                thisImage.raycastTarget = true;
            }
        }
    }
}
