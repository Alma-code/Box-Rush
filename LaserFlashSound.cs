using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFlashSound : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        SoundManager.PlaySound("Laser Activate Sound");
		SoundManager.PlaySound("ForceField Humming Sound");
		ScoreText_Pointy.PointyCount = ScoreText_Pointy.PointyCount - 15;
	}

}
