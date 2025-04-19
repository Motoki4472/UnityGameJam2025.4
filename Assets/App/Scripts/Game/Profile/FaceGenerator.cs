using UnityEngine;

namespace App.Scripts.Game.Profile
{
    public class FaceGenerator : MonoBehaviour
    {
        public GameObject facePrefab;

        void Start()
        {
            CreateRandomFace();
        }

        void CreateRandomFace()
        {
            Vector3 spawnPosition = transform.position;

            GameObject face = Instantiate(facePrefab, spawnPosition, Quaternion.identity, transform);

            Sprite decoration = LoadRandomSprite("Decoration");
            Sprite eyes = LoadRandomSprite("Eye");
            Sprite hair = LoadRandomSprite("Hair");
            Sprite mouth = LoadRandomSprite("Mouth");

            face.transform.Find("Decoration").GetComponent<SpriteRenderer>().sprite = eyes;
            face.transform.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes;
            face.transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hair;
            face.transform.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouth;
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
    }
}
