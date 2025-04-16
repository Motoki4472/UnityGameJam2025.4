using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _Constellation
    {
        private List<string> Constellations = new List<string>
        {
            "おひつじ座",
            "おうし座",
            "ふたご座",
            "かに座",
            "しし座",
            "おとめ座",
            "てんびん座",
            "さそり座",
            "いて座",
            "やぎ座",
            "みずがめ座",
            "うお座"
        };

        public List<string> GetConstellations()
        {
            return Constellations;
        }
    }
}