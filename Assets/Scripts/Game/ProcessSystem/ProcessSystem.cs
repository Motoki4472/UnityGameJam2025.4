using UnityEngine;
using App.Scripts.Game.Data;
using App.Game.ProcessSystem;
using App.Common.Camera;

namespace App.Game.ProcessSystem
{
    public class ProcessSystem : MonoBehaviour
    {
        private _ProcessStateHolder ProcessStateHolder = new _ProcessStateHolder();
        private _LimitTimeHolder LimitTimeHolder = new _LimitTimeHolder();
        private _ActiveUserHolder ActiveUserHolder = new _ActiveUserHolder();
        [SerializeField] private float LimitTime = 60f;
        [SerializeField] private float ProcessInterval = 0.1f;
        [SerializeField] private int InitialActiveUser = 100000;
        [SerializeField] private int DefaultChangeValue = -10;
        [SerializeField] private int AmplificationValue = 1;
        private float elapsedTime = 0f;
        void Start()
        {
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
                    LimitTimeHolder.SubtractLimitTime(ProcessInterval);
                    ActiveUserHolder.CalculateActiveUser(DefaultChangeValue, AmplificationValue);
                    if (LimitTimeHolder.GetLimitTime() <= 0f)
                    {
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
    }
}
