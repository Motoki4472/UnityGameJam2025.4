using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Data;
using App.Scripts.Game.Demand;

namespace App.Scripts.Game.Profile
{
    public class _GenerateProfile
    {
        private HashSet<string> generatedNames = new HashSet<string>(); // 生成済みの名前を記憶
        private HashSet<string> generatedImageIds = new HashSet<string>(); // 生成済みのImageIdを記憶

        public _ProfileParameter GenerateProfileParameter(_DemandParameter Parameter)
        {
            _Appearance appearance = new _Appearance();
            int[] ImageId;
            string Name;

            // ImageIdの再抽選処理
            do
            {
                ImageId = GenerateImageId(appearance.GetAppearanceCountsByString(Parameter.GetAppearance()));
            } while (!generatedImageIds.Add(string.Join(",", ImageId))); // 重複している場合は再抽選

            // Nameの再抽選処理
            do
            {
                Name = GenerateName();
            } while (!generatedNames.Add(Name)); // 重複している場合は再抽選

            string Gender = GenerateGender(Parameter.GetGender());
            string Age = GenerateAge(Parameter.GetAge());
            string Birthdate = GenerateBirthdate(Age);
            string Background = GenerateBackground(Parameter.GetBackground());
            string Zodiac = GenerateZodiac(Birthdate);
            string MBTI = GetMBTIFromList(SplitStringToList(Parameter.GetMbti()));
            string Region = GenerateRegion(SplitStringToList(Parameter.GetRegion()));

            //Debug.Log($"プロフィール生成結果:");
            //Debug.Log($"ImageId: {string.Join(", ", ImageId)}");
            //Debug.Log($"Name: {Name}");
            //Debug.Log($"Gender: {Gender}");
            //Debug.Log($"Birthdate: {Birthdate}");
            //Debug.Log($"Age: {Age}");
            //Debug.Log($"Background: {Background}");
            //Debug.Log($"Zodiac: {Zodiac}");
            //Debug.Log($"MBTI: {MBTI}");
            //Debug.Log($"Region: {Region}");

            return new _ProfileParameter(ImageId, Name, Gender, Birthdate, Age, Background, Zodiac, MBTI, Region);
        }

        private int[] GenerateImageId(int[] ImageId)
        {
            System.Random random = new System.Random();
            _Appearance appearance = new _Appearance();
            int[] AppearanceCounts = appearance.GetAppearanceCounts();
            for (int i = 0; i < ImageId.Length; i++)
            {
                if (ImageId[i] == -1)
                {
                    ImageId[i] = random.Next(0, AppearanceCounts[i]);
                }
            }
            return ImageId;
        }

        private string GenerateName()
        {
            System.Random random = new System.Random();
            _PersonName personName = new _PersonName();
            var nameList = personName.GetPersonName(random.Next(0, personName.GetFirstNameCount()), random.Next(0, personName.GetLastNameCount()));
            string nameString = "";
            for (int i = 0; i < nameList.Count; i++)
            {
                nameString += nameList[i];
                nameString += " ";
            }
            return nameString;
        }
        private string GenerateGender(string gender)
        {
            if (gender == "気にしない")
            {
                // ランダムに性別を生成
                System.Random random = new System.Random();
                int chance = random.Next(0, 100); // 0～99のランダムな数値を生成

                // 99%の確率で女性、1%の確率で男性
                if (chance < 99)
                {
                    return "女性";
                }
                else
                {
                    return "男性";
                }
            }

            // 「気にしない」以外の場合はそのまま返す
            return gender;
        }

