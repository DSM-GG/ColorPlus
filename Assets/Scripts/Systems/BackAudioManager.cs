using UI;
using UnityEngine;

namespace Systems
{
    public class BackAudioManager : MonoBehaviour
    {
        public static BackAudioManager instance;
        
        // 인스펙터 노출 변수
        // 일반
        [SerializeField]
        private AudioSource  audioSource;            // 해당 오디오 소스
        
        // 인스펙터 비노출 변수
        // 수치
        private bool         isEnabled = true;       // 배경음 활성화
        
        
        // 초기화
        private void Awake()
        {
            DontDestroyOnLoad(transform);

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
        }

        // 배경음 끄고 키기
        public void OnOffBackAudio()
        {
            isEnabled = !isEnabled;
            
            if (isEnabled)
            {
                UIManager.instance.SetText(1, "ON");
                audioSource.Play();
            }
            else
            {
                UIManager.instance.SetText(1, "OFF");
                audioSource.Stop();
            }
        }
    }
}
