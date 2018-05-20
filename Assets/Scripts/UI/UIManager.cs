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
        [SerializeField]
        private Text[]             texts;				// 텍스트 집합
        [SerializeField]
        private GameObject[]       panels;              // ui 집합
		
		
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
        }
        
        // 레벨 선택화면으로 돌아가기
        public void GotoScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        // 이동 효과
        public IEnumerator FadePosition(RectTransform target, Vector2 goalPos, float time)
        {
            float   originTime = time;
            Vector2 startPos   = target.position;
            
           
            while (time > 0)
            {
                target.position = Vector2.Lerp(goalPos, startPos, (time / originTime));
                
                time -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        // 알파 페이드 효과 ( 이미지 )
        public IEnumerator FadeAlpha(Image target, float goalAlpha, float time)
        {
            float originTime  = time;
            Color originColor = target.color;
            float startAlpha  = target.color.a;
            
            
            while (time > 0)
            {
                originColor.a = Mathf.Lerp(goalAlpha, startAlpha, (time / originTime));
                target.color  = originColor;
                
                time -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        // 알파 페이드 효과 ( 텍스트 )
        public IEnumerator FadeAlpha(Text target, float goalAlpha, float time)
        {
            float originTime  = time;
            Color originColor = target.color;
            float startAlpha  = target.color.a;
            
            
            while (time > 0)
            {
                originColor.a = Mathf.Lerp(startAlpha, goalAlpha, (time / originTime));
                target.color  = originColor;
                
                time -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        // 크기 변경 효과
        public IEnumerator FadeScale(RectTransform target, Vector2 goalScale, float time)
        {
            Vector2 originScale = target.localScale;
            float   originTime  = time;
            
            
            while (time > 0)
            {
                target.localScale = Vector2.Lerp(goalScale, originScale, (time / originTime));
                
                time -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}

