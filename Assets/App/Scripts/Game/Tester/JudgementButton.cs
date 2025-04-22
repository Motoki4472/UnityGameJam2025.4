using System.Diagnostics;
using UnityEngine;
using TMPpro;
using App.Game.ProcessSystem;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;

namespace App.Scripts.Game.Tester
{
    public class JudgementButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI JudgementText;
        [SerializeField] private ProcessSystem _processSystem;
        private GameObject[] profileList;
        void Start()
        {
            JudgementText.SetActive(false);
            profileList = _processSystem.GetProfileList();
        }

        public void JudgementButtonClick()
        {
            foreach (var profile in profileList)
            {
                if (profile.GetComponent<DocumentsAnimation>().isInCamera)
                {
                    StartCoroutine(DetectTextAnimation(profile));
                }
            }
        }

        private IEnumerator DetectTextAnimation(GameObject profile)
        {
            JudgementText.SetActive(true);
            JudgementText.text = "検出中";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中.";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中..";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出中...";
            yield return new WaitForSeconds(0.5f);
            JudgementText.text = "検出完了";
            yield return new WaitForSeconds(0.5f);
            if(profile.ProfilePrefab.IsPhotoEffect())
            {
                JudgementText.text = "加工有"
            }
            else
            {
                JudgementText.text = "加工無";
            }
            yield return new WaitForSeconds(4f);
            JudgementText.SetActive(false);
            JudgementText.text = "";
        }
    }

}
