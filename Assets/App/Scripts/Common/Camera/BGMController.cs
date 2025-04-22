using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace App.Common.Camera
{
    public class BGMController : MonoBehaviour
    {
        [SerializeField] List<AudioClip> BGMList = new List<AudioClip>();
        [SerializeField] private AudioMixer AudioMixer = null;
        [SerializeField] private AudioSource BGMSource = null;
        private static AudioClip[] staticBGMClips = null;

        string debugScene = "#101";

        void Start()
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

        public void PlayGameBGM()
        {
            InitializeAudioSource(BGMSource);
            BGMSource.clip = staticBGMClips[1];
            BGMSource.Play();
        }

        private void InitializeAudioSource(AudioSource audioSource)
        {
            audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups("BGM")[0];
            audioSource.loop = true;
            audioSource.playOnAwake = false;
        }
    }
}
