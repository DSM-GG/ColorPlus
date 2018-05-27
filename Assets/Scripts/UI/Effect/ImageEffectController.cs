using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Effect
{
    public class ImageEffectController : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 일반
        public  List<ImageScaleFadeEffect> imageList;             // 이미지 모음
        
        // 수치
        [SerializeField]
        private bool                       isStatFade;            // 시작시 페이드를 진행할지
        [SerializeField]
        private float                      startDelay;            // 시작시 페이드 전 딜레이
        [SerializeField]
        private float                      fadeTime;              // 페이드 진행 시간
        [SerializeField]
        private bool                       isStartInit;           // 시작 초기화 사용할지
        [SerializeField]
        private float                      minDelay;              // 최소 딜레이
        [SerializeField] 
        private float                      maxDelay;              // 최대 딜레이
        
        
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
                        imageList[i].Initilize(minDelay, maxDelay);
                    }
                }
            }

            if (isStatFade)
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
