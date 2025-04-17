using UnityEngine;

using App.Scripts.Game.Profile;

namespace App.Scripts.Game.Demand
{
    public class DemandSystem : MonoBehaviour
    {
        private _GenerateDemand _generateDemand;
        private _GenerateProfile _generateProfile;

        public void Start()
        {
            _generateDemand = new _GenerateDemand();
            _generateProfile = new _GenerateProfile();

            _DemandParameter demandParameter = _generateDemand.GenerateDemandParameter(0);
            
            _generateProfile.GenerateProfileParameter(demandParameter);
            _generateProfile.GenerateProfileParameter(demandParameter);
            _generateProfile.GenerateProfileParameter(demandParameter);
        }
    }
}
