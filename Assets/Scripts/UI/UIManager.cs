using System.Collections;
using Board;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
		
        // 인스펙터 노출 변수
        // 일반
        [SerializeField]
        private Text[]             texts;				 // 텍스트 집합
        [SerializeField]
        private GameObject[]       panels;              // ui 집합
		
        // 수치
        [SerializeField]
        private float              fadeGap;             // 페이드 효과 간격
        
		
        // 초기화
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        // 텍스트 설정
        public void SetText(int index, string str)
        {
            texts[index].text = str;
        }
        
        // UI 설정
        public void SetUI(int index, bool enable)
        {
            panels[index].gameObject.SetActive(enable);
        }
        
        // 되돌리기 버튼
        public void RestoreGame()
        {
            BoardManager.instance.Restore();
        }
        
        // UI 이동
        public void FadePositionFunc(int index, Vector2 goalPos, float time)
        {
            StartCoroutine(FadePosition(panels[index].GetComponent<RectTransform>(), goalPos, time));
        }
        
        // UI 알파 변경
        public void FadeAlphaFunc(int arrayOffset, int index, float goalAlpha, float time)
        {
            switch (arrayOffset)
            {
                case 0:
                    StartCoroutine(FadeAlpha(panels[index].GetComponent<Image>(), goalAlpha, time));
                    
                    break;
                case 1:
                    StartCoroutine(FadeAlpha(texts[index], goalAlpha, time));
                    
                    break;
                default:
                    Debug.Log("arrayOffset");
                    
                    break;
            }
        }
        
        // UI 크기 변경
        public void FadeScaleFunc(int index, Vector2 goalScale, float time)
        {
            StartCoroutine(FadeScale(panels[index].GetComponent<RectTransform>(), goalScale, time));
        }

        // 다시하기 버튼
        public void ResetGame()
        {
            BoardManager.instance.ResetTile();

            panels[2].SetActive(false);
            panels[2].SetActive(true);
        }
        
        // 레벨 선택화면으로 돌아가기
        public void GotoScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        // 이동 효과
        public IEnumerator FadePosition(RectTransform target, Vector2 goalPos, float time)
        {
            Vector2 startPos    = target.position;
            int     count       = (int)(time / fadeGap);
            int     originCount = count;      
           
            while (count > 0)
            {
                target.position = Vector2.Lerp(goalPos, startPos, (float)count / originCount);
                
                count -= 1;
                yield return new WaitForSeconds(fadeGap);
            }

            target.position = goalPos;
        }
        
        // 알파 페이드 효과 ( 이미지 )
        public IEnumerator FadeAlpha(Image target, float goalAlpha, float time)
        {
            Color originColor = target.color;
            float startAlpha  = target.color.a;
            int   count       = (int)(time / fadeGap);
            int   originCount = count;      
            
            while (count > 0)
            {
                originColor.a = Mathf.Lerp(goalAlpha, startAlpha, (float)count / originCount);
                target.color  = originColor;
                
                count -= 1;
                yield return new WaitForSeconds(fadeGap);
            }

            originColor.a = goalAlpha;
            target.color = originColor;
        }
        
        // 알파 페이드 효과 ( 텍스트 )
        public IEnumerator FadeAlpha(Text target, float goalAlpha, float time)
        {
            Color originColor = target.color;
            float startAlpha  = target.color.a;
            int   count       = (int)(time / fadeGap);
            int   originCount = count;   
            
            while (count > 0)
            {
                originColor.a = Mathf.Lerp(startAlpha, goalAlpha, (float)count / originCount);
                target.color  = originColor;
                
                count -= 1;
                yield return new WaitForSeconds(fadeGap);
            }
            
            originColor.a = goalAlpha;
            target.color = originColor;
        }
        
        // 크기 변경 효과
        public IEnumerator FadeScale(RectTransform target, Vector2 goalScale, float time)
        {
            Vector2 originScale = target.localScale;
            int     count = (int)(time / fadeGap);
            int     originCount = count;
            
            
            while (count > 0)
            {
                target.localScale = Vector2.Lerp(goalScale, originScale, (float)count / originCount);
                
                count -= 1;
                yield return new WaitForSeconds(fadeGap);
            }
            
            target.localScale = goalScale;
        }
    }
}

