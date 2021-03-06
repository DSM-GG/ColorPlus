﻿using Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class OptionButton : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 노출 변수
        // 수치
        [SerializeField]
        private int         optionIndex;                // 옵션 패널 인덱스
        
        // 인스펙터 비노출 변수 
        // 수치
        private static bool enalbed = false;            // 활성화 여부

        
        // 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.instance.StartAudio(0);
            
            enalbed = !enalbed;

            UIManager.instance.SetUI(optionIndex, enalbed);
        }
    }
}
