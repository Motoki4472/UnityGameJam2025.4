using UnityEngine;
using UnityEngine.SceneManagement;
using App.Result.Data;

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
        static public void ChengeSceneToResult(EndName endName, int finalActiveUserNumber, int maxActiveUserNumber)
        {
            SceneManager.sceneLoaded += (scene, mode) => ResultSceneLoaded(endName, finalActiveUserNumber, maxActiveUserNumber);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        }

        static private void ResultSceneLoaded(EndName endName, int finalActiveUserNumber, int maxActiveUserNumber)
        {
            // ResultDataHolderを取得
            var resultDataHolder = GameObject.Find("ResultDataHolder");
            if (resultDataHolder != null)
            {
                var resultData = resultDataHolder.GetComponent<ResultDataHolder>();
                if (resultData != null)
                {
                    resultData.finalActiveUserNumber = finalActiveUserNumber;
                    resultData.maxActiveUserNumber = maxActiveUserNumber;
                    resultData.endName = endName;
                }
            }
            else
            {
                Debug.LogError("ResultDataHolderが見つかりません。");
            }
            Debug.Log("Resultシーンが読み込まれました。");
            SceneManager.sceneLoaded -= (scene, mode) => ResultSceneLoaded(endName, finalActiveUserNumber, maxActiveUserNumber);
        }
    }
}
