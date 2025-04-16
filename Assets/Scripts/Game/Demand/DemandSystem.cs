using UnityEngine;

namespace App.Scripts.Game.Demand
{
    public class DemandSystem : MonoBehaviour
    {
        private _GenerateDemand _generateDemand;
        public void Start()
        {
            _generateDemand = new _GenerateDemand();
            _generateDemand.GenerateDemandParameter(2);
        }
    }
}
