using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Data;
using App.Scripts.Game.Demand;

namespace App.Scripts.Game.Profile
{
    public class _GenerateMistakeProfile
    {
        private List<Func<_DemandParameter, _ProfileParameter, _ProfileParameter>> MistakeFunctions;

        public _GenerateMistakeProfile()
        {
            MistakeFunctions = new List<Func<_DemandParameter, _ProfileParameter, _ProfileParameter>>
            {
                ApplyAppearanceMistake,
                ApplyAgeMistake,
                ApplyBirthdateMistake,
                ApplyGenderMistake,
                ApplyBackgroundMistake,
                ApplyMbtiMistake,
                ApplyRegionMistake,
                ApplyZodiacMistake
            };
        }

        public _ProfileParameter GenerateMistakeProfileParameter(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            System.Random random = new System.Random();
            int mistakeId;
            HashSet<int> MistakeIds = new HashSet<int>()
            {
                0, // 外見
                1, // 年齢
                2, // 誕生日
                3, // 性別
                4, // 背景
                5, // MBTI
                6, // 地域
                7  // 干支
            };

            // "気にしない"になっているパラメータをHashSetに追加
            if (demandParameter.GetAppearance() == "気にしない" && MistakeIds.Contains(0)) MistakeIds.Remove(0);
            if (demandParameter.GetAge() == "気にしない" && MistakeIds.Contains(1)) MistakeIds.Remove(1);
            if (demandParameter.GetAge() == "気にしない" && MistakeIds.Contains(2)) MistakeIds.Remove(2);
            if (demandParameter.GetGender() == "気にしない" && MistakeIds.Contains(3)) MistakeIds.Remove(3);
            if (demandParameter.GetBackground() == "気にしない" && MistakeIds.Contains(4)) MistakeIds.Remove(4);
            if (demandParameter.GetMbti() == "気にしない" && MistakeIds.Contains(5)) MistakeIds.Remove(5);
            if (demandParameter.GetRegion() == "気にしない" && MistakeIds.Contains(6)) MistakeIds.Remove(6);
            if (demandParameter.GetAge() == "気にしない" && MistakeIds.Contains(2)) MistakeIds.Remove(7);


            // 気にしないになっていない項目と重複しないmistakeIdを生成
            List<int> mistakeIdList = MistakeIds.ToList();
            mistakeId = mistakeIdList[random.Next(0, mistakeIdList.Count)];

            profileParameter = MistakeFunctions[mistakeId](demandParameter, profileParameter);
            profileParameter.SetIsCorrect(false); // プロフィールが正しくないことを示すフラグを設定
            Debug.Log($"Mistake applied: {mistakeId}"); // デバッグ用ログ


            //Debug.Log($"偽プロフィール生成結果:");
            //Debug.Log($"ImageId: {string.Join(", ", profileParameter.GetImageId())}");
            //Debug.Log($"Name: {profileParameter.GetName()}");
            //Debug.Log($"Gender: {profileParameter.GetGender()}");
            //Debug.Log($"Birthdate: {profileParameter.GetBirthdate()}");
            //Debug.Log($"Age: {profileParameter.GetAge()}");
            //Debug.Log($"Background: {profileParameter.GetBackground()}");
            //Debug.Log($"Zodiac: {profileParameter.GetZodiac()}");
            //Debug.Log($"MBTI: {profileParameter.GetMbti()}");
            //Debug.Log($"Region: {profileParameter.GetRegion()}");

            return profileParameter;
        }

        // 各ミス処理の例
        private _ProfileParameter ApplyAppearanceMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            System.Random random = new System.Random();
            float randomAppearanceProbability = 0.5f;
            float chance = (float)random.NextDouble(); // 0.0～1.0のランダムな値を生成
            int[] newAppearance;

            if (chance < randomAppearanceProbability)
            {
                newAppearance = RandomAppearanceMistake(profileParameter);
            }
            else
            {
                newAppearance = PhotoEffectMistake(profileParameter);
                profileParameter.SetIsPhotoEffect(true); // PhotoEffectを適用
            }

            return new _ProfileParameter(
                newAppearance,
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }

        private int[] RandomAppearanceMistake(_ProfileParameter profileParameter)
        {
            int[] MissAppearance = profileParameter.GetImageId();
            int[] AppearanceCounts = new _Appearance().GetAppearanceCounts();
            System.Random random = new System.Random();

            for (int i = 0; i < MissAppearance.Length; i++)
            {
                int newValue;
                do
                {
                    newValue = random.Next(0, AppearanceCounts[i]);
                } while (newValue == MissAppearance[i]);

                MissAppearance[i] = newValue;
            }

            return MissAppearance;
        }

        private int[] PhotoEffectMistake(_ProfileParameter profileParameter)
        {
            // _Appearanceの方で実装し、この関数内で実行
            profileParameter.SetIsPhotoEffect(true);

            return profileParameter.GetImageId();
        }

        private _ProfileParameter ApplyAgeMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            _Age _age = new _Age();
            System.Random random = new System.Random();

            // 年齢範囲を取得
            (int minAge, int maxAge) = _age.GetAge(demandParameter.GetAge());

            int newAge;
            do
            {
                // 18～59の間でランダムな年齢を生成
                newAge = random.Next(18, 60); // 18～59の範囲
            } while (newAge >= minAge && newAge <= maxAge); // minAge～maxAgeの範囲内の場合は再生成

            // 新しい年齢を設定して返す
            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                newAge.ToString(), // 新しい年齢を文字列に変換して設定
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }

