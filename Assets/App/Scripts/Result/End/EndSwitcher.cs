using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

using App.Common._SceneChange;
using App.Result.Data;

namespace App.Result.End
{
    public class EndSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _resultDataHolder;
        [SerializeField] private GameObject _endText;
        [SerializeField] private GameObject _epilogueText;
        [SerializeField] private GameObject _endIlust;
        [SerializeField] private List<Sprite> _endSprites;

        void Start()
        {
            _EndTextData endTextData = new _EndTextData();
            TextMeshProUGUI _endTextTMP = _endText.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI _epilogueTextTMP = _epilogueText.GetComponent<TextMeshProUGUI>();
            Image endIlustImage = _endIlust.GetComponent<Image>();

            if (_resultDataHolder != null)
            {
                var resultData = _resultDataHolder.GetComponent<ResultDataHolder>();
                if (resultData != null)
                {
                    switch (resultData.endName)
                    {
                        case _SceneChangeManager.EndName.BadEnd:
                            _endTextTMP.text = endTextData.GetEndText(0);
                            _epilogueTextTMP.text = endTextData.GetEpilogueText(0);
                            endIlustImage.sprite = _endSprites[0];
                            break;
                        case _SceneChangeManager.EndName.NormalEnd:
                            _endTextTMP.text = endTextData.GetEndText(1);
                            _epilogueTextTMP.text = endTextData.GetEpilogueText(1);
                            endIlustImage.sprite = _endSprites[1];
                            break;
                        case _SceneChangeManager.EndName.GoodEnd:
                            _endTextTMP.text = endTextData.GetEndText(2);
                            _epilogueTextTMP.text = endTextData.GetEpilogueText(2);
                            endIlustImage.sprite = _endSprites[2];
                            break;
                    }
                }
                else
                {
                    Debug.LogError("ResultDataHolderが見つかりません。");
                }
            }
            else
            {
                Debug.LogError("ResultDataHolderが見つかりません。");
            }
        }
    }
}
