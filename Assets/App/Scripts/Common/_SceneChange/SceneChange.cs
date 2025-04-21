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
            _SceneChangeManager.EndName endName = 0;
            int finalActiveUserNumber = 100; 
            int maxActiveUserNumber = 200;
            // シーン遷移を行う
            _SceneChangeManager.ChengeSceneToResult(
                endName,
                finalActiveUserNumber,
                maxActiveUserNumber
            );
        }
    }
}
