using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace App.Common.Camera
{
    public class SEController : MonoBehaviour
    {
        [SerializeField] List<AudioClip> SEList = new List<AudioClip>();
        [SerializeField] private static AudioMixer AudioMixer = null;
        private static AudioSource SESource = null;
        private static AudioClip[] staticSEClips = null;

        void Awake()
        {
            if (staticSEClips == null)
            {
                staticSEClips = new AudioClip[SEList.Count];
                for (int i = 0; i < SEList.Count; i++)
                {
                    staticSEClips[i] = SEList[i];
                }
            }
            InitializeAudioSource(SESource);
            SESource.clip = staticSEClips[0];
        }

        public static void PlaySE(int clip)
        {
            SESource.clip = staticSEClips[clip];
            SESource.Play();
        }

        private static void InitializeAudioSource(AudioSource audioSource)
        {
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
            audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups("SE")[0];
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }
    }
}
