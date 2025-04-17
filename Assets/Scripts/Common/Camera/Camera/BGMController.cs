using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace App.Common.Camera
{
    public class BGMController : MonoBehaviour
    {
        [SerializeField] List<AudioClip> BGMList = new List<AudioClip>();
        [SerializeField] private static AudioMixer AudioMixer = null;
        [SerializeField] private static AudioSource BGMSource = null;
        private static AudioClip[] staticBGMClips = null;

        string debugScene = "";

        void Awake()
        {
            Scene current = SceneManager.GetActiveScene();
            if (staticBGMClips == null)
            {
                staticBGMClips = new AudioClip[BGMList.Count];
                for (int i = 0; i < BGMList.Count; i++)
                {
                    staticBGMClips[i] = BGMList[i];
                }
            }
            if ((current.name != "Game") && (current.name != debugScene))
            {
                InitializeAudioSource(BGMSource);
                BGMSource.clip = staticBGMClips[0];
                BGMSource.Play();
            }
        }

        public static void PlayGameBGM()
        {
            InitializeAudioSource(BGMSource);
            BGMSource.clip = staticBGMClips[1];
            BGMSource.Play();
        }

        private static void InitializeAudioSource(AudioSource audioSource)
        {
            if (audioSource == null)
            {
                Debug.LogError("AudioSourceがnullです。");
                return;
            }
            if (audioSource.clip == null)
            {
                Debug.LogError("AudioClipがnullです。");
                return;
            }
            if (AudioMixer == null)
            {
                Debug.LogError("AudioMixerがnullです。");
                return;
            }
            audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups("BGM")[0];
            audioSource.loop = true;
            audioSource.playOnAwake = false;
        }
    }
}
