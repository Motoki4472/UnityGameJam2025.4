using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _Schools
    {
        private List<string> Universities = new List<string>
        {
            "東都大学",
            "神楽坂国際大学",
            "青嶺総合大学",
            "白鷺芸術大学",
            "鳴海未来大学",
            "光陽情報大学",
            "天峰工科大学",
            "霧島創造大学",
            "瑞穂人文大学",
            "桜花女子大学",
            "星環大学",
            "白峰大学",
            "東雲大学",
            "楠葉大学",
            "若松大学",
            "鳳凰大学",
            "常盤大学",
            "錦ヶ丘大学",
            "神代大学",
            "朝日大学",
            "高天原大学",
            "明芳大学",
            "新城大学",
            "清和大学",
            "南条大学",
            "北栄大学",
            "千歳大学",
            "晴海大学",
            "陽和大学",
            "青楓大学",
            "聖和大学",
            "ネオ東京未来大学"
        };
        private List<string> VocationalCollege = new List<string>
        {
            "青葉女子短期大学",
            "東都文化短期大学",
            "若松こども短期大学",
            "桜丘栄養短期大学",
            "瑞穂国際短期大学",
            "光和看護短期大学",
            "白鷺ファッション短期大学",
            "高天原福祉短期大学",
            "神代保育短期大学",
            "南条ビジネス短期大学",
            "日本デザイン専門学校",
            "東京IT技術専門学校",
            "関西調理製菓専門学校",
            "聖和メディカル専門学校",
            "北栄アート専門学校",
            "千歳動物看護専門学校",
            "青楓音楽専門学校",
            "明芳ビューティー専門学校",
            "朝日建築技術専門学校",
            "清和医療福祉専門学校"
        };
        private List<string> HighSchool = new List<string>
        {
            "青葉学園高等学校",
            "桜丘高等学校",
            "白鷺高等学校",
            "鳴海第一高等学校",
            "瑞穂台高等学校",
            "神楽坂高等学校",
            "東雲高等学校",
            "風見野高等学校",
            "水明館高等学校",
            "北条西高等学校",
            "星蘭学園高等部",
            "東都帝国高等学校",
            "九条学術高等学校",
            "明鏡国際高等学校",
            "光陽台アカデミー",
            "黒耀魔法学園",
            "蒼星術高等学院",
            "第六区域高等教育機関",
            "ネオ東京情報高専",
            "電脳開発学園ユニット"
        };

        private Dictionary<string, int> schoolTypes = new Dictionary<string, int>
        {
            { "大卒", 0 },
            { "短大・専門卒", 1 },
            { "高卒", 2 },
            { "短大・専門卒以上", 3 },
            { "気にしない", 4 }
        };


        public List<string> GetSchools(int type)
        {
            switch (type)
            {
                case 0://大卒
                    return Universities;
                case 1://短大・専門卒
                    return VocationalCollege;
                case 2://高卒
                    return HighSchool;
                case 3://短大・専門卒以上
                    List<string> Schools = new List<string>();
                    Schools.AddRange(Universities);
                    Schools.AddRange(VocationalCollege);
                    return Schools;
                case 4://気にしない
                    List<string> allSchools = new List<string>();
                    allSchools.AddRange(Universities);
                    allSchools.AddRange(VocationalCollege);
                    allSchools.AddRange(HighSchool);
                    return allSchools;
                default:
                    Debug.LogError("Invalid type provided. Returning empty list.");
                    return new List<string>();
            }
        }

        public List<string> GetMistake(int type)
        {
            switch (type)
            {
                case 0: // 大卒
                    List<string> mistakeSchoolsForUniversity = new List<string>();
                    mistakeSchoolsForUniversity.AddRange(HighSchool);
                    mistakeSchoolsForUniversity.AddRange(VocationalCollege);
                    return mistakeSchoolsForUniversity;
                case 1: // 短大・専門卒
                    List<string> mistakeSchoolsForVocational = new List<string>();
                    mistakeSchoolsForVocational.AddRange(Universities);
                    mistakeSchoolsForVocational.AddRange(HighSchool);
                    return mistakeSchoolsForVocational;
                case 2: // 高卒
                    List<string> mistakeSchoolsForHighSchool = new List<string>();
                    mistakeSchoolsForHighSchool.AddRange(Universities);
                    mistakeSchoolsForHighSchool.AddRange(VocationalCollege);
                    return mistakeSchoolsForHighSchool;
                case 3: // 短大・専門卒以上
                    return HighSchool;
                case 4: // 気にしない
                    List<string> allMistakeSchools = new List<string>();
                    allMistakeSchools.AddRange(Universities);
                    allMistakeSchools.AddRange(VocationalCollege);
                    allMistakeSchools.AddRange(HighSchool);
                    return allMistakeSchools;
                default:
                    Debug.LogError("Invalid type provided. Returning empty list.");
                    return new List<string>();
            }
        }

        public int GetSchoolType(string type)
        {
            if (schoolTypes.ContainsKey(type))
            {
                return schoolTypes[type];
            }
            else
            {
                Debug.LogError("Invalid type provided. Returning default value.");
                return 0;
            }
        }

        public string GetSchoolTypeName(int type)
        {
            foreach (var kvp in schoolTypes)
            {
                if (kvp.Value == type)
                {
                    return kvp.Key;
                }
            }
            Debug.LogError("Invalid type provided. Returning default value.");
            return "Unknown";
        }

        public int GetGraduationYears(string schoolName)
        {
            if (Universities.Contains(schoolName))
            {
                return 4; // 大学は4年
            }
            else if (VocationalCollege.Contains(schoolName))
            {
                return 2; // 短大・専門学校は2年
            }
            else if (HighSchool.Contains(schoolName))
            {
                return 3; // 高校は3年
            }
            else
            {
                Debug.LogError("Invalid school name provided. Returning default value.");
                return 0; // 不明な学校名の場合は0を返す
            }
        }
    }
}