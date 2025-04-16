using UnityEngine;

namespace App.Scripts.Game.Demand
{

    public class _DemandParameter
    {
        private string _appearance;
        private string _age;
        private string _background;
        private string _gender;
        private string _mbti;
        private string _region;

        public _DemandParameter(string appearance, string age, string background, string gender, string mbti, string region)
        {
            this._appearance = appearance;
            this._age = age;
            this._background = background;
            this._gender = gender;
            this._mbti = mbti;
            this._region = region;
        }
        public string GetAppearance()
        {
            return _appearance;
        }
        public string GetAge()
        {
            return _age;
        }
        public string GetBackground()
        {
            return _background;
        }
        public string GetGender()
        {
            return _gender;
        }
        public string GetMbti()
        {
            return _mbti;
        }
        public string GetRegion()
        {
            return _region;
        }



    }
}