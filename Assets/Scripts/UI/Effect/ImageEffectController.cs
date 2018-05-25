using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Effect
{
    public class ImageEffectController : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 일반
        public List<ImageScaleFadeEffect> imageList;             // 이미지 모음
        
        // 수치
        public bool                       isStatCreate;          // 시작시 삭제 할거냐
        public float                      startDelay;            // 시작시 삭제할때 초반 딜레이
        public float                      fadeTime;              // 페이드 진행 시간
        public bool                       isStartInit;           // 시작 초기화 사용?
        
        
        // 초기화
        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ImageScaleFadeEffect target = transform.GetChild(i).GetComponent<ImageScaleFadeEffect>();


                if (target != null)
                {
                    imageList.Add(target);

                    if (isStartInit)
                    {
                        imageList[i].Initilize(0.1f, 0.3f);
                    }
                }
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
