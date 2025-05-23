using UnityEngine;
using System.Collections.Generic;

namespace App.Scripts.Game.Data
{
    public class _PersonName
    {
        private List<string> FirstNames = new List<string>
        {
            "一花",
            "七海",
            "万紗子",
            "万里菜",
            "三佳",
            "久子",
            "久恵",
            "久美",
            "久美子",
            "乱",
            "亜利沙",
            "亜季子",
            "亜希子",
            "亜弥",
            "亜矢子",
            "亜紀",
            "亜紀子",
            "亜美",
            "亜華梨",
            "亜衣子",
            "亜衿",
            "亜香里",
            "京加",
            "京子",
            "仁美",
            "今日子",
            "佑唯",
            "佑子",
            "佑香",
            "佳奈子",
            "佳香",
            "侑希",
            "保奈美",
            "修子",
            "優",
            "優佳",
            "優佳里",
            "優奈",
            "優子",
            "優実",
            "優寧",
            "優樹菜",
            "優民",
            "優理",
            "優美",
            "優花",
            "優芽",
            "優菜",
            "優衣",
            "優里奈",
            "優香",
            "光",
            "典子",
            "典愛",
            "冬優花",
            "凛々花",
            "凛香",
            "凪",
            "加奈",
            "勝美",
            "十和子",
            "千夏",
            "千尋",
            "千恵",
            "千捺",
            "千春",
            "千晃",
            "千花",
            "千菜",
            "千里",
            "千香",
            "南朋",
            "友穂",
            "友紀",
            "友香",
            "史織",
            "和叶",
            "和美",
            "和香",
            "咲",
            "咲子",
            "咲流",
            "咲良",
            "唯",
            "啓菜",
            "圭澄",
            "夏季",
            "夏希",
            "夏摘",
            "夏月",
            "夏樹",
            "夏海",
            "夏美",
            "夏菜",
            "夏菜実",
            "夕子",
            "夕眞",
            "夕里香",
            "夢奈",
            "夢子",
            "央佳",
            "奈々",
            "奈々子",
            "奈々未",
            "奈々美",
            "奈々香",
            "奈央",
            "奈子",
            "奈津美",
            "奈緒",
            "奈美",
            "奈那",
            "奈那華",
            "好珠",
            "姫",
            "実来",
            "寛子",
            "小夜子",
            "小百合",
            "小麟",
            "尚子",
            "峰子",
            "希実",
            "希明",
            "希美",
            "幸子",
            "幹代",
            "広子",
            "広香",
            "弓束",
            "弘子",
            "弘美",
            "弥生",
            "彩",
            "彩乃",
            "彩也香",
            "彩会",
            "彩佳",
            "彩夏",
            "彩水",
            "彩花",
            "彩香",
            "彰子",
            "心",
            "心春",
            "心美",
            "心葉",
            "志乃",
            "志保",
            "志歩",
            "志穂",
            "怜",
            "怜奈",
            "恋",
            "恋々",
            "恭加",
            "恭子",
            "恵",
            "恵利",
            "恵子",
            "恵理子",
            "恵美",
            "恵美子",
            "恵里伽",
            "悠",
            "悠理",
            "悠理枝",
            "悠貴",
            "悦子",
            "愛",
            "愛佳",
            "愛加",
            "愛奈",
            "愛子",
            "愛実",
            "愛月",
            "愛海",
            "愛理",
            "愛真",
            "愛莉鈴",
            "愛里",
            "愛里奈",
            "愛里沙",
            "慶美",
            "成子",
            "政江",
            "文乃",
            "文香",
            "新音",
            "日芽香",
            "早姫",
            "早希",
            "早紀",
            "早織",
            "早耶",
            "早記",
            "明日菜",
            "明日香",
            "明音",
            "星香",
            "春奈",
            "春花",
            "景子",
            "景織子",
            "晶保",
            "晶子",
            "智子",
            "智実",
            "智美",
            "智香",
            "有咲",
            "有基",
            "有希",
            "有望",
            "有未",
            "有沙",
            "有紀",
            "有紀奈",
            "有美",
            "有羽",
            "有華",
            "有香",
            "朋果",
            "望",
            "望叶",
            "望愛",
            "未久",
            "未央",
            "未季",
            "未帆",
            "未来",
            "未遥",
            "朱合",
            "朱桃",
            "杏南",
            "杏奈",
            "杏子",
            "杏月",
            "杏菜",
            "杏里",
            "来夢",
            "果歩",
            "柚愛",
            "柚花",
            "柚香",
            "栞",
            "栞帆",
            "栞那",
            "桃夏",
            "桃奈",
            "桃子",
            "桃果",
            "桃香",
            "桐子",
            "桜子",
            "梓",
            "梓帆",
            "梨々子",
            "梨央",
            "梨奈",
            "梨穂",
            "梨緒",
            "椰子",
            "楊子",
            "楓",
            "歩",
            "歩夢",
            "水柚",
            "水絵",
            "汐里",
            "江梨子",
            "沙也加",
            "沙代子",
            "沙怜",
            "沙空",
            "沙紀",
            "沙絵子",
            "沙緒里",
            "沙織",
            "沙耶",
            "沙耶香",
            "泉",
            "法子",
            "洋子",
            "洋美",
            "流花",
            "流衣",
            "流那",
            "海佑",
            "海星",
            "海月",
            "海荷",
            "涼子",
            "涼花",
            "深雪",
            "淳子",
            "清美",
            "渚",
            "渚紗",
            "満彩",
            "潤",
            "澄香",
            "澪",
            "瀬奈",
            "瀬里奈",
            "玲",
            "玲佳",
            "玲央奈",
            "玲海菜",
            "理央",
            "理奈",
            "理恵",
            "理江",
            "理沙",
            "理美",
            "理莉",
            "琉衣",
            "琴美",
            "琴音",
            "瑞希",
            "瑠璃亜",
            "瑠見",
            "瑠那",
            "璃花",
            "由佳",
            "由真",
            "由紀",
            "由紀代",
            "由美",
            "由美子",
            "由美香",
            "由衣",
            "由貴",
            "由香",
            "留華",
            "百々花",
            "百合",
            "百合子",
            "百花",
            "百菜",
            "百萌香",
            "皐生",
            "益代",
            "直子",
            "真依",
            "真利奈",
            "真喜子",
            "真央",
            "真姫宝",
            "真宵",
            "真希",
            "真弓",
            "真心",
            "真未",
            "真樹",
            "真澄",
            "真理佳",
            "真理子",
            "真琴",
            "真由美",
            "真紀",
            "真緒",
            "真美",
            "瞳",
            "知世",
            "知夏",
            "知子",
            "知恵子",
            "知美",
            "砂羽",
            "礼央奈",
            "礼子",
            "祐実",
            "祐希",
            "神音",
            "祥子",
            "稚菜",
            "穂乃",
            "穂乃果",
            "穂之香",
            "笑子",
            "節子",
            "紀江",
            "純",
            "純奈",
            "純子",
            "紗世",
            "紗也",
            "紗和子",
            "紗季",
            "紗希",
            "素子",
            "紫之",
            "結子",
            "結月",
            "結衣",
            "絢音",
            "絵未梨",
            "絵梨",
            "絵美",
            "絵麻",
            "綾乃",
            "綾子",
            "綾香",
            "緋杏",
            "緑",
            "織江",
            "繭子",
            "美乃里",
            "美代子",
            "美佑",
            "美佳",
            "美保",
            "美保子",
            "美優",
            "美和",
            "美咲",
            "美奈",
            "美好",
            "美希",
            "美弥子",
            "美愉",
            "美憂",
            "美月",
            "美桜",
            "美樹",
            "美波",
            "美玲",
            "美理",
            "美瑠",
            "美知子",
            "美穂",
            "美紀",
            "美緒",
            "美織",
            "美羽",
            "美里",
            "美音",
            "美香",
            "翔",
            "耀",
            "聖子",
            "聡子",
            "胡花",
            "與惠",
            "舞",
            "舞子",
            "舞羽",
            "舞菜",
            "良子",
            "艶子",
            "芯",
            "花",
            "花凜",
            "芳怜",
            "芹奈",
            "芽実",
            "若菜",
            "若葉",
            "英梨子",
            "英里奈",
            "英里香",
            "苺",
            "茉央",
            "茉莉也",
            "莉々",
            "莉乃",
            "莉佳子",
            "莉央奈",
            "莉奈",
            "莉緒",
            "莉那",
            "菜々",
            "菜々子",
            "菜々巳",
            "菜央",
            "菜絵",
            "菫",
            "萌",
            "萌々子",
            "萌々香",
            "萌乃",
            "萌維",
            "萌香",
            "葉瑠",
            "葵",
            "薫",
            "藍",
            "藍里",
            "蛍",
            "裕子",
            "詩乃",
            "詩織",
            "貴子",
            "輝美",
            "遥",
            "那美",
            "郁海",
            "里夢",
            "里奈",
            "里歩",
            "里沙",
            "里穂",
            "里紗",
            "里緒",
            "里莉",
            "里菜",
            "里華",
            "里香",
            "鈴華",
            "陽子",
            "陽菜",
            "雪乃",
            "雪奈",
            "雫",
            "静奈",
            "静香",
            "音色",
            "響",
            "響子",
            "風詩",
            "飛鳥",
            "香奈",
            "香織",
            "香菜子",
            "麗",
            "麗央",
            "麗奈",
            "麗来",
            "麗華",
            "麻友",
            "麻妃",
            "麻妙",
            "麻子",
            "麻未",
            "麻琴",
            "麻美",
            "麻衣",
            "麻衣子",
            "麻都",
            "麻里",
            "麻里奈"

            
        };

