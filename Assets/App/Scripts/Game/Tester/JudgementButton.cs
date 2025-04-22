using System.Diagnostics;
using UnityEngine;
using App.Game.ProcessSystem;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;

namespace App.Scripts.Game.Tester
{
    public class JudgementButton : MonoBehaviour
    {
        [SerializeField] private GameObject JudgementText;
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
                if(profile.GetComponent<DocumentsAnimation>().isInCamera)
                {
                    JudgementText.SetActive(true);
                    
                }
            }
        }
    }

}
