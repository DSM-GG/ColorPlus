using System.Collections;
using UnityEngine;

namespace UI.Effect
{
    public class ImageScaleFadeEffect : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 수치
        [SerializeField]
        private bool          isStartFade = false;                  // 시작시 바로 페이드
        [SerializeField]
        private bool          isStartInit = false;                  // 시작시 초기화
        [SerializeField]
        private float         minDelay = 0;                         // 최소 딜레이
        [SerializeField]
        private float         maxDelay = 0.2f;                      // 최대 딜레이
        [SerializeField]
        private Vector2       scale = Vector2.one;                  // 시작시 크기
        [SerializeField]
        private float         fadeGap = 0.01f;                      // 페이드 간격                   
        
        public  Vector2       goalScale = Vector2.zero;             // 목표 스케일
        public  float         fadeTime = 0.1f;                      // 페이드 시간
        
        // 인스펙터 비노출 변수
        // 일반
        private RectTransform thisRectTrans;                        // 이 오브젝트의 사각 트랜스폼
        
        // 수치
        private float         delay;                                // 딜레이

        
        // 초기화
        private void Awake()
        {
            thisRectTrans = GetComponent<RectTransform>();
        }
        
        // 오브젝트 켜짐
        private void OnEnable()
        {
            thisRectTrans.localScale = scale;
            
            if (isStartInit)
            {
                Initilize(minDelay, maxDelay);                
            }
            
            if (isStartFade)
            {
                FadeScaleImage();
            }
        }

        // 초기화
        public void Initilize(float min, float max)
        {
            delay = Random.Range(min, max);
        }
        
        // 크기 페이드 효과
        public void FadeScaleImage()
        {
            StartCoroutine(FadeSacleImageCor());
        }
        
        // 크기 페이드 효과 루틴
        private IEnumerator FadeSacleImageCor()
        {
            yield return new WaitForSeconds(delay);
            
            Vector2 originScale = thisRectTrans.localScale;
            int     count       = (int)(fadeTime / fadeGap);
            int     originCount = count;
            
            
            while (count > 0)
            {
                thisRectTrans.localScale = Vector2.Lerp(goalScale, originScale, (float)count / originCount);
                
                count -= 1;
                yield return new WaitForSeconds(fadeGap);
            }

            thisRectTrans.localScale = goalScale;
        }
    }
}
