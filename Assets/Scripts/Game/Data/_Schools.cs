using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _Schools
    {
        private List<string> Universities = new List<string>
        {
            "School 1",
            "School 2",
            "School 3"
        };
        private List<string> VocationalCollege = new List<string>
        {
            "College 1",
            "College 2",
            "College 3"
        };
        private List<string> HighSchool = new List<string>
        {
            "High School 1",
            "High School 2",
            "High School 3"
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
    }
}