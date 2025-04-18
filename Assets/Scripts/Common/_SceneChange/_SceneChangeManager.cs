using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Common._SceneChange
{
    public class _SceneChangeManager
    {
        public enum EndName
        {
            BadEnd,
            GoodEnd,
            NormalEnd
        }
        static public void ChengeSceneToTitle()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        }
        static public void ChengeSceneToGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        static public void ChengeSceneToResult(EndName endName)
        {
            if (endName == EndName.BadEnd)
            {
                SceneManager.sceneLoaded += (scene, mode) => ResultSceneLoaded(endName);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
            else if (endName == EndName.GoodEnd)
            {
                SceneManager.sceneLoaded += (scene, mode) => ResultSceneLoaded(endName);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
            else if (endName == EndName.NormalEnd)
            {
                SceneManager.sceneLoaded += (scene, mode) => ResultSceneLoaded(endName);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
        }

        static private void ResultSceneLoaded(EndName endName)
        {
            // Resultシーンが読み込まれた後の処理をここに記述
            // 例えば、UIの初期化やデータの設定など
            // ここでは例としてDebug.Logを使用していますが、実際には必要な処理を実装してください
            Debug.Log("Resultシーンが読み込まれました。");
            SceneManager.sceneLoaded -= (scene, mode) => ResultSceneLoaded(endName);
        }
    }
}
