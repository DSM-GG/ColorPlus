using UnityEngine;

namespace Design
{
    public class BrushManager : MonoBehaviour
    {
        public static BrushManager instance;
        
        // 인스펙터 노출 변수
        // 수치
        public int     brushColor;            // 브러쉬 색
        
        
        // 초기화
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            brushColor = 0;
        }
        
        // 색 변경
        public void SetColor(int color)
        {
            brushColor = color;
        }
    }
}
