using UnityEngine;

namespace App.Scripts.Game.Data
{
    public class _ActiveUserHolder
    {
        private int ActiveUser = 0;

        public int GetActiveUser()
        {
            return ActiveUser;
        }
    }
}
