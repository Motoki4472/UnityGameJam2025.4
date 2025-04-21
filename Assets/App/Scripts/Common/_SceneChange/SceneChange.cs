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

        public void ToResult(_SceneChangeManager.EndName endName, int finalActiveUserNumber, int maxActiveUserNumber)
        {
            // シーン遷移を行う
            _SceneChangeManager.ChengeSceneToResult(
                endName,
                finalActiveUserNumber,
                maxActiveUserNumber
            );
        }
    }
}
