using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

        public int[] GetAppearanceCounts()
        {
            int[] AppearanceCounts = new int[4];
            AppearanceCounts[0] = Hair.Count;
            AppearanceCounts[1] = Eye.Count;
            AppearanceCounts[2] = Mouth.Count;
            AppearanceCounts[3] = Accessory.Count;
            return AppearanceCounts;
        }

        public int[] GetAppearanceCountsByString(string appearanceString)
        {
            // 入力文字列をカンマで分割し、空白を削除
            string[] appearances = appearanceString.Split(',')
                                                   .Select(a => a.Trim())
                                                   .Where(a => !string.IsNullOrEmpty(a)) // 空の要素を除外
                                                   .ToArray();

            // 結果を格納する配列
            int[] counts = new int[4];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = -1; // 初期値として-1を設定
            }

            for (int i = 0; i < appearances.Length; i++)
            {
                string appearance = appearances[i];

                if (Hair.Contains(appearance))
                {
                    counts[0] = Hair.IndexOf(appearance); // Hairリスト内のインデックスを取得
                }
                else if (Eye.Contains(appearance))
                {
                    counts[1] = Eye.IndexOf(appearance); // Eyeリスト内のインデックスを取得
                }
                else if (Mouth.Contains(appearance))
                {
                    counts[2] = Mouth.IndexOf(appearance); // Mouthリスト内のインデックスを取得
                }
                else if (Accessory.Contains(appearance))
                {
                    counts[3] = Accessory.IndexOf(appearance); // Accessoryリスト内のインデックスを取得
                }
                else
                {
                    counts[i] = -1;
                }
            }

            return counts;
        }
    }
}