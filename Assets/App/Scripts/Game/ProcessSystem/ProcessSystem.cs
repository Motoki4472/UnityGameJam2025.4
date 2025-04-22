using UnityEngine;
using System.Collections.Generic;
using App.Scripts.Game.Data;
using App.Game.ProcessSystem;
using App.Common.Camera;
using App.Scripts.Game.Demand;
using App.Scripts.Game.Review;
using App.Scripts.Game.AmplificationDisplay;
using System.Collections;
using UnityEditor.SearchService;
using App.Common._SceneChange;

namespace App.Game.ProcessSystem
{
    public class ProcessSystem : MonoBehaviour
    {
        private _ProcessStateHolder ProcessStateHolder;
        private _LimitTimeHolder LimitTimeHolder = new _LimitTimeHolder();
        private _ActiveUserHolder ActiveUserHolder = new _ActiveUserHolder();
        [SerializeField] private BGMController BGMController = null;
        [SerializeField] private float LimitTime = 60f;
        [SerializeField] private float ProcessInterval = 0.1f;
        [SerializeField] private int InitialActiveUser = 100000;
        [SerializeField] private int DefaultChangeValue = -10;
        [SerializeField] private int AmplificationValue = 1;
        [SerializeField] private GameObject DemandSystem;
        [SerializeField] private ReviewSystem ReviewSystem;
        [SerializeField] private TMPro.TextMeshProUGUI ActiveUserNumberDisplay;
        [SerializeField] private TMPro.TextMeshProUGUI LimitTimeDisplay;
        [SerializeField] private AmplificationAnimation AmplificationAnimation;
        [SerializeField] private SceneChange SceneChange;
        [SerializeField] private int goodornormalBorder = 1000000;
        private GameObject Demand;
        private List<GameObject> ProfileList = new List<GameObject>();
        private List<GameObject> SurveyList = new List<GameObject>();
        private float elapsedTime = 0f;
        private float ReviewTime = 0f;
        void Start()
        {
            ProcessStateHolder = new _ProcessStateHolder(DemandSystem, this);
            LimitTimeHolder.SetLimitTime(LimitTime);
            ActiveUserHolder.SetInitialActiveUser(InitialActiveUser);
            StartCoroutine(DelayedBGMStart());
            ProcessStateHolder.StartAnimationStarting();
        }

        IEnumerator DelayedBGMStart()
        {
            yield return new WaitForSeconds(0.5f);
            BGMController.PlayGameBGM();
        }

        void FixedUpdate()
        {
            ExecutePeriodically(ProcessInterval);
        }

        private void ExecutePeriodically(float interval)
        {
            elapsedTime += Time.deltaTime;
            if (ActiveUserNumberDisplay != null)
            {
                ActiveUserNumberDisplay.text = ActiveUserHolder.GetActiveUser().ToString();
            }
            if (LimitTimeDisplay != null)
            {
                LimitTimeDisplay.text = LimitTimeHolder.GetLimitTime().ToString("F1");
            }

            if (elapsedTime >= interval)
            {
                elapsedTime -= interval;
                if (ProcessStateHolder.IsWaiting)
                {
                }
                else if (ProcessStateHolder.IsPlaying)
                {
                    ReviewTime += ProcessInterval;
                    LimitTimeHolder.SubtractLimitTime(ProcessInterval);
                    ActiveUserHolder.CalculateActiveUser(DefaultChangeValue, AmplificationValue);
                    if (LimitTimeHolder.GetLimitTime() <= 0f)
                    {
                        ProcessStateHolder.Wait();
                        ProcessStateHolder.Finish();

                        // 結果シーンに遷移
                        if (ActiveUserHolder.GetActiveUser() >= goodornormalBorder)
                        {
                            SceneChange.ToResult(_SceneChangeManager.EndName.GoodEnd, ActiveUserHolder.GetActiveUser(), ActiveUserHolder.GetPeakActiveUser());
                        }
                        else
                        {
                            SceneChange.ToResult(_SceneChangeManager.EndName.NormalEnd, ActiveUserHolder.GetActiveUser(), ActiveUserHolder.GetPeakActiveUser());
                        }
                    }
                    if (ActiveUserHolder.GetActiveUser() <= 0)
                    {
                        ProcessStateHolder.Wait();
                        ProcessStateHolder.Finish();

                        // 結果シーンに遷移
                        SceneChange.ToResult(_SceneChangeManager.EndName.BadEnd, 0, ActiveUserHolder.GetPeakActiveUser());
                    }
                }
                else if (ProcessStateHolder.IsPaused)
                {
                }
                else if (ProcessStateHolder.IsFinished)
                {
                }
            }
        }
        public void SetDemand(GameObject demand)
        {
            Demand = demand;
        }
        public GameObject GetDemand()
        {
            return Demand;
        }

        public void SetProfileList(List<GameObject> profileList)
        {
            ProfileList = profileList;
        }
        public List<GameObject> GetProfileList()
        {
            return ProfileList;
        }

        public void SetSurveyList(List<GameObject> surveyList)
        {
            SurveyList = surveyList;
        }
        public List<GameObject> GetSurveyList()
        {
            return SurveyList;
        }

        public void Match(bool isCorrect)
        {

            if (!ProcessStateHolder.IsPlaying) return;
            ReviewSystem.GenerateReviewComment(ReviewTime, isCorrect);
            if (isCorrect)
            {
                if (ReviewSystem.Star == 5)
                {
                    ActiveUserHolder.AddMagnificationValue();
                    ActiveUserHolder.AddMagnificationValue();
                    ActiveUserHolder.AddMagnificationValue();
                }
                else if (ReviewSystem.Star == 4)
                {
                    ActiveUserHolder.AddMagnificationValue();
                    ActiveUserHolder.AddMagnificationValue();
                }
                else if (ReviewSystem.Star == 3)
                {
                    ActiveUserHolder.AddMagnificationValue();
                }
            }
            else
            {
                if (ReviewSystem.Star == 2)
                {
                    ActiveUserHolder.SubtractMagnificationValue();
                }
                else if (ReviewSystem.Star == 1)
                {
                    ActiveUserHolder.SubtractMagnificationValue();
                    ActiveUserHolder.SubtractMagnificationValue();
                }
                else if (ReviewSystem.Star == 0)
                {
                    ActiveUserHolder.SubtractMagnificationValue();
                    ActiveUserHolder.SubtractMagnificationValue();
                    ActiveUserHolder.SubtractMagnificationValue();
                }
            }

            ReviewTime = 0f;
            AmplificationAnimation.StartAnimation(AmplificationValue, isCorrect, ReviewSystem.Star);
            Debug.Log($"AmplificationValue: {AmplificationValue}");
            // ActiveUserに情報渡す
            ProcessStateHolder.Wait();
            ProcessStateHolder.StartAnimationMatched();
        }
    }
}
