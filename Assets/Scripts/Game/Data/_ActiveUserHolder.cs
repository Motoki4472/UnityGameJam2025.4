using UnityEngine;

namespace App.Scripts.Game.Data
{
    public class _ActiveUserHolder
    {
        private int ActiveUser = 0;
        private int magnification_value = 0;

        public void SetInitialActiveUser(int initialActiveUser)
        {
            ActiveUser = initialActiveUser;
        }
        public int GetActiveUser()
        {
            return ActiveUser;
        }
        public void AddMagnificationValue()
        {
            magnification_value++;
        }
        public void SubtractMagnificationValue()
        {
            magnification_value--;
        }
        public void CalculateActiveUser(int default_change_value, int amplification_value)
        {
            ActiveUser += default_change_value * (1 + amplification_value * (-magnification_value));
            if (ActiveUser < 0)
            {
                ActiveUser = 0;
            }
        }
    }
}
