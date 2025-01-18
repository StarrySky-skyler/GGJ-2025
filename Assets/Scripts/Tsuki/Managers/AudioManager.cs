// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 14:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Tsuki.Weather;
using UnityEngine;

namespace Tsuki.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        [Header("音频配置")]
        public AudioSource bgmAudioSource;
        public AudioSource soundEffectAudioSource;
        public AudioSource weatherAudioSource;

        private void Awake()
        {
            Instance = this;
            soundEffectAudioSource.loop = false;
            weatherAudioSource.loop = false;
        }

        private void Start()
        {
            // 注册事件
            WeatherManager.Instance.OnSeasonChanged += PlayBgm;
        }

        /// <summary>
        /// 播放季节bgm
        /// </summary>
        /// <param name="season"></param>
        private void PlayBgm(SeasonTye season)
        {
            bgmAudioSource.Stop();
            AudioClip clip = Resources.Load<AudioClip>("AudioClips/Bgm/春");
            switch (season)
            {
                case SeasonTye.Spring:
                    clip = Resources.Load<AudioClip>("AudioClips/Bgm/春");
                    break;
                case SeasonTye.Summer:
                    clip = Resources.Load<AudioClip>("AudioClips/Bgm/夏");
                    break;
                case SeasonTye.Autumn:
                    clip = Resources.Load<AudioClip>("AudioClips/Bgm/秋");
                    break;
                case SeasonTye.Winter:
                    clip = Resources.Load<AudioClip>("AudioClips/Bgm/冬");
                    break;
            }
            bgmAudioSource.clip = clip;
            bgmAudioSource.Play();
        }

        /// <summary>
        /// 播放天气音效
        /// </summary>
        /// <param name="weather"></param>
        public void PlaySoundEffects(WeatherType weather)
        {
            AudioClip clip;
            switch (weather)
            {
                case WeatherType.Hurricane:
                    clip = Resources.Load<AudioClip>("AudioClips/SoundEffects/风");
                    soundEffectAudioSource.PlayOneShot(clip);
                    break;
                case WeatherType.Rainy:
                    clip = Resources.Load<AudioClip>("AudioClips/SoundEffects/雨");
                    soundEffectAudioSource.PlayOneShot(clip);
                    break;
                case WeatherType.Lightning:
                    clip = Resources.Load<AudioClip>("AudioClips/SoundEffects/闪电");
                    soundEffectAudioSource.PlayOneShot(clip);
                    break;
                case WeatherType.Hail:
                    clip = Resources.Load<AudioClip>("AudioClips/SoundEffects/冰雹");
                    soundEffectAudioSource.PlayOneShot(clip);
                    break;
            }
        }
    }
}
