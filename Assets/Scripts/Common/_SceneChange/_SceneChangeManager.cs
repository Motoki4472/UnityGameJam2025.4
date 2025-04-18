using UnityEngine;

namespace App.Common._SceneChange
{
    static public class _SceneChangeManager
    {
        static public enum EndName
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
            else if (endName == EndName.GoodEnd)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
            else if (endName == EndName.NormalEnd)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            }
        }
    }
}