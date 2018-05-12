using LevelSelect;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelChangeButton : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 노출 변수
        // 수치
        [SerializeField]
        private int     leveloffset;                    // 레벨 오프셋
        
        // 인스펙터 비노출 변수
        // 수치
        private int     nextLevel;                      // 다음 레벨
        
        
        // 시작
        private void Start()
        {
            nextLevel = LevelManager.instance.level + leveloffset;


            if (nextLevel > LevelManager.instance.finalLevel || nextLevel < 1)
            {
                Destroy(gameObject);
            }
        }

        // 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            LevelManager.instance.level = nextLevel;
            
            SceneManager.LoadScene("MainScene");
        }
    }
}
