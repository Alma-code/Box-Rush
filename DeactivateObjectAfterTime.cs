using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjectAfterTime : MonoBehaviour
{	
	public float Time;
	public int Rtime;
	public int Timing;
	public int test;
	public Renderer rend;
	public static AudioSource audioS;
	public static bool ShieldOn;
    // Start is called before the first frame update
    
	void OnEnable()
    {
        test ++;
		Timing = 0;
		Rtime = 0;
		rend = this.GetComponent<Renderer>();
	 	rend.enabled = true;
		TimingFunction();
		timer();
		audioS = SoundManager.audioSrc;
		ShieldOn = true;
    }
	


    // Update is called once per frame
    void Update()
    {
        
    }
	
	void TimingFunction()
	{
		if (Timing >= 0 & Timing < Time)
		{
			Timing ++;
			Invoke("TimingFunction",1f);
		}
		
		else if (Timing >= Time)
		{
			audioS.Stop();
			Timing = 0;
			ShieldOn = false;
			this.gameObject.SetActive(false);
			
		}
	}
	
	void timer()
	{
	  Rtime ++ ;
      if (Rtime >= 7 & Rtime < 16)
	  {
	  rend.enabled = !rend.enabled;
	  Invoke("timer",0.3f);
	  }
	  
	  else if(Rtime >= 16)
	  {
	  rend.enabled = false;
	  Rtime = 0;
	  }

	  else
	  {
	  rend.enabled = true;
	  Invoke("timer",0.3f);
	  }
	}
}
