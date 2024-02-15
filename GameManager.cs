
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gamehasended = false;
    public float restartdelay = 1f;
    public GameObject completelevelUI;
    public GameObject[] DUI;	
	public GameObject Player;
	public Playermovement_RogueMode RogueScript;
	public Flyer_Cube FlyScript;
	public static bool isRestarting;
	public static int LastLevelReached;
	public Button Laser;
	public Button Bubbles;
	public static bool IsGameOver;

	void Start () {
		
		if ( SceneManager.GetActiveScene().buildIndex > 0)
		{
			if( SceneManager.GetActiveScene().buildIndex > LastLevelReached)
				{
				LastLevelReached = SceneManager.GetActiveScene().buildIndex;
				Debug.Log(LastLevelReached);
				PlayerPrefs.SetInt("LastLevelReached",LastLevelReached);
				}
		}
		
		NoRepeat.Backtomenu = true;

		}
	
	public void completelevel()
    {
        completelevelUI.SetActive(true);
		isRestarting = false;
    }
    public void EndGame()
    {
        if (gamehasended == false)
        {
            gamehasended = true;
            Invoke("Restart", restartdelay);
        }
    }
    public void Restart()
     {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	  isRestarting = true;
     }
    
	public void RestartCoins()
     {
	  ScoreText_Coin.CoinCount = ScoreText_Coin.CoinCount - 50;
	  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	  isRestarting = true;
	  Lives.Reset = 0;
	  Time.timeScale = 1f;
     }
	
	public void RestartPointy()
     {
	  ScoreText_Pointy.PointyCount = ScoreText_Pointy.PointyCount - 20;
	  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	  isRestarting = true;
	  Lives.Reset = 0;
	  Time.timeScale = 1f;
     }
	 
	 public void TimeScalePause()
	 {
	 	Time.timeScale = 0f;
	 }
	 
	 public void TimeScaleContinue()
	 {
	 	Time.timeScale = 1f;
	 }

	public void CoinsBuyCurrency()
	{
	 ScoreText_Coin.CoinCount += 75;
	}

	public void PointyBuyCurrency()
	{
	 ScoreText_Pointy.PointyCount += 20;
	}


	 public void GameOverRestart_ResetLives()
	 {
	 	 Lives.Reset = 0;
		 IsGameOver = true;
	 }

	public void DeactivateUI()
	{
		DUI = GameObject.FindGameObjectsWithTag("DUI");
		foreach (GameObject d in DUI)
		{
		  d.SetActive(false);
		}

	}

	public void Update()
	{
		int CoinValue = ScoreText_Coin.CoinCount;
		int PointyValue = ScoreText_Pointy.PointyCount;
		if (CoinValue < 50 & PointyValue < 15)
		{
			
			Laser.interactable = false;
			Bubbles.interactable = false;
		}

		else if (CoinValue >= 50 & PointyValue < 15)
		{
			 Debug.Log(CoinValue);
			 Bubbles.interactable = true;			
			 Laser.interactable = false;
		}

		else if( CoinValue < 50 & PointyValue >= 15)
		{
			Bubbles.interactable = false;
			Laser.interactable = true;
		
		}

		else{

			Bubbles.interactable = true;
			Laser.interactable = true;
		}
	}


	public void ActivateRogue()
	{
		RogueScript.enabled = true;
	}

	public void ActivateFlyer()
	{
		FlyScript.enabled = true;
	}
}