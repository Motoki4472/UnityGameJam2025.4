using UnityEngine;
using UnityEngine.Audio;
using App.Common.Data;
using UnityEngine.UI;

namespace App.Common.Camera
{
    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer = null;
        [SerializeField] private Slider masterSlider = null;
        [SerializeField] private Slider bgmSlider = null;
        [SerializeField] private Slider seSlider = null;
        private static _PlayerPrefsSystem PlayerPrefsSystem = new _PlayerPrefsSystem();
        private float masterVolume = 0f;
        private float bgmVolume = 0f;
        private float seVolume = 0f;
        public void Awake()
        {
            InitializeAudioMixer(audioMixer);
            masterSlider.value = masterVolume;
            bgmSlider.value = bgmVolume;
            seSlider.value = seVolume;
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            seSlider.onValueChanged.AddListener(SetSEVolume);
        }
        private static void InitializeAudioMixer(AudioMixer mixer)
        {
            PlayerPrefsSystem.LoadVolumeSetting(out float master_value, out float bgm_value, out float se_value);
            if (mixer == null)
            {
                Debug.LogError("AudioMixerがnullです。");
                return;
            }
            mixer.SetFloat("Master", master_value);
            mixer.SetFloat("BGM", bgm_value);
            mixer.SetFloat("SE", se_value);
        }

        public void SetMasterVolume(float value)
        {
            masterVolume = value;
            audioMixer.SetFloat("masterVolume", masterVolume);
        }
        public void SetBGMVolume(float value)
        {
            bgmVolume = value;
            audioMixer.SetFloat("bgmVolume", bgmVolume);
        }
        public void SetSEVolume(float value)
        {
            seVolume = value;
            audioMixer.SetFloat("seVolume", seVolume);
        }

        void OnDestroy()
        {
            PlayerPrefsSystem.SaveVolumeSetting(masterVolume, bgmVolume, seVolume);
            PlayerPrefsSystem.SaveAll();
        }
    }
}