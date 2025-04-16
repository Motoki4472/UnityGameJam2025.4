using UnityEngine;

namespace App.Scripts.Game.Data
{
    public class _LimitTimeHolder
    {
        private float LimitTime = 0f;

        public _LimitTimeHolder(float limitTime)
        {
            LimitTime = limitTime;
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
