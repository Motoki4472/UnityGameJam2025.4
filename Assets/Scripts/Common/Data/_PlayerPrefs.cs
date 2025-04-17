using UnityEngine;

namespace App.Common.Data
{
    public class _PlayerPrefsSystem
    {
        public void SaveVolumeSetting(float master_value, float bgm_value, float se_value)
        {
            SetFloat("masterVolume", master_value);
            SetFloat("bgmVolume", bgm_value);
            SetFloat("seVolume", se_value);
        }

        public void LoadVolumeSetting(out float master_value, out float bgm_value, out float se_value)
        {
            master_value = GetFloat("masterVolume");
            bgm_value = GetFloat("bgmVolume");
            se_value = GetFloat("seVolume");
        }

        public void SaveAll()
        {
            UnityEngine.PlayerPrefs.Save();
        }

        private void SetFloat(string key, float value)
        {
            UnityEngine.PlayerPrefs.SetFloat(key, value);
        }

        private float GetFloat(string key)
        {
            return UnityEngine.PlayerPrefs.GetFloat(key);
        }

        private void DeleteKey(string key)
        {
            UnityEngine.PlayerPrefs.DeleteKey(key);
        }

        private void DeleteAll()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
    }
}