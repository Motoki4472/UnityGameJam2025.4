using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace App.Scripts.Common.Setting
{
    public class SettingUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject settingCanvas; // 設定用の Canvas
        [SerializeField] private GameObject tutorialCanvas; // チュートリアル用の Canvas
        [SerializeField] private List<Sprite> tutorialImages; // チュートリアル画像のリスト
        [SerializeField] private Image tutorialImageDisplay; // チュートリアル画像を表示する UI
        [SerializeField] private GameObject nextButton; // 次の画像ボタン
        [SerializeField] private GameObject previousButton; // 前の画像ボタン
        [SerializeField] private GameObject specialImage1; // 特定のインデックスで表示する GameObject
        [SerializeField] private GameObject specialImage2; // 特定のインデックスで表示する GameObject

        private int currentImageIndex = 0; // 現在表示中の画像のインデックス

        public void OpenSetting()
        {
            settingCanvas.SetActive(true);
        }

        public void CloseSetting()
        {
            settingCanvas.SetActive(false);
        }

        public void OpenTutorial()
        {
            if (tutorialImages == null || tutorialImages.Count == 0)
            {
                Debug.LogError("Tutorial images are not set.");
                return;
            }

            // 最初の画像を表示
            tutorialImageDisplay.sprite = tutorialImages[currentImageIndex];
            tutorialCanvas.SetActive(true);
            UpdateButtonVisibility(); // ボタンの表示状態を更新
        }

        // チュートリアル Canvas を非アクティブにする
        public void CloseTutorial()
        {
            currentImageIndex = 0; // インデックスをリセット
            tutorialCanvas.SetActive(false);
            UpdateButtonVisibility(); // ボタンの表示状態を更新
        }

        // 次の画像を表示する
        public void ShowNextImage()
        {
            if (tutorialImages == null || tutorialImages.Count == 0)
            {
                Debug.LogError("Tutorial images are not set.");
                return;
            }

            // インデックスを次に進める
            currentImageIndex++;
            if (currentImageIndex >= tutorialImages.Count)
            {
                currentImageIndex = tutorialImages.Count - 1; // 最後の画像に固定
            }

            // 画像を更新
            tutorialImageDisplay.sprite = tutorialImages[currentImageIndex];
            UpdateButtonVisibility(); // ボタンの表示状態を更新
        }

        // 前の画像を表示する
        public void ShowPreviousImage()
        {
            if (tutorialImages == null || tutorialImages.Count == 0)
            {
                Debug.LogError("Tutorial images are not set.");
                return;
            }

            // インデックスを前に戻す
            currentImageIndex--;
            if (currentImageIndex < 0)
            {
                currentImageIndex = 0; // 最初の画像に固定
            }

            // 画像を更新
            tutorialImageDisplay.sprite = tutorialImages[currentImageIndex];
            UpdateButtonVisibility(); // ボタンの表示状態を更新
        }

        // ボタンの表示状態を更新
        private void UpdateButtonVisibility()
        {
            // 最初の画像の場合、previousButton を非表示
            previousButton.SetActive(currentImageIndex > 0);

            // 最後の画像の場合、nextButton を非表示
            nextButton.SetActive(currentImageIndex < tutorialImages.Count - 1);

            // インデックスが0のときだけ specialImage を表示
            if (specialImage1 != null && specialImage2 != null)
            {
                specialImage1.SetActive(currentImageIndex == 0);
                specialImage2.SetActive(currentImageIndex == 0);
            }
        }
    }
}