        private _ProfileParameter ApplyBirthdateMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            // 現在の誕生日を取得
            string currentBirthdate = profileParameter.GetBirthdate();
            DateTime birthdate = DateTime.Parse(currentBirthdate); // 誕生日をDateTime型に変換

            System.Random random = new System.Random();
            int newYear;

            do
            {
                // ±5年の範囲でランダムな生まれ年を生成
                newYear = birthdate.Year + random.Next(-5, 6); // -5～+5の範囲
            } while (newYear == birthdate.Year); // 元の年と被らないようにする

            // 新しい誕生日を作成
            DateTime newBirthdate = new DateTime(newYear, birthdate.Month, birthdate.Day);

            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                newBirthdate.ToString("yyyy-MM-dd"),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }

        private _ProfileParameter ApplyGenderMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            //Debug.Log("Applying Gender Mistake");

            string currentGender = profileParameter.GetGender();
            string newGender = currentGender == "男性" ? "女性" : "男性";

            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                newGender,
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }

        private _ProfileParameter ApplyBackgroundMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            System.Random random = new System.Random();
            float randomProbability = 0.5f;
            float chance = (float)random.NextDouble(); // 0.0～1.0のランダムな値を生成
            string newBackground;
            if (chance < randomProbability)
            {
                newBackground = RandomBackGroundMistake(demandParameter, profileParameter);
            }
            else
            {
                BackGroundFraud(demandParameter, profileParameter);
                newBackground = profileParameter.GetBackground();
                profileParameter.SetIsBackgroundFraud(true);
            }


            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                newBackground,
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }


        private string RandomBackGroundMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            System.Random random = new System.Random();
            _Schools school = new _Schools();
            List<string> MissSchool = school.GetMistake(school.GetSchoolType(demandParameter.GetBackground()));
            int randomIndex = random.Next(0, MissSchool.Count);
            return MissSchool[randomIndex];
        }

        private void BackGroundFraud(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            profileParameter.SetIsBackgroundFraud(true);
            return;
        }

        private _ProfileParameter ApplyMbtiMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            //Debug.Log("Applying MBTI Mistake");

            System.Random random = new System.Random();
            _MBTI mbti = new _MBTI();
            string[] allMbtiTypes = mbti.GetMBTI(); // 全てのMBTIタイプを取得
            List<string> excludedMbtiList = demandParameter.GetMbti().Split(',').Select(m => m.Trim()).ToList(); // 指定されたMBTIをリスト化

            // 指定されたMBTI以外のリストを作成
            List<string> availableMbtiList = allMbtiTypes.Where(m => !excludedMbtiList.Contains(m)).ToList();

            string newMbti;
            if (availableMbtiList.Count == 0)
            {
                newMbti = "不明"; // 指定されたMBTI以外が存在しない場合
            }
            else
            {
                // 指定されたMBTI以外からランダムに1つ選択
                int index = random.Next(0, availableMbtiList.Count);
                newMbti = availableMbtiList[index];
            }

            // 新しいMBTIを設定して返す
            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                newMbti, // 新しいMBTIを設定
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }

        private _ProfileParameter ApplyRegionMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            //Debug.Log("Applying Region Mistake");

            System.Random random = new System.Random();
            _Region _region = new _Region();

            // demandParameterのregionを取得し、指定された地域をリスト化
            List<string> excludedRegions = demandParameter.GetRegion().Split(',').Select(r => r.Trim()).ToList();
            List<string> excludedPrefectures = new List<string>();
            foreach (string region in excludedRegions)
            {
                // 都道府県を取得し、リストに追加
                List<string> prefectures = _region.GetPrefectures(region);
                excludedPrefectures.AddRange(prefectures);
            }


            // 全ての都道府県を取得
            List<string> allPrefectures = _region.GetAllPrefectures();

            // 指定された地域以外の都道府県リストを作成
            List<string> availablePrefectures = allPrefectures.Where(p => !excludedPrefectures.Contains(p)).ToList();

            string newRegion;
            if (availablePrefectures.Count == 0)
            {
                newRegion = "不明"; // 指定された地域以外が存在しない場合
            }
            else
            {
                // 指定された地域以外からランダムに1つ選択
                int index = random.Next(0, availablePrefectures.Count);
                newRegion = availablePrefectures[index];
            }

            // 新しい地域を設定して返す
            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                profileParameter.GetZodiac(),
                profileParameter.GetMbti(),
                newRegion,// 新しい地域を設定
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud() 
            );
        }

        private _ProfileParameter ApplyZodiacMistake(_DemandParameter demandParameter, _ProfileParameter profileParameter)
        {
            // 現在の干支を取得
            string currentZodiac = profileParameter.GetZodiac();
            string[] zodiacs = { "子年", "丑年", "寅年", "卯年", "辰年", "巳年", "午年", "未年", "申年", "酉年", "戌年", "亥年" };

            // 現在の干支以外をリスト化
            List<string> otherZodiacs = new List<string>(zodiacs);
            otherZodiacs.Remove(currentZodiac);

            // ランダムに間違った干支を選択
            System.Random random = new System.Random();
            string newZodiac = otherZodiacs[random.Next(otherZodiacs.Count)];

            // 新しい干支を設定して返す
            return new _ProfileParameter(
                profileParameter.GetImageId(),
                profileParameter.GetName(),
                profileParameter.GetGender(),
                profileParameter.GetBirthdate(),
                profileParameter.GetAge(),
                profileParameter.GetBackground(),
                newZodiac, // 間違った干支を設定
                profileParameter.GetMbti(),
                profileParameter.GetRegion(),
                profileParameter.GetIsCorrect(),
                profileParameter.GetIsPhotoEffect(),
                profileParameter.GetIsBackgroundFraud()
            );
        }
    }
}