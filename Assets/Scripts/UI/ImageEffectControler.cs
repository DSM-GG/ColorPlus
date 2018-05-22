using System.Collections;
using UnityEngine;

namespace UI
{
    public class ImageEffectControler : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 일반
        public ImageScaleFadeEffect[] imageArray;            // 이미지 모음
        public bool                   isStatDelete;          // 시작시 삭제 할거냐
        public float                  startDelay;            // 시작시 삭제할때 초반 딜레이
        public float                  fadeTime;              // 페이드 진행 시간
        
        
        // 초기화
        private void Start()
        {
            imageArray = new ImageScaleFadeEffect[transform.childCount];
            
            for (int i = 0; i < transform.childCount; i++)
            {
                imageArray[i] = transform.GetChild(i).GetComponent<ImageScaleFadeEffect>();
                imageArray[i].Initilize(0.1f, 0.3f);
            }

            if (isStatDelete)
            {
                StartCoroutine(StartDelete());
            }
        }
        
        // 이미지 전체 페이드
        public void DeleteAllImage(Vector2 goalScale)
        {
            for (int i = 0; i < imageArray.Length; i++)
            {
                imageArray[i].FadeScaleImage(goalScale, fadeTime);
            }
        }
        
        // 시작 삭제
        private IEnumerator StartDelete()
        {
            yield return new WaitForSeconds(startDelay);
        }
    }
}
