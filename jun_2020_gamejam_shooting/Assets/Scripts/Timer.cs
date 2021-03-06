﻿using System;
using UniRx.Async;
using UnityEngine;

namespace gamejam
{
    public class Timer
    {
        private TimeParameter timeParam = null;

        public Timer() { }
        public Timer(TimeParameter timeParam)
        {
            this.timeParam = timeParam;
        }

        /// <summary>
        /// Event issued when the countdown starts.
        /// </summary>
        public event Action OnStartTimer = () => { };

        /// <summary>
        /// Event issued during the countdown.
        /// </summary>
        public event Action OnDuringTimer = () => { };

        /// <summary>
        /// Event issued when the countdown ends.
        /// </summary>
        public event Action OnEndTimer = () => { };

        public event Action OnStopWatchEvent = () => { };

        /// <summary>
        /// TimeLimit.
        /// </summary>
        public int TimeLimit { get; private set; } = 0;

        /// <summary>
        /// Current elapsed time.
        /// </summary>
        public float RemainsTime { get; private set; } = 0f;

        /// <summary>
        /// Is the timer running.
        /// </summary>
        public bool IsTimerRunning { get; private set; } = false;

        float remainTimeOfStopWatch;
        /// <summary>
        /// 毎フレーム時間経過させる。
        /// タイムリミット
        /// Add timer every frame.
        /// </summary>
        public void UpdateTimer()
        {
            if (!IsTimerRunning) return;

            RemainsTime -= Time.deltaTime;
            remainTimeOfStopWatch -= Time.deltaTime;

            OnDuringTimer?.Invoke();
            if (remainTimeOfStopWatch <= 0)
            {
                OnStopWatchEvent?.Invoke();
                remainTimeOfStopWatch = timeParam.StopWatchEventTime; 
            }

            if (RemainsTime <= 0)
            {
                OnEndTimer?.Invoke();
                IsTimerRunning = false;
            }
        }
        /// <summary>
        /// タイマースタート
        /// </summary>
        /// <param name="timeLimit"></param>
        /// <param name="delayTime"></param>
         void StartTimer(int timeLimit)
        {
            RemainsTime = TimeLimit = timeLimit;
            IsTimerRunning = true;
            OnStartTimer?.Invoke();
        }

        /// <summary>
        /// <see cref="timeParam"/> の情報を使用してタイマースタート
        /// </summary>
        public void StartTimer()
        {
            if (timeParam == null) throw new NullReferenceException($"timePramはnull");
            remainTimeOfStopWatch = timeParam.StopWatchEventTime;
            StartTimer(timeParam.TimeLimit);
        }



        /// <summary>
        /// 指定秒数遅延してからタイマースタート
        /// </summary>
        /// <param name="timeLimit"></param>
        /// <param name="delayTime"></param>
        public async void DelayStartTimerAsync(int timeLimit, TimeSpan delayTime)
        {
            await UniTask.Delay(delayTime);

            RemainsTime = TimeLimit = timeLimit;
            IsTimerRunning = true;
            OnStartTimer?.Invoke();
        }

        /// <summary>
        /// <see cref="timeParam"/> の情報を使用して遅延タイマースタート
        /// </summary>
        public void DelayStartTimerAsync()
        {
            if (timeParam == null) throw new NullReferenceException($"timePramはnull");
            DelayStartTimerAsync(timeParam.TimeLimit, timeParam.StartTimerDelayTime);
        }

        /// <summary>
        /// Pause timer.
        /// </summary>
        public void StopTimer()
        {
            IsTimerRunning = false;
        }

        /// <summary>
        /// Resume timer.
        /// </summary>
        public void ResumeTimer()
        {
            IsTimerRunning = true;
        }
    }
}