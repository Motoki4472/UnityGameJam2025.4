using UnityEngine;

namespace App.Common._SceneChange
{
    public class SceneChange : MonoBehaviour
    {
        public void ToTitle()
        {
            _SceneChangeManager.ChengeSceneToTitle();
        }

        public void ToGame()
        {
            _SceneChangeManager.ChengeSceneToGame();
        }

        public void ToResult()
        {
            // 仮のデータ（必要に応じて動的に変更可能）
            _SceneChangeManager.ChengeSceneToResult(
                _SceneChangeManager.EndName.GoodEnd,
                finalActiveUserNumber: 50,
                maxActiveUserNumber: 100
            );
        }
    }
}
