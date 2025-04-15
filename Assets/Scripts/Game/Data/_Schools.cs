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

        public List<string> GetSchools(int type)
        {
            switch (type)
            {
                case 0:
                    return Universities;
                case 1:
                    return VocationalCollege;
                case 2:
                    return HighSchool;
                case 3:
                    List<string> Schools = new List<string>();
                    Schools.AddRange(Universities);
                    Schools.AddRange(VocationalCollege);
                    return Schools;
                case 4:
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
    }
}