using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace App.Result.Data
{

    public class _EndTextData
    {
        private List<string> End = new List<string>
        {
            "サービス終了エンド\n～さようなら、マッチング～",
            "サービス継続エンド\n～恋は止まらない～",
            "第三次ベビーブームエンド\n～マッチの果てに～"
        };

        private List<string> Epilogue = new List<string>
        {
            "ついに力尽きたあなたの手によるマッチメイキング。理想のカップルを生み出すはずが、送った通知は既読スルー、マッチした二人は初対面で口論。 レビュー欄は☆1の嵐、「運営が人力らしい」と話題にすらならず。\nそして、静かに告げられる運営終了のお知らせ。 誰にも知られず、愛の灯はそっと消えていった——。\nだが、あなたの奮闘を見ていたひとりのユーザーが、こうつぶやいた。「マッチは失敗したけど、あの通知、ちょっと笑えた」\n……それもまた、ひとつの出会い。",
            "あなたの地道なマッチングが、ついに実を結んだ！ちょっと変わったカップルもいたけれど、気づけば「意外と相性いいかも？」と盛り上がるチャットルーム。 SNSでは「このアプリ、なぜか合う」と話題になり、ユーザー数も右肩上がり！\nつぎはぎだらけのシステムでも、 “人の手による温かいマッチング”が逆にウケてしまったのだ。\nこうしてアプリは、奇跡のように生き残った。あなたは今も、パソコンの前でひと組でも多くの恋をつなげている。\n愛と根性で続く、このサービス—— 次にマッチングされるのは、あなたかもしれない。",
            "はじめは1人で行っていたマッチングも、やがて「AIより当たる」と評判になり、社会現象へと発展！「運営者が選ぶから外れない！」という信頼のもと、登録者数は億を突破。\nやがて国が動き出す。 「これを少子化対策に使おう」 政府公認マッチングアプリへと昇格し、ついには国家予算が投入される始末。\nそして起こる——第三次ベビーブーム。\n「名前の由来はこのアプリなんですよ」と語る親子があふれ、世間ではあなたを「愛の救世主」と呼ぶようになった。\nあなたがつないだ無数の赤い糸が、未来の世代へと続いていく。……でも、サーバーはそろそろ限界らしい。"
        };

        public string GetEndText(int endIndex)
        {
            if (endIndex < 0 || endIndex >= End.Count)
            {
                Debug.LogError("Invalid end index: " + endIndex);
                return null;
            }
            return End[endIndex];
        }

        public string GetEpilogueText(int epilogueIndex)
        {
            if (epilogueIndex < 0 || epilogueIndex >= Epilogue.Count)
            {
                Debug.LogError("Invalid epilogue index: " + epilogueIndex);
                return null;
            }
            return Epilogue[epilogueIndex];
        }
    }
}
