using System.Collections;
using UnityEngine;

namespace UI
{
    public class ImageScaleFadeEffect : MonoBehaviour
    {
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

        // 초기화
        public void Initilize(float min, float max)
        {
            delay = Random.Range(min, max);
        }
        
        // 크기 페이드 효과
        public void FadeScaleImage(Vector2 goalScale, float time)
        {
            StartCoroutine(FadeSacleImageCor(goalScale, time));
        }
        
        // 크기 페이드 효과 루틴
        private IEnumerator FadeSacleImageCor(Vector2 goalScale, float time)
        {
            yield return new WaitForSeconds(delay);
            
            Vector2 originScale = thisRectTrans.localScale;
            float   originTime  = time;
            
            
            while (time > 0)
            {
                thisRectTrans.localScale = Vector2.Lerp(goalScale, originScale, (time / originTime));
                
                time -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