        private string GenerateAge(string ageGroupe)
        {
            _Age _age = new _Age();
            System.Random random = new System.Random();
            if (ageGroupe == "気にしない")
            {

                int ageGroupIndex = random.Next(0, 5);
                ageGroupe = _age.GetAgeRange();
            }
            (int, int) ageRange = _age.GetAge(ageGroupe);
            int ageValue = random.Next(ageRange.Item1, ageRange.Item2 + 1);
            return ageValue.ToString();
        }
        private string GenerateBirthdate(string age)
        {
            int ageValue = int.Parse(age);
            System.Random random = new System.Random();

            System.DateTime today = System.DateTime.Now;
            int birthYear = today.Year - ageValue;

            int birthMonth = random.Next(1, 13);
            int birthDay;

            switch (birthMonth)
            {
                case 2: // 2月（うるう年を考慮）
                    birthDay = random.Next(1, System.DateTime.IsLeapYear(birthYear) ? 30 : 29);
                    break;
                case 4:
                case 6:
                case 9:
                case 11: // 30日までの月
                    birthDay = random.Next(1, 31);
                    break;
                default: // 31日までの月
                    birthDay = random.Next(1, 32);
                    break;
            }

            System.DateTime birthdate = new System.DateTime(birthYear, birthMonth, birthDay);
            if (birthdate > today)
            {
                birthdate = birthdate.AddYears(-1);

                if (birthMonth == 2 && birthDay == 29 && !System.DateTime.IsLeapYear(birthYear))
                {
                    birthDay = 28; // 2月29日が存在しない場合は28日に調整
                }

                birthdate = new System.DateTime(birthYear, birthMonth, birthDay);
            }

            // 誕生日を文字列として返す（例: "1995-08-15"）
            return birthdate.ToString("yyyy-MM-dd");
        }

        private string GenerateBackground(string background)
        {
            System.Random random = new System.Random();
            _Schools school = new _Schools();
            var schoolList = school.GetSchools(school.GetSchoolType(background));
            string backgroundString = "";
            backgroundString += schoolList[random.Next(0, schoolList.Count)];
            return backgroundString;
        }

        private string GenerateZodiac(string birthdate)
        {
            // 干支を計算して返す
            System.DateTime date = System.DateTime.Parse(birthdate);
            int year = date.Year;
            int zodiacIndex = (year - 4) % 12; // 干支の計算（4年を基準にする）
            string[] zodiacs = { "子年", "丑年", "寅年", "卯年", "辰年", "巳年", "午年", "未年", "申年", "酉年", "戌年", "亥年" };
            return zodiacs[zodiacIndex]; // 干支を返す

        }

        private string GetMBTIFromList(List<string> list)
        {
            if (list == null || list.Count == 0)
            {
                return "不明"; // リストが空の場合のデフォルト値
            }

            System.Random random = new System.Random();
            int index = random.Next(0, list.Count); // 0からリストの要素数未満の範囲でランダムなインデックスを生成
            if (list[index] == "気にしない")
            {
                _MBTI mbti = new _MBTI();
                string[] mbtiTypes = mbti.GetMBTI();
                index = random.Next(0, mbtiTypes.Length);
                return mbtiTypes[index]; // ランダムに選ばれたMBTIを返す
            }
            return list[index]; // ランダムに選ばれた要素を返す
        }

        private string GenerateRegion(List<string> region)
        {
            System.Random random = new System.Random();
            _Region _region = new _Region();
            if (region == null || region.Count == 0)
            {
                return "不明"; // リストが空の場合のデフォルト値
            }
            int index = random.Next(0, region.Count);
            List<string> Prefectures = _region.GetPrefectures(region[index]);
            string regionString = "";
            index = random.Next(0, Prefectures.Count);
            regionString += Prefectures[index];
            return regionString;
        }

        private List<string> SplitStringToList(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>(); // 入力が空の場合は空のリストを返す
            }

            // カンマで分割し、各要素の前後の空白を削除してリストに変換
            return input.Split(',')
                        .Select(element => element.Trim()) // 前後の空白を削除
                        .Where(element => !string.IsNullOrEmpty(element)) // 空の要素を除外
                        .ToList();
        }

        public void ResetHashSet()
        {
            generatedNames.Clear(); // 名前のHashSetをクリア
            generatedImageIds.Clear(); // ImageIdのHashSetをクリア
        }

    }
}