        private List<string> LastNames = new List<string>
        {
            "一ノ瀬",
            "一戸",
            "一色",
            "三井",
            "三原",
            "三宅",
            "三島",
            "三村",
            "三橋",
            "三浦",
            "三船",
            "上原",
            "上尾野辺",
            "上村",
            "上田",
            "上甲",
            "上里",
            "下山",
            "下野",
            "中井",
            "中原",
            "中島",
            "中川",
            "中村",
            "中林",
            "中澤",
            "中野",
            "丸尾",
            "久保",
            "久藤",
            "乙音",
            "二宮",
            "五十嵐",
            "井上",
            "井生",
            "亘",
            "仁田尾",
            "仁藤",
            "今井",
            "今野",
            "仲田",
            "伊東",
            "伊藤",
            "伊達",
            "会田",
            "佃",
            "佐々木",
            "佐伯",
            "佐川",
            "佐藤",
            "佐野",
            "倖田",
            "入山",
            "入江",
            "八代",
            "八十",
            "八田",
            "八重樫",
            "内田",
            "内藤",
            "内間",
            "冨士",
            "冴木",
            "冴羽",
            "出町",
            "前田",
            "加藤",
            "勝又",
            "北",
            "北乃",
            "北野",
            "十川",
            "半田",
            "南",
            "南野",
            "卯月",
            "原",
            "原田",
            "古崎",
            "古川",
            "古賀",
            "古里",
            "可愛手",
            "吉川",
            "吉村",
            "吉永",
            "吉田",
            "吉野",
            "向井",
            "和中",
            "和田",
            "国府田",
            "国見",
            "国頭",
            "園田",
            "園部",
            "土本",
            "坂上",
            "坂元",
            "坂巻",
            "城野",
            "堀井",
            "堀川",
            "堤",
            "塚野",
            "塩村",
            "増本",
            "大下",
            "大久保",
            "大園",
            "大山",
            "大岩",
            "大島",
            "大川",
            "大松",
            "大林",
            "大根",
            "大槻",
            "大田",
            "大網",
            "大谷",
            "大野",
            "天川",
            "太田",
            "奥井",
            "宅和",
            "宇佐美",
            "宇佐見",
            "宇垣",
            "宇野",
            "守屋",
            "安来",
            "安陪",
            "宍戸",
            "宝生",
            "宮前",
            "宮原",
            "宮園",
            "宮崎",
            "宮本",
            "宮田",
            "宮里",
            "家村",
            "寺本",
            "寺田",
            "小向",
            "小室",
            "小宮",
            "小宮山",
            "小山",
            "小岩",
            "小島",
            "小川",
            "小日向",
            "小林",
            "小滝",
            "小澤",
            "小牧",
            "小畑",
            "小谷",
            "小野",
            "小野沢",
            "小門",
            "小高",
            "山中",
            "山内",
            "山口",
            "山形",
            "山本",
            "山瀬",
            "山田",
            "山野",
            "岡本",
            "岡村",
            "岡田",
            "岡野",
            "岩崎",
            "岩田",
            "岬",
            "岸本",
            "島",
            "島原",
            "島津",
            "嵯峨",
            "川口",
            "川崎",
            "川浪",
            "川股",
            "工藤",
            "己浪",
            "巻",
            "市川",
            "平井",
            "平岡",
            "平松",
            "平江",
            "平田",
            "広岡",
            "広田",
            "広野",
            "庄司",
            "廣池",
            "廣瀬",
            "後藤",
            "成沢",
            "成澤",
            "成田",
            "戸倉",
            "戸川",
            "掛布",
            "斎田",
            "新井",
            "新浦",
            "新海",
            "新里",
            "日向",
            "早坂",
            "早瀬",
            "星空",
            "春日井",
            "春野",
            "景山",
            "月足",
            "有倉",
            "有奈",
            "有田",
            "有町",
            "服部",
            "望月",
            "朝日",
            "朝比奈",
            "木崎",
            "木本",
            "木村",
            "本田",
            "杉内",
            "杉山",
            "杉本",
            "杉田屋",
            "村山",
            "村松",
            "村田",
            "来栖",
            "東出",
            "東新",
            "松原",
            "松尾",
            "松岡",
            "松本",
            "松村",
            "松浦",
            "林",
            "柏瀬",
            "柳瀬",
            "柳田",
            "柿本",
            "根本",
            "桃瀬",
            "桑原",
            "桜井",
            "桜田",
            "桜羽",
            "桝田",
            "桶川",
            "梅原",
            "梅山",
            "梅田",
            "梶原",
            "森",
            "森下",
            "森滝",
            "森野",
            "植田",
            "椎名",
            "椿",
            "榊",
            "樋口",
            "権東",
            "横内",
            "横田",
            "樽井",
            "橋下",
            "橘",
            "櫻井",
            "櫻田",
            "武藤",
            "水原",
            "水咲",
            "水川",
            "水澤",
            "水落",
            "水谷",
            "水野",
            "永井",
            "永山",
            "永木",
            "池上",
            "池田",
            "沖",
            "沖田",
            "沖野",
            "沢山",
            "河中",
            "河愛",
            "河辺",
            "河野",
            "波夛野",
            "津田",
            "浅生",
            "浜",
            "浜口",
            "浜名",
            "浜浦",
            "浦島",
            "浦田",
            "涼宮",
            "深澤",
            "深田",
            "深谷",
            "清原",
            "清水",
            "清田",
            "清野",
            "渋谷",
            "渡辺",
            "渡邊",
            "湊川",
            "湯口",
            "滑川",
            "滝沢",
            "濱涯",
            "瀬名",
            "照井",
            "片山",
            "片岡",
            "片平",
            "片瀬",
            "片貝",
            "牧",
            "狩野",
            "猪子",
            "琴吹",
            "生田",
            "生駒",
            "田中",
            "田代",
            "田原",
            "田島",
            "田村",
            "田沢",
            "田畑",
            "田邉",
            "當間",
            "白木",
            "白石",
            "白谷",
            "白鳥",
            "皆月",
            "益田",
            "盛島",
            "盛田",
            "真白",
            "真鍋",
            "矢吹",
            "矢畑",
            "矢野",
            "石井",
            "石原",
            "石塚",
            "石川",
            "石田",
            "石谷",
            "磯田",
            "神代",
            "神波多",
            "神納",
            "神野",
            "福井",
            "福嶋",
            "福永",
            "福留",
            "秋本",
            "種部",
            "稲葉",
            "穂波",
            "穂高",
            "立花",
            "立野",
            "竹之内",
            "竹内",
            "竹村",
            "竹重",
            "笹垣",
            "篠岬",
            "篠田",
            "米山",
            "米村",
            "米沢",
            "米津",
            "籾井",
            "納家",
            "細川",
            "細谷",
            "紺野",
            "結城",
            "緒奈",
            "緒方",
            "美月",
            "美輪",
            "羽山",
            "羽田",
            "與山",
            "船田",
            "船越",
            "船迫",
            "良川",
            "花音",
            "芳村",
            "若松",
            "若林",
            "茅野",
            "草木",
            "荒井",
            "荒川",
            "荒巻",
            "荒谷",
            "菅井",
            "菅野",
            "菊地",
            "萩原",
            "落合",
            "葦原",
            "蓮見",
            "藤井",
            "藤原",
            "藤吉",
            "藤山",
            "藤島",
            "藤崎",
            "藤森",
            "藤江",
            "藤澤",
            "藤瀬",
            "藤田",
            "藪",
            "西",
            "西垣",
            "西山",
            "西川",
            "西村",
            "西森",
            "西澤",
            "西田",
            "観月",
            "角田",
            "谷口",
            "豊田",
            "赤星",
            "赤木",
            "越智",
            "辻",
            "通野",
            "運上",
            "遠藤",
            "遥",
            "郡司",
            "都並",
            "里田",
            "重松",
            "野崎",
            "野村",
            "野波",
            "金井",
            "金園",
            "金城",
            "金山",
            "金森",
            "金沢",
            "金田",
            "針谷",
            "鈴木",
            "長",
            "長月",
            "長田",
            "長谷川",
            "門倉",
            "門原",
            "門田",
            "間宮",
            "関",
            "関口",
            "関本",
            "関根",
            "阿部",
            "青山",
            "青木",
            "青田",
            "鞘師",
            "音嶋",
            "音市",
            "風岡",
            "風谷",
            "風間",
            "飯田",
            "館山",
            "香川",
            "高宮",
            "高岡",
            "高島",
            "高松",
            "高林",
            "高柳",
            "高梨",
            "高橋",
            "高江洲",
            "高瀬",
            "高雄",
            "鳥越",
            "鳴尾",
            "鵜狩",
            "鹿谷",
            "黒原",
            "黒沢",
            "黒羽",
            "黒部",
            "齋藤"

        };

        public List<string> GetPersonName(int firstNameIndex, int lastNameIndex)
        {
            List<string> personName = new List<string>();
            personName.Add(LastNames[lastNameIndex]);
            personName.Add(FirstNames[firstNameIndex]);
            
            return personName;
        }

        public int GetFirstNameCount()
        {
            return FirstNames.Count;
        }
        public int GetLastNameCount()
        {
            return LastNames.Count;
        }
    }
}