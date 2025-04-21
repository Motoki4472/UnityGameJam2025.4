using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Profile
{
    public class _FaceGenerator
    {
        public GameObject facePrefab;
        public bool useRandom;
        public int[] facePartsIndex;

        //プロフィールプレハブ内のPlofileImage,偽のプロフィールかどうか、パーツのインデックスを渡す。
        public _FaceGenerator(GameObject facePrefab, bool useRandom, int[] facePartsIndex)
        {
            this.facePrefab = facePrefab;
            this.useRandom = useRandom;
            this.facePartsIndex = facePartsIndex;
        }

        public void GenerateFace()
        {
            if (useRandom)
                CreateRandomFace();
            else
                CreateFaceByIndex();
        }

        void CreateRandomFace()
        {
            Sprite hair = LoadRandomSprite("Hair");
            Sprite eyes = LoadRandomSprite("Eye");
            Sprite mouth = LoadRandomSprite("Mouth");
            Sprite decoration = LoadRandomSprite("Decoration");

            SetFaceParts(facePrefab, hair, eyes, mouth, decoration);
        }

        void CreateFaceByIndex()
        {
            int hairIdx = facePartsIndex[0];
            int eyeIdx = facePartsIndex[1];
            int mouthIdx = facePartsIndex[2];
            int decorationIdx = facePartsIndex[3];

            Sprite hair = LoadSpriteByIndex("Hair", hairIdx);
            Sprite eyes = LoadSpriteByIndex("Eye", eyeIdx);
            Sprite mouth = LoadSpriteByIndex("Mouth", mouthIdx);
            Sprite decoration = LoadSpriteByIndex("Decoration", decorationIdx);

            SetFaceParts(facePrefab, hair, eyes, mouth, decoration);
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

        void SetFaceParts(GameObject face, Sprite hair, Sprite eyes, Sprite mouth, Sprite decoration)
        {
            SetPartImage(face, "Hair", hair);
            SetPartImage(face, "Eyes", eyes);
            SetPartImage(face, "Mouth", mouth);
            SetPartImage(face, "Decoration", decoration);
        }

        void SetPartImage(GameObject parent, string childName, Sprite sprite)
        {
            Transform part = parent.transform.Find(childName);
            if (part == null)
            {
                Debug.LogWarning($"Part not found: {childName}");
                return;
            }

            Image image = part.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image component not found on: {childName}");
            }
        }
    }
}