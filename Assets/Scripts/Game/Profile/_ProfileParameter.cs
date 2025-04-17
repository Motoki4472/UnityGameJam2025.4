using UnityEngine;
using App.Scripts.Game.Data;
using App.Scripts.Game.Demand;

namespace App.Scripts.Game.Profile
{
    public class _ProfileParameter
    {
        private int[] _imageId;
        private string _name;
        private string _gender;
        private string _birthdate;
        private string _age;
        private string _background;
        private string _zodiac;
        private string _mbti;
        private string _region;

        public _ProfileParameter(int[] imageId,string name,string gender,string birthdate,string age,string background,string zodiac,string mbti,string region)
        {
            this._imageId = imageId;
            this._name = name;
            this._gender = gender;
            this._birthdate = birthdate;
            this._age = age;
            this._background = background;
            this._zodiac = zodiac;
            this._mbti = mbti;
            this._region = region;
        }

        public int[] GetImageId()
        {
            return _imageId;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetGender()
        {
            return _gender;
        }
        public string GetBirthdate()
        {
            return _birthdate;
        }
        public string GetAge()
        {
            return _age;
        }
        public string GetBackground()
        {
            return _background;
        }
        public string Getzodiac()
        {
            return _zodiac;
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