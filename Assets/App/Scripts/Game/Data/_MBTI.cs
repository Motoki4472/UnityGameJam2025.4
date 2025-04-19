using UnityEngine;

namespace App.Scripts.Game.Data
{
    public class _MBTI
    {
        private string[] MBTI = new string[]
        {
            "INTJ",
            "INTP",
            "ENTJ",
            "ENTP",
            "INFJ",
            "INFP",
            "ENFJ",
            "ENFP",
            "ISTJ",
            "ISFJ",
            "ESTJ",
            "ESFJ",
            "ISTP",
            "ISFP",
            "ESTP",
            "ESFP"
        };

        public string[] GetMBTI()
        {
            return MBTI;
        }
    }
}