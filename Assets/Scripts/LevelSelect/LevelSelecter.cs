using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelSelect
{
    public class LevelSelecter : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 노출 변수
        // 수치
        public int     level;                    // 레벨
        
        // 인스펙터 비노출 변수
        // 일반
        private Text   levelText;                // 레벨 텍스트
        private Button levelButton;              // 레벨 버튼
        
        
        // 초기화
        private void Awake()
        {
            level = 0;

            levelText   = GetComponentInChildren<Text>();
            levelButton = GetComponentInChildren<Button>();
        }
    
        // 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            LevelManager.instance.level = level;
            
            SceneManager.LoadScene("MainScene");
        }
        
        // 레벨 설정
        public void SetLevel(int value)
        {
            level = value;
            levelText.text = level.ToString();

            if (LevelManager.instance.finalLevel < level)
            {
                levelButton.interactable = false;
            }
        }
    }
}
