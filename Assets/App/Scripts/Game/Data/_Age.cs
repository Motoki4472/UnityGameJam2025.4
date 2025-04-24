using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Data
{
    public class _Age
    {
        private Dictionary<string, (int, int)> ageGroups = new Dictionary<string, (int, int)>
        {
            { "10代", (18, 19) },
            { "20代", (20, 29) },
            { "30代", (30, 39) },
            { "40代", (40, 49) },
            { "21以下",(18, 21) },
            { "22以下",(18, 22) },
            { "23以下",(18, 23) },
            { "24以下",(18, 24) },
            { "25以下",(18, 25) },
            { "26以下",(18, 26) },
            { "27以下",(18, 27) },
            { "28以下",(18, 28) },
            { "29以下",(18, 29) },
            { "30以下",(18, 30) },
            { "31以下",(18, 31) },
            { "32以下",(18, 32) },
            { "33以下",(18, 33) },
            { "34以下",(18, 34) },
            { "35以下",(18, 35) },

        };

        public string GetAgeRange()
        {
            System.Random random = new System.Random();
            var keys = ageGroups.Keys.ToList();
            int index = random.Next(keys.Count);
            return keys[index];
        }

        public (int, int) GetAge(string ageGroup)
        {
            if (ageGroups.ContainsKey(ageGroup))
            {
                return ageGroups[ageGroup];
            }
            else
            {
                Debug.LogError("Invalid age group provided. Returning default value.");
                return (0, 0);
            }
        }

    }
}