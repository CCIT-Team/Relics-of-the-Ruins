

using System.Collections.Generic;
using UnityEngine;
namespace Manager.Core
{
    public class SoundManager
    {
        private AudioSource[] _audioSources = new AudioSource[(int)Utils.Defines.SoundChannels.MAX_CHANNELS];

        private Dictionary<string, AudioClip> _cachedAudioClips = new Dictionary<string, AudioClip>();

        private GameObject _soundRoot = null;


        public void Init()
        {
            if (_soundRoot == null)
            {
                _soundRoot = GameObject.Find("@SoundRoot");
                if (_soundRoot == null)
                {
                    _soundRoot = new GameObject { name = "@SoundRoot" };
                    UnityEngine.Object.DontDestroyOnLoad(_soundRoot);

                    string[] soundTypeNames = System.Enum.GetNames(typeof(Utils.Defines.SoundChannels));
                    for (int count = 0, maxCnt = (int)Utils.Defines.SoundChannels.MAX_CHANNELS; count < maxCnt; count++)
                    {
                        GameObject go = new GameObject { name = soundTypeNames[count] };
                        _audioSources[count] = go.AddComponent<AudioSource>();
                        go.transform.parent = _soundRoot.transform;
                    }
                }
            }
        }

        public void Play(Utils.Defines.SoundChannels channel, string key, bool loop, float volume = 1.0f, float pitch = 1.0f)
        {
            if (channel < Utils.Defines.SoundChannels.BGM_0 || channel >= Utils.Defines.SoundChannels.MAX_CHANNELS)
            {
#if UNITY_EDITOR
                Debug.LogWarning("wrong channel number");
#endif  
                return;
            }

            AudioSource audioSource = _audioSources[(int)channel];
            AudioClip clip = LoadAudioClip(key);

            if (clip is null)
            {
                return;
            }

            audioSource.pitch = pitch;
            audioSource.volume = volume;

            if (channel < Utils.Defines.SoundChannels.EFFECT_0)
            {
                audioSource.Stop();
                audioSource.loop = loop;
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.Log("eff");
                audioSource.PlayOneShot(clip);
            }
        }

        public void PlayBGMInIdleChannel(Utils.Defines.SoundChannelTypes type, string key, bool loop, float volume = 1.0f, float pitch = 1.0f)
        {
            Utils.Defines.SoundChannels channelName = Utils.Defines.SoundChannels.UNKNOWN;
            int channelCnt = GetChannelCnt(type);

            int channelIdxStart = (int)type;
            for (int channelIdxMax = channelCnt + channelIdxStart, i = channelIdxStart; i < channelIdxMax; i++)
            {
                if (_audioSources[i].isPlaying == false)
                {
                    channelName = (Utils.Defines.SoundChannels)i;
                    break;
                }
            }

            Play(channelName, key, loop, volume, pitch);
        }

        public void Stop(Utils.Defines.SoundChannels channelName)
        {
            if (channelName >= Utils.Defines.SoundChannels.BGM_0 && channelName < Utils.Defines.SoundChannels.MAX_CHANNELS)
            {
                _audioSources[(int)channelName].Stop();
            }
        }

        public void StopAll()
        {
            foreach (var source in _audioSources)
            {
                source.Stop();
            }
        }

        public void StopAllOf(Utils.Defines.SoundChannelTypes type)
        {
            int channelIdxStart = (int)type;
            int channelCnt = GetChannelCnt(type);

            for (int channelIdxMax = channelCnt + channelIdxStart, i = channelIdxStart; i < channelIdxMax; i++)
            {
                _audioSources[i].Stop();
            }
        }

        public void Clear()
        {
            StopAll();
            _cachedAudioClips.Clear();
        }


        private AudioClip LoadAudioClip(string audioClipName)
        {
            AudioClip clip;
            if (_cachedAudioClips.TryGetValue(audioClipName, out clip))
            {
                return clip;
            }

            clip = Managers.Instance.ResourceManager.Load<AudioClip>(audioClipName);
            if (clip is not null)
            {
                _cachedAudioClips.Add(audioClipName, clip);
            }
            return clip;
        }

        public int GetChannelCnt(Utils.Defines.SoundChannelTypes type)
        {
            switch (type)
            {
                case Utils.Defines.SoundChannelTypes.BGM:
                    return (int)Utils.Defines.SoundChannelCounts.BGM_CNT;
                case Utils.Defines.SoundChannelTypes.SUBBGM:
                    return (int)Utils.Defines.SoundChannelCounts.SUBBGM_CNT;
                case Utils.Defines.SoundChannelTypes.EFFECT:
                    return (int)Utils.Defines.SoundChannelCounts.EFFECT_CNT;
            }
            return -1;
        }
    }
    
}