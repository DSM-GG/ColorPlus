using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LevelSelect
{
    public class LevelSelecter : MonoBehaviour, IPointerClickHandler
    {
        // 수치
        public int     level;
        
        
        // 초기화
        private void Awake()
        {
            level = 0;
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
        }
    }
}
