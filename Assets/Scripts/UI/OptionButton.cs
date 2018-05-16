using Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class OptionButton : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 비노출 변수 
        // 수치
        private static bool enalbed;            // 활성화 여부

        
        // 초기화
        private void Awake()
        {
            enalbed = false;
        }

        // 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            enalbed = !enalbed;

            UIManager.instance.SetUI(0, enalbed);
        }
    }
}
