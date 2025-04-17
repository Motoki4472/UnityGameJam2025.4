using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _Region
    {
        private Dictionary<string, List<string>> regionToPrefectures = new Dictionary<string, List<string>>
        {
            { "北海道", new List<string> { "北海道" } },
            { "東北", new List<string> { "青森県", "岩手県", "宮城県", "秋田県", "山形県", "福島県" } },
            { "関東", new List<string> { "茨城県", "栃木県", "群馬県", "埼玉県", "千葉県", "東京都", "神奈川県" } },
            { "中部", new List<string> { "新潟県", "富山県", "石川県", "福井県", "山梨県", "長野県", "岐阜県", "静岡県", "愛知県" } },
            { "近畿", new List<string> { "三重県", "滋賀県", "京都府", "大阪府", "兵庫県", "奈良県", "和歌山県" } },
            { "中国", new List<string> { "鳥取県", "島根県", "岡山県", "広島県", "山口県" } },
            { "四国", new List<string> { "徳島県", "香川県", "愛媛県", "高知県" } },
            { "九州・沖縄", new List<string> { "福岡県", "佐賀県", "長崎県", "熊本県", "大分県", "宮崎県", "鹿児島県", "沖縄県" } }
        };
        public List<string> GetPrefectures(string region)
        {
            if (regionToPrefectures.ContainsKey(region))
            {
                return regionToPrefectures[region];
            }
            else if (region == "気にしない")
            {
                List<string> allPrefectures = new List<string>();
                foreach (var prefectures in regionToPrefectures.Values)
                {
                    allPrefectures.AddRange(prefectures);
                }
                return allPrefectures;
            }
            else
            {
                Debug.LogError("Invalid region provided. Returning empty list.");
                return new List<string>();
            }
        }

        public List<string> GetRegions()
        {
            return new List<string>(regionToPrefectures.Keys);
        }


    }
}