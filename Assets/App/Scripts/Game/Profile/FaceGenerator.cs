using UnityEngine;

namespace App.Scripts.Game.Profile
{
    public class FaceGenerator : MonoBehaviour
    {
        public GameObject facePrefab;

        // ランダム or 指定生成
        public bool useRandom = true;

        // 指定するインデックス（Inspectorから入力してもOK）
        public int decorationIndex = 0;
        public int eyeIndex = 0;
        public int hairIndex = 0;
        public int mouthIndex = 0;

        void Start()
        {
            if (useRandom)
                CreateRandomFace();
            else
                CreateFaceByIndex(decorationIndex, eyeIndex, hairIndex, mouthIndex);
        }

        void CreateRandomFace()
        {
            Vector3 spawnPosition = transform.position;

            GameObject face = Instantiate(facePrefab, spawnPosition, Quaternion.identity, transform);

            Sprite decoration = LoadRandomSprite("Decoration");
            Sprite eyes = LoadRandomSprite("Eye");
            Sprite hair = LoadRandomSprite("Hair");
            Sprite mouth = LoadRandomSprite("Mouth");

            SetFaceParts(face, decoration, eyes, hair, mouth);
        }

        Sprite LoadRandomSprite(string folder)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(folder);
            if (sprites.Length == 0)
            {
                Debug.LogWarning($"No sprites found in Resources/{folder}");
                return null;
            }
            return sprites[Random.Range(0, sprites.Length)];
        }

        void CreateFaceByIndex(int decorationIdx, int eyeIdx, int hairIdx, int mouthIdx)
        {
            GameObject face = Instantiate(facePrefab, transform);
            face.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            Sprite decoration = LoadSpriteByIndex("Decoration", decorationIdx);
            Sprite eyes = LoadSpriteByIndex("Eyes", eyeIdx);
            Sprite hair = LoadSpriteByIndex("Hair", hairIdx);
            Sprite mouth = LoadSpriteByIndex("Mouth", mouthIdx);

            SetFaceParts(face, decoration, eyes, hair, mouth);
        }

        Sprite LoadSpriteByIndex(string folder, int index)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(folder);
            if (sprites.Length == 0 || index < 0 || index >= sprites.Length)
            {
                Debug.LogWarning($"Invalid index ({index}) for folder: {folder}");
                return null;
            }
            return sprites[index];
        }

        void SetFaceParts(GameObject face, Sprite decoration, Sprite eyes, Sprite hair, Sprite mouth)
        {
            face.transform.Find("Decoration").GetComponent<SpriteRenderer>().sprite = decoration;
            face.transform.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes;
            face.transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hair;
            face.transform.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouth;
        }
    }
}
