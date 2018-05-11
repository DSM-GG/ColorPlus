using UnityEngine;

namespace Design
{
    public class BrushManager : MonoBehaviour
    {
        public static BrushManager instance;
        
        // 인스펙터 노출 변수
        // 수치
        public int     brushColor; 

        
        // 초기화
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            brushColor = 0;
        }
    }
}
