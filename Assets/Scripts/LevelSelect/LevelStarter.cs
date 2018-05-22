using UI;
using UI.Effect;
using UnityEngine;

namespace LevelSelect
{
    public class LevelStarter : MonoBehaviour
    {
        // 인스펙터 노출 변수
        [SerializeField]
        private ImageIniter     imageIniter;                // 이미지 초기화
        
        
        // 초기화
        private void Awake()
        {
            LevelManager.Init();
        }
        
        // 시작
        private void Start()
        {
            LevelManager.instance.InitLevelSelecter(imageIniter);
        }
    }
}
