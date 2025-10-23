


using System;

namespace Utils.Defines
{
    public enum SceneNames
    {
        Unknown = -1,
        Title = 1,
        Test = 60
    }

    public enum SoundChannels
    {
        BGM_0 = 0,
        BGM_1 = 1,
        SUBBGM_0 = 2,
        SUBBGM_1 = 3,
        EFFECT_0 = 4,
        EFFECT_1 = 5,
        MAX_CHANNELS = 6,
        UNKNOWN = -1
    }
    public enum SoundChannelTypes
    {
        BGM = SoundChannels.BGM_0,
        SUBBGM = SoundChannels.SUBBGM_0,
        EFFECT = SoundChannels.EFFECT_0,
        UNKNOWN = -1
    }
    public enum SoundChannelCounts
    {
        BGM_CNT = 2,
        SUBBGM_CNT = 2,
        EFFECT_CNT = 2,
        UNKNOWN = -1
    }

    public enum UIEventTypes
    {
        CLICK,
        PRESSED,
        POINTER_DOWN,
        POINTER_UP,
        DRAG,
        BEGIN_DRAG,
        END_DRAG,
        POINTER_ENTER,
        POINTER_EXIT

    }

}