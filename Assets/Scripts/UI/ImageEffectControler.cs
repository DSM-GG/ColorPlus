using UnityEngine;

namespace UI
{
    public class ImageEffectControler : MonoBehaviour
    {
        // 인스펙터 노출 변수
        // 일반
        public ImageScaleFadeEffect[] imageArray;            // 이미지 모음
        
        
        // 초기화
        private void Start()
        {
            imageArray = new ImageScaleFadeEffect[transform.childCount];
            
            for (int i = 0; i < transform.childCount; i++)
            {
                imageArray[i] = transform.GetChild(i).GetComponent<ImageScaleFadeEffect>();
                imageArray[i].Initilize(0.1f, 0.5f);
            }
        }
        
        // 이미지 전체 삭제
        public void DeleteAllImage()
        {
            for (int i = 0; i < imageArray.Length; i++)
            {
                imageArray[i].DeleteImage(0.2f);
            }
        }
    }
}
