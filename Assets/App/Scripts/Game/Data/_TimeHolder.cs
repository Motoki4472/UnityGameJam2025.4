using UnityEngine;

namespace App.Scripts.Game.Data
{
    public class _LimitTimeHolder
    {
        private float LimitTime = 0f;

        private float LimitTimeMax = 0f;

        public void SetLimitTime(float time)
        {
            LimitTime = time;
            LimitTimeMax = time;
        }

        public float GetLimitTime()
        {
            return LimitTime;
        }

        public void SubtractLimitTime(float time)
        {
            LimitTime -= time;
            if (LimitTime < 0f)
            {
                LimitTime = 0f;
            }
        }
    }
}
