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
            "アクセサリーなし",
            "メガネ",
            "ピアス",
            "ネックレス"
        };

        public List<(string, int)> GetAppearance()
        {
            System.Random random = new System.Random();
            List<(string, int)> appearance = new List<(string, int)>
            {
                (Hair[random.Next(Hair.Count)], random.Next(Hair.Count)),
                (Eye[random.Next(Eye.Count)], random.Next(Eye.Count)),
                (Mouth[random.Next(Mouth.Count)], random.Next(Mouth.Count)),
                (Accessory[random.Next(Accessory.Count)], random.Next(Accessory.Count))
            };
            return appearance;
        }
    }
}