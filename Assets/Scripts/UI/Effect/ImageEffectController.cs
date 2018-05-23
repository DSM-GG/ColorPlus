using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Effect
{
    public class ImageEffectController : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 일반
        public List<ImageScaleFadeEffect> imageList;             // 이미지 모음
        public bool                       isStatCreate;          // 시작시 삭제 할거냐
        public float                      startDelay;            // 시작시 삭제할때 초반 딜레이
        public float                      fadeTime;              // 페이드 진행 시간
        
        
        // 초기화
        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                imageList.Add(transform.GetChild(i).GetComponent<ImageScaleFadeEffect>());
                imageList[i].Initilize(0.1f, 0.3f);
            }

            if (isStatCreate)
            {
                StartCoroutine(StartCreate());
            }
        }
        
        // 이미지 전체 페이드
        public void FadeAllImage(Vector2 goalScale)
        {
            for (int i = 0; i < imageList.Count; i++)
            {
                imageList[i].fadeTime = fadeTime;
                imageList[i].goalScale = goalScale;
                imageList[i].FadeScaleImage();
            }
        }
        
        // 시작시 생성
        private IEnumerator StartCreate()
        {
            yield return new WaitForSeconds(startDelay);
            
            FadeAllImage(Vector2.one);
        }
    }
}
