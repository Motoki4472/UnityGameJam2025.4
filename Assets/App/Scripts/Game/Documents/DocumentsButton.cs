using UnityEngine;
using System.Collections.Generic;
using App.Scripts.Game.Tester;

namespace App.Scripts.Game.Documents
{
    public class DocumentsButton : MonoBehaviour
    {
        [SerializeField] private List<GameObject> documentsPrefabs;
        [SerializeField] private int documentIndex = 0;
        [SerializeField] private BigTester bigTester;

        public void OnClick()
        {
            // すべてのオブジェクトの DocumentsAnimation を確認
            foreach (var document in documentsPrefabs)
            {
                if (document != null)
                {
                    DocumentsAnimation animation = document.GetComponent<DocumentsAnimation>();
                    if (animation != null && animation.IsInCamera())
                    {
                        animation.Down(); // IsInCamera が true の場合に Down を実行
                        if (documentsPrefabs.IndexOf(document) == documentIndex)
                        {
                            return;
                        }
                    }

                }
            }
            if (bigTester != null)
            {
                if(bigTester.IsInCamera())
                {
                    bigTester.OnClick();
                }
            }

            // 指定された documentIndex のオブジェクトの Up を実行
            if (documentIndex >= 0 && documentIndex < documentsPrefabs.Count)
            {
                GameObject targetDocument = documentsPrefabs[documentIndex];
                if (targetDocument != null)
                {
                    DocumentsAnimation targetAnimation = targetDocument.GetComponent<DocumentsAnimation>();
                    if (targetAnimation != null)
                    {
                        targetAnimation.Up();
                    }
                }
            }
            else
            {
                Debug.LogError("documentIndex is out of range.");
            }
        }

        public void SetDocumentPrefabs(List<GameObject> documents)
        {
            documentsPrefabs = documents;
        }
    }
}