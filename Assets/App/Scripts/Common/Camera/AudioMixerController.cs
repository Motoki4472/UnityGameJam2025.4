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
        private static float masterVolume = 1f;
        private static float bgmVolume = 1f;
        private static float seVolume = 1f;
        static float a, b, c;
        public void Awake()
        {
            InitializeAudioMixer(audioMixer);
            InitializeVolumeSliders();
        }
        public void Start()
        {
            SetBGMVolume(bgmVolume);
            SetSEVolume(seVolume);
            SetMasterVolume(masterVolume);
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
            PlayerPrefsSystem.LoadVolumeSetting(out masterVolume, out bgmVolume, out seVolume);
            if (mixer == null)
            {
                Debug.LogError("AudioMixerがnullです。");
                return;
            }
            mixer.SetFloat("Master", LinearToDecibel(masterVolume));
            mixer.SetFloat("BGM", LinearToDecibel(bgmVolume));
            mixer.SetFloat("SE", LinearToDecibel(seVolume));
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
