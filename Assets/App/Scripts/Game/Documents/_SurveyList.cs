using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using App.Scripts.Game.Data;
using App.Scripts.Game.Profile;

namespace App.Scripts.Game.Documents
{
    public class _SurveyList
    {
        private _Schools schools = new _Schools();
        private HashSet<string> StudentList = new HashSet<string>();
        private string SurveyTitle;
        private string GraduationYear;
        private string GraduationSchool;

        public void GenerateStudentList(_ProfileParameter profileParameter)
        {
            StudentList = new HashSet<string> { profileParameter.GetName() }; // 単一の名前をHashSetに追加
            if (profileParameter.GetIsBackgroundFraud())
            {
                StudentList = new HashSet<string> { }; // 単一の名前をHashSetに追加
            }
            GraduationSchool = profileParameter.GetBackground();
            GraduationYear = CalculateGraduationYear(profileParameter.GetBirthdate(), GraduationSchool);
            SetSurveyTitle(profileParameter); // 戻り値を期待せず直接呼び出す
            GeneratePersonName();

            //Debug.Log($"Generated Student List: {string.Join(", ", StudentList)}");
            //Debug.Log($"Graduation Year: {GraduationYear}");
            //Debug.Log($"Graduation School: {GraduationSchool}");
            //Debug.Log($"Survey Title: {SurveyTitle}");
        }

        private string CalculateGraduationYear(string birthdate, string schoolName)
        {
            if (!TryParseBirthdate(birthdate, out System.DateTime birthDateTime) || string.IsNullOrEmpty(schoolName))
            {
                Debug.LogError("Invalid birthdate or school name provided.");
                return "Unknown";
            }

            int graduationAge = GetGraduationAge(schoolName);
            if (graduationAge == -1) return "Unknown";

            return (birthDateTime.Year + graduationAge).ToString();
        }

        private string SetSurveyTitle(_ProfileParameter profileParameter)
        {
            string birthdate = profileParameter.GetBirthdate();
            string schoolName = profileParameter.GetBackground();

            if (!TryParseBirthdate(birthdate, out System.DateTime birthDateTime) || string.IsNullOrEmpty(schoolName))
            {
                Debug.LogError("Invalid birthdate or school name provided.");
                SurveyTitle = "Unknown";
                return SurveyTitle;
            }

            int graduationAge = GetGraduationAge(schoolName);
            if (graduationAge == -1)
            {
                SurveyTitle = "Unknown";
                return SurveyTitle;
            }

            int graduationYear = birthDateTime.Year + graduationAge;
            int currentAge = System.DateTime.Now.Year - birthDateTime.Year;

            SurveyTitle = $"{graduationYear}年度\n  {schoolName}\n  卒業者一覧" + (currentAge < graduationAge ? " (予定)" : "");
            return SurveyTitle;
        }

        private int GetGraduationAge(string schoolName)
        {
            return schoolName switch
            {
                _ when schools.GetSchools(0).Contains(schoolName) => 22 + new System.Random().Next(0, 3), // 大学 + 浪人考慮
                _ when schools.GetSchools(1).Contains(schoolName) => 20, // 短大・専門学校
                _ when schools.GetSchools(2).Contains(schoolName) => 18, // 高校
                _ => -1 // 不明な学校
            };
        }

        private bool TryParseBirthdate(string birthdate, out System.DateTime birthDateTime)
        {
            return System.DateTime.TryParse(birthdate, out birthDateTime);
        }

        private void GeneratePersonName()
        {
            _PersonName personName = new _PersonName();
            System.Random random = new System.Random();
            int nameCount = random.Next(19, 25);

            while (StudentList.Count < nameCount)
            {
                int firstNameIndex = random.Next(0, personName.GetFirstNameCount());
                int lastNameIndex = random.Next(0, personName.GetLastNameCount());
                List<string> fullName = personName.GetPersonName(firstNameIndex, lastNameIndex);
                string newName = $"{fullName[0]} {fullName[1]}"; // 姓と名を結合
                StudentList.Add(newName);
            }
            //　名簿をシャッフル
            StudentList = new HashSet<string>(StudentList.OrderBy(x => random.Next()).ToList());
        }
        public string GetSurveyTitle()
        {
            return SurveyTitle;
        }


        public string GetStudentName()
        {
            List<string> studentArray = StudentList.ToList();

            // 最大の名前の幅を取得（全角文字は2、半角文字は1として計算）
            int maxNameWidth = 16;

            // ペアごとにフォーマット
            string formattedList = "";
            for (int i = 0; i < studentArray.Count; i += 2)
            {
                string first = studentArray[i];
                string second = (i + 1 < studentArray.Count) ? studentArray[i + 1] : "";

                // 名前の幅に応じてスペースを調整
                int padding = maxNameWidth - GetStringWidth(first);
                formattedList += $"{first}{new string(' ', padding)}{second}\n";
            }

            return formattedList;
        }

        // 文字列の幅を計算するヘルパーメソッド
        private int GetStringWidth(string input)
        {
            int width = 0;
            foreach (char c in input)
            {
                // Unicodeカテゴリを使用して全角文字を判定
                if (Regex.IsMatch(c.ToString(), @"\p{IsCJKUnifiedIdeographs}|\p{IsHiragana}|\p{IsKatakana}"))
                {
                    width += 2; // 全角文字は幅2
                }
                else
                {
                    width += 1; // 半角文字は幅1
                }
            }
            return width;
        }
    }
}
