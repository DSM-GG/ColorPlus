using System.Collections;
using UnityEngine;

namespace UI.Effect
{
    public class ImageScaleFadeEffect : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 수치
        [SerializeField]
        private bool          isStartFade;          // 시작시 바로 페이드
        [SerializeField]
        private float         startDelay;           // 시작시 페이드할 때 초반 딜레이
        [SerializeField]
        private float         minDelay;             // 최소 딜레이
        [SerializeField]
        private float         maxDelay;             // 최대 딜레이
        
        public  Vector2       goalScale;            // 목표 스케일
        public  float         fadeTime;             // 페이드 시간
        
        // 인스펙터 비노출 변수
        // 일반
        private RectTransform thisRectTrans;        // 이 오브젝트의 사각 트랜스폼
        
        // 수치
        private float         delay;                // 딜레이

        
        // 초기화
        private void Awake()
        {
            thisRectTrans = GetComponent<RectTransform>();
        }

        private void Start()
        {
            if (isStartFade)
            {
                Initilize(minDelay, maxDelay);
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
            float   originTime  = fadeTime;
            
            
            while (fadeTime > 0)
            {
                thisRectTrans.localScale = Vector2.Lerp(goalScale, originScale, (fadeTime / originTime));
                
                fadeTime -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
