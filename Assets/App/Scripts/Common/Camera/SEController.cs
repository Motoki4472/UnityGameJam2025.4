using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace App.Common.Camera
{
    public class SEController : MonoBehaviour
    {
        [SerializeField] List<AudioClip> SEList = new List<AudioClip>();
        [SerializeField] private AudioMixer AudioMixer = null;
        [SerializeField] private AudioSource SESource = null;
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

        public void PlaySE(int clip)
        {
            Debug.Log($"PlaySE: {clip}");
            SESource.clip = staticSEClips[clip];
            SESource.Play();
        }

        private void InitializeAudioSource(AudioSource audioSource)
        {
            audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups("SE")[0];
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }
    }
}
