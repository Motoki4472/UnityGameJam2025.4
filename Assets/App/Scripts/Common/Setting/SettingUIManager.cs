using UnityEngine;

namespace App.Scripts.Common.Setting
{
    public class SettingUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject settingCanvas;

        public void OpenSetting()
        {
            settingCanvas.SetActive(true);
        }

        public void CloseSetting()
        {
            settingCanvas.SetActive(false);
        }
    }
}
