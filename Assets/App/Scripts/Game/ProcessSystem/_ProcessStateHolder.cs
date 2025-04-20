using UnityEngine;
using App.Scripts.Game.Demand;

namespace App.Game.ProcessSystem
{
    public class _ProcessStateHolder
    {
        private enum ProcessState
        {
            waiting,
            animation_starting,
            animation_distributing,
            playing,
            animation_matched,
            animation_review,
            animation_gotoresult,
            finished,
            paused
        }

        private ProcessState state = ProcessState.waiting;

        public bool IsWaiting => state == ProcessState.waiting;
        public bool IsPlaying => state == ProcessState.playing;
        public bool IsPaused => state == ProcessState.paused;
        public bool IsFinished => state == ProcessState.finished;
        public bool IsAnimationStarting => state == ProcessState.animation_starting;
        public bool IsAnimationDistributing => state == ProcessState.animation_distributing;
        public bool IsAnimationMatched => state == ProcessState.animation_matched;
        public bool IsAnimationCollecting => state == ProcessState.animation_review;
        public bool IsAnimationGotoResult => state == ProcessState.animation_gotoresult;

        private GameObject demandSystem;

        public _ProcessStateHolder(GameObject DemandSystem)
        {
            this.demandSystem = DemandSystem;
        }

        public void Pause()
        {
            if (state == ProcessState.playing)
            {
                state = ProcessState.paused;
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == playing ｝の時に呼び出してください。");
            }
        }
        public void Resume()
        {
            if (state == ProcessState.paused)
            {
                state = ProcessState.playing;
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == paused ｝の時に呼び出してください。");
            }
        }
        public void Finish()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.finished;
                // 結果画面に遷移
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void Play()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.playing;
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void Wait()
        {
            if (state != ProcessState.paused && state != ProcessState.finished)
            {
                state = ProcessState.waiting;
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state != paused && state != finished ｝の時に呼び出してください。");
            }
        }
        public void StartAnimationStarting()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.animation_starting;
                // アニメーションの処理
                Wait();
                StartAnimationDistributing();
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void StartAnimationDistributing()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.animation_distributing;
                demandSystem.GetComponent<DemandSystem>().GenerateDemandAndProfile();
                // アニメーションの処理
                Wait();
                Play();
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void StartAnimationMatched()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.animation_matched;
                // アニメーションの処理
                //プロフィールと要望書、資料を消すアニメーションを実行
                Wait();
                StartAnimationReview();
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void StartAnimationReview()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.animation_review;
                // アニメーションの処理
                //レビューのアニメーションを実行
                Wait();
                StartAnimationDistributing();
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
        public void StartAnimationGotoResult()
        {
            if (state == ProcessState.waiting)
            {
                state = ProcessState.animation_gotoresult;
                // アニメーションの処理
                Wait();
                Finish();
            }
            else
            {
                Debug.LogError("この関数は状態が｛ state == waiting ｝の時に呼び出してください。");
            }
        }
    }
}
