using System;
using UnityEngine;

namespace gamejam
{
    /// <summary>
    /// Parameter of <see cref="Timer"/>
    /// </summary>
    [Serializable]
    public class TimeParameter
    {
        [SerializeField]
        [Header("スタートコールされてからタイマーを開始する迄の遅延時間")]
        float _startTimerDelayTime;

        [SerializeField]
        [Header("タイマーの制限時間")]
        int _timeLimit;

        [SerializeField]
        float stopWatchEventTime = 1f;


        /// <summary>
        /// シナリオ終了してからタイマーを開始する迄の遅延時間
        /// </summary>
        public TimeSpan StartTimerDelayTime => TimeSpan.FromSeconds(_startTimerDelayTime);
        /// <summary>
        /// タイマーの制限時間
        /// </summary>
        public int TimeLimit => _timeLimit;

        public float StopWatchEventTime { get => stopWatchEventTime; set => stopWatchEventTime = value; }
    }
}