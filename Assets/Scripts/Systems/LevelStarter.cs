using UI;
using UnityEngine;

namespace Systems
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
