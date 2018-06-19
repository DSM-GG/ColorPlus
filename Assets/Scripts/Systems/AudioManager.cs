using UI;
using UnityEngine;

namespace Systems
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager instance;
		
		// 인스펙터 노출 변수
		// 일반
		[SerializeField]
		private AudioSource audioSource;            // 해당 오디오 소스
		[SerializeField]
		private AudioClip[] audioClip;              // 오디오 클립의 모음
		
		// 인스펙터 비노출 변수
		// 수치 
		private bool 		isEnabled = true;			// 켜져있니
	

		// 초기화
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			
			if (audioSource == null)
			{
				audioSource = GetComponent<AudioSource>();
			}
		}
		
		// 오디오 온오프
		public void OnOffAudio()
		{
			isEnabled = !isEnabled;

			if (isEnabled)
			{
				UIManager.instance.SetText(0, "ON");
			}
			else
			{
				UIManager.instance.SetText(0, "OFF");
			}
		}
		
		// 배경음 온오프
		public void OnOffBackAudio()
		{
			BackAudioManager.instance.OnOffBackAudio();
		}

		// 해당 인덱스의 소리 재생
		public void StartAudio(int index)
		{
			if (isEnabled)
			{
				// Index out of range exception
				if (index >= audioClip.Length)
				{
					return;
				}

				AudioClip targetClip = audioClip[index];

				// Null reference exception
				if (targetClip == null)
				{
					return;
				}
		
				audioSource.PlayOneShot(targetClip);				
			}
		}

		// 전체 소리재생 종료
		public void StopAudio()
		{
			audioSource.Stop();
		}

		// 전체 소리재생 정지
		public void PauseAudio()
		{
			audioSource.Pause();
		}
	
		// 전체 소리재생 정지 해제
		public void UnPauseAudio()
		{
			audioSource.UnPause();
		}

		// 오디오 소스 반환
		public AudioSource GetAudioSource()
		{
			return audioSource;
		}

		// 오디오 소스 설정
		public void SetAudioSource(AudioSource target)
		{
			audioSource = target;

			return;
		}
	}
}
