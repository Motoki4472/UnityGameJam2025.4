using UnityEngine;
using App.Common._SceneChange;

namespace App.Title.Camera
{
    public class ResultDataHolder : MonoBehaviour
    {
        public static ResultDataHolder Instance { get; private set; }

        public int finalActiveUserNumber { get; set; } = 0;
        public int maxActiveUserNumber { get; set; } = 0;

        public _SceneChangeManager.EndName endName { get; set; } = _SceneChangeManager.EndName.BadEnd;

        private void Awake()
        {
            Instance = this;
        }
    }
}
