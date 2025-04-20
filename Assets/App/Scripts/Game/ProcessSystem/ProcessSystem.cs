using UnityEngine;
using System.Collections.Generic;
using App.Scripts.Game.Data;
using App.Game.ProcessSystem;
using App.Common.Camera;
using App.Scripts.Game.Demand;
using App.Scripts.Game.Review;

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
        private List<GameObject> ProfileList = new List<GameObject>();
        private List<GameObject> SurveyList = new List<GameObject>();
        private float elapsedTime = 0f;
        private float ReviewTime = 0f;
        void Start()
        {
            ProcessStateHolder = new _ProcessStateHolder(DemandSystem);
            LimitTimeHolder.SetLimitTime(LimitTime);
            ActiveUserHolder.SetInitialActiveUser(InitialActiveUser);
            BGMController.PlayGameBGM();
            ProcessStateHolder.StartAnimationStarting();
        }

        void FixedUpdate()
        {
            ExecutePeriodically(ProcessInterval);
        }

        private void ExecutePeriodically(float interval)
        {
            elapsedTime += Time.deltaTime;
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
            ReviewTime = 0f;
            // ActiveUserに情報渡す
            ProcessStateHolder.StartAnimationMatched();

        }

    }
}
