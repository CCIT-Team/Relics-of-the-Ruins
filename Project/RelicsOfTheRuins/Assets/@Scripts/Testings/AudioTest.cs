using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    //반응형 오디오
    public bool loop = false;
    public Utils.Defines.SoundChannels c;
    public string lable;
    public string resourceName;

    [ContextMenu("test")]
    void pr()
    {
        Managers.Instance.SoundManager.PlayBGMInIdleChannel(Utils.Defines.SoundChannelTypes.BGM, resourceName, loop);
    }

    [ContextMenu("play")]
    void play()
    {
        Managers.Instance.SoundManager.Play(c
        , resourceName
        , loop);
    }

    [ContextMenu("Init")]
    void Init()
    {
        Managers.Instance.ResourceManager.LoadAsyncAllIn(lable, null);
    }
}
