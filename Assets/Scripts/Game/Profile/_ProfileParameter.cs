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

        private bool _isCorrect;
        private bool _isPhotoEffect;
        private bool _isBackgroundFraud;

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
            this._isCorrect = true;
            this._isPhotoEffect = false;
            this._isBackgroundFraud = false;
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
        public string GetZodiac()
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
        public void SetIsCorrect(bool isCorrect)
        {
            this._isCorrect = isCorrect;
        }
        public bool GetIsCorrect()
        {
            return _isCorrect;
        }
        public void SetIsPhotoEffect(bool isPhotoEffect)
        {
            this._isPhotoEffect = isPhotoEffect;
        }
        public bool GetIsPhotoEffect()
        {
            return _isPhotoEffect;
        }
        public void SetIsBackgroundFraud(bool isBackgroundFraud)
        {
            this._isBackgroundFraud = isBackgroundFraud;
        }

    }
}