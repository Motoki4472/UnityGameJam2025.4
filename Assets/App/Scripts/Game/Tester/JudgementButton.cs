using System.Diagnostics;
using UnityEngine;
using App.Game.ProcessSystem;
using App.Scripts.Game.Profile;

namespace App.Scripts.Game.Tester
{
    public class JudgementButton : MonoBehaviour
    {
        [SerializeField] private GameObject JudgementText;
        [SerializeField] private ProcessSystem _processSystem;
        private _ProfileParameter ProfileParameter;
        
        public void JudgementButtonClick()
        {
            if (ProfileParameter.GetIsPhotoEffect())
            {
                
            }
            else
            {
            }
        }
    }

}
