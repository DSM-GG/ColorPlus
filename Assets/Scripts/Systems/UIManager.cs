using Board;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
		
        // 인스펙터 노출 변수
        [SerializeField]
        private Text[]             texts;				// 텍스트 집합
        [SerializeField]
        private GameObject[]       panels;             // ui 집합
		
		
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
            panels[index].SetActive(enable);
        }
        
        // 되돌리기 버튼
        public void RestoreGame()
        {
            BoardManager.instance.Restore();
        }

        // 다시하기 버튼
        public void ResetGame()
        {
            BoardManager.instance.ResetTile();
        }
        
        // 레벨 선택화면으로 돌아가기
        public void ReturnLevelList()
        {
            SceneManager.LoadScene("SeletScene");
        }
    }
}

