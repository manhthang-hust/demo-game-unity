using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider experienceSlider;
    public static HUDManager instance;
    private void Awake()
    {
        instance = this;
    }
    
}
