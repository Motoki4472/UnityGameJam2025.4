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
        private float masterVolume = 1f;
        private float bgmVolume = 1f;
        private float seVolume = 1f;
        public void Awake()
        {
            InitializeAudioMixer(audioMixer);
            InitializeVolumeSliders();
            
        }
        private void InitializeVolumeSliders()
        {
            masterSlider.value = masterVolume;
            bgmSlider.value = bgmVolume;
            seSlider.value = seVolume;
            masterSlider.minValue = 0.0001f;
            masterSlider.maxValue = 2f;
            bgmSlider.minValue = 0.0001f;
            bgmSlider.maxValue = 2f;
            seSlider.minValue = 0.0001f;
            seSlider.maxValue = 2f;
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
            mixer.SetFloat("Master", LinearToDecibel(master_value));
            mixer.SetFloat("BGM", LinearToDecibel(bgm_value));
            mixer.SetFloat("SE", LinearToDecibel(se_value));
        }

        public void SetMasterVolume(float value)
        {
            masterVolume = value;
            audioMixer.SetFloat("Master", LinearToDecibel(masterVolume));
        }
        public void SetBGMVolume(float value)
        {
            bgmVolume = value;
            audioMixer.SetFloat("BGM", LinearToDecibel(bgmVolume));
        }
        public void SetSEVolume(float value)
        {
            seVolume = value;
            audioMixer.SetFloat("SE", LinearToDecibel(seVolume));
        }

        void OnDestroy()
        {
            PlayerPrefsSystem.SaveVolumeSetting(masterVolume, bgmVolume, seVolume);
            PlayerPrefsSystem.SaveAll();
        }

        private static float LinearToDecibel(float linear)
        {
            return Mathf.Log10(linear) * 20f;
        }
    }
}
