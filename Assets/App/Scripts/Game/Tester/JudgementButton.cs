using UnityEngine;
using TMPro;
using System.Collections;
using App.Game.ProcessSystem;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;
using System.Collections.Generic;


namespace App.Scripts.Game.Tester
{
    public class JudgementButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI JudgementText;
        [SerializeField] private ProcessSystem _processSystem;
        private List<GameObject> profileList;
        void Start()
        {
            JudgementText.text = "";
        }

        public void OnJudgementButtonClick()
        {
            profileList = _processSystem.GetProfileList();
            foreach (var profile in profileList)
            {
                Debug.Log("JudgementButtonClick");
                if (profile.GetComponent<DocumentsAnimation>().IsInCamera())
                {
                    StartCoroutine(DetectTextAnimation(profile));
                }
            }
        }

        private IEnumerator DetectTextAnimation(GameObject profile)
        {
            JudgementText.text = "検出中";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中.";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中..";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中...";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出完了";
            yield return new WaitForSeconds(4f);
            if (profile.GetComponent<ProfilePrefab>().IsPhotoEffect())
            {
                JudgementText.text = "加工有";
            }
            else
            {
                JudgementText.text = "加工無";
            }
            yield return new WaitForSeconds(6f);
            JudgementText.text = "";
        }
    }

}
