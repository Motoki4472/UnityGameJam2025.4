using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace App.Game.Profile
{
    public class ProfileImageHolder : MonoBehaviour
    {
        [SerializeField] private List<Sprite>[] _sourceImages;
        [SerializeField] private GameObject _imagePrefab;

        public void GenerateProfileImage(int[] ImageID)
        {
            if (_sourceImages == null || _sourceImages.Length == 0)
            {
                Debug.LogError("Source images are not set.");
                return;
            }

            for (int i = 0; i < ImageID.Length; i++)
            {
                if (ImageID[i] < 0 || ImageID[i] >= _sourceImages.Length)
                {
                    Debug.LogError($"Invalid ImageID: {ImageID[i]}");
                    continue;
                }

                List<Sprite> images = _sourceImages[ImageID[i]];
                if (images != null && images.Count > 0)
                {
                    // ここで画像を使用する処理を追加
                    // 例: GetComponent<Image>().sprite = images[0];
                }
                else
                {
                    Debug.LogError($"No images found for ImageID: {ImageID[i]}");
                }
            }
        }
    }
}