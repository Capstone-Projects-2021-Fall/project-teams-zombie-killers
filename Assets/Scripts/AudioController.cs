using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    [SerializeField]
    private Profiles m_profiles;

    [SerializeField]
    private List<SliderX> m_VolumeSliders = new List<SliderX>();


    private void Awake()
    {

        if (m_profiles != null)
            m_profiles.SetProfile(m_profiles);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.GetAudioLevels();
    }

    public void ApplyChanges()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.SaveAudioLevels();
    }

    public void CancelChanges()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.GetAudioLevels();


        for (int i = 0; i < m_VolumeSliders.Count; i++)
        {
            m_VolumeSliders[i].ResetSliderValue();
        }
    }
}
