using UnityEngine;
using App.Scripts.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Demand
{
    public class _GenerateDemand
    {


        public _DemandParameter GenerateDemandParameter(int demandNumber)
        {
            int _demandNumber = demandNumber;
            List<string> parameters = new List<string> { GenerateAppearance(), GenerateAge(), GenerateBackground(), GenerateGender(), GenerateMBTI(), GenerateRegion() };
            System.Random random = new System.Random();
            HashSet<int> replacedIndices = new HashSet<int>();

            for (int i = 0; i < demandNumber; i++)
            {
                int index;
                do
                {
                    index = random.Next(parameters.Count); // ランダムにインデックスを選択
                } while (replacedIndices.Contains(index)); // 重複を避ける

                replacedIndices.Add(index);
                parameters[index] = "気にしない"; // 選択されたパラメータを「気にしない」に置き換える
            }

            Debug.Log($"外見: {parameters[0]}");
            Debug.Log($"年齢: {parameters[1]}");
            Debug.Log($"背景: {parameters[2]}");
            Debug.Log($"性別: {parameters[3]}");
            Debug.Log($"MBTI: {parameters[4]}");
            Debug.Log($"地域: {parameters[5]}");
            

            return new _DemandParameter(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
        }

        private string GenerateAppearance()
        {
            System.Random random = new System.Random();
            _Appearance appearance = new _Appearance();
            var appearanceList = appearance.GetAppearance();
            string appearanceString = "";

            int numOfAppearance = random.Next(1, 4);
            HashSet<int> selectedIndices = new HashSet<int>();

            for (int i = 0; i < numOfAppearance; i++)
            {
                int index;
                do
                {
                    index = random.Next(appearanceList.Count);
                } while (selectedIndices.Contains(index));

                selectedIndices.Add(index);
                appearanceString += appearanceList[index].Item1;
                if (i < numOfAppearance - 1)
                {
                    appearanceString += ", ";
                }
            }


            return appearanceString;
        }


        private string GenerateAge()
        {
            System.Random random = new System.Random();
            _Age age = new _Age();
            string ageGroup = age.GetAgeRange();
            return ageGroup;
        }
        private string GenerateBackground()
        {
            System.Random random = new System.Random();
            _Schools schools = new _Schools();
            int type = random.Next(0, 5);
            return schools.GetSchoolTypeName(type);
        }


        private string GenerateGender()
        {
            System.Random random = new System.Random();
            int chance = random.Next(0, 100);

            if (chance < 99)
            {
                return "女性";
            }
            else
            {
                return "男性";
            }

        }

        private string GenerateMBTI()
        {
            System.Random random = new System.Random();
            _MBTI mbti = new _MBTI();
            string[] mbtiTypes = mbti.GetMBTI();

            int numOfMBTIs = random.Next(1, 4);
            HashSet<int> selectedIndices = new HashSet<int>();
            List<string> selectedMBTIs = new List<string>();

            for (int i = 0; i < numOfMBTIs; i++)
            {
                int index;
                do
                {
                    index = random.Next(mbtiTypes.Length);
                } while (selectedIndices.Contains(index));

                selectedIndices.Add(index);
                selectedMBTIs.Add(mbtiTypes[index]);
            }

            return string.Join(", ", selectedMBTIs);
        }

        private string GenerateRegion()
        {
            System.Random random = new System.Random();
            _Region region = new _Region();
            List<string> regions = region.GetRegions();

            int numOfRegions = random.Next(1, 4);
            HashSet<int> selectedIndices = new HashSet<int>();
            List<string> selectedRegions = new List<string>();

            for (int i = 0; i < numOfRegions; i++)
            {
                int index;
                do
                {
                    index = random.Next(regions.Count);
                } while (selectedIndices.Contains(index));

                selectedIndices.Add(index);
                selectedRegions.Add(regions[index]);
            }

            return string.Join(", ", selectedRegions);
        }

    }
}
