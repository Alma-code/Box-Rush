using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPcontroller : MonoBehaviour
{
   
   public static int RoguePoint;
   public static int ShieldPoint;
   public static int FlyerPoint;
   public GameObject RogueIAPpanel;
   public GameObject FlyerIAPpanel;
   public GameObject ShieldIAPpanel;
   
   public void AwardRoguePoint()
   {
   	RoguePoint = 5;
	Debug.Log("RoguePoint " + RoguePoint);
   }
   
   public void ConsumeRoguePoint()
   {
   	RoguePoint --;
	Debug.Log(RoguePoint);
   }
   
   public void AwardFlyerPoint()
   {
   	FlyerPoint = 4;
	Debug.Log("FlyerPoint " + FlyerPoint);
   }
   
   public void ConsumeFlyerPoint()
   {
   	FlyerPoint --;
	Debug.Log(FlyerPoint);
   }
   
     public void AwardShieldPoint()
   {
   	ShieldPoint = 3;
	Debug.Log("ShieldPoint " + ShieldPoint);
   }
   
   public void ConsumeShieldPoint()
   {
   	ShieldPoint --;
	Debug.Log(ShieldPoint);
   }
   
   public void Update()
	{
	 if (RoguePoint == 0)
	 {
		RogueIAPpanel.gameObject.SetActive(true);
	 }   
	 
	 if (FlyerPoint == 0)
	 {
		FlyerIAPpanel.gameObject.SetActive(true);
	 }    
	
	 if (ShieldPoint == 0)
	 {
		ShieldIAPpanel.gameObject.SetActive(true);
	 }    
	
	}
   
}  
