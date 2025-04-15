using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _Appearance
    {
        private List<string> Hair = new List<string>
        {
            "ロング",
            "ボブ",
            "ショート"
        };

        private List<string> Eye = new List<string>
        {
            "たれ目",
            "切れ長",
            "ぱっちり"
        };

        private List<string> Mouth = new List<string>
        {
            "にっこり",
            "ふんわり",
            "すまし顔"
        };

        private List<string> Accessory = new List<string>
        {
            "なし",
            "メガネ",
            "ピアス",
            "ネックレス"
        };

        public List<string> GetAppearance(int HairType, int EyeType, int MouthType, int AccessoryType)
        {
            List<string> appearance = new List<string>();
            appearance.Add(Hair[HairType]);
            appearance.Add(Eye[EyeType]);
            appearance.Add(Mouth[MouthType]);
            appearance.Add(Accessory[AccessoryType]);
            return appearance;
        }
    }
}