/*SoundSettings.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : Singleton<SoundSettings>
{

    [Header("Sound Variables")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;
    public Toggle muteSound;
}
