
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour {

    public Rigidbody rb;
	public playermovement Playermovement;
    public float force = 2000f;
    public float sidewaysforce = 1000f;
	public static bool isRestart;
	public static Vector3 Reached;
	public static int Reset_3;
	public GameObject GameOver;
	public GameObject LifeUi;
	public Renderer rend;
	public int time;
	
	
	void Start()
	{
	 time = 0;
	 rend = this.GetComponent<Renderer>();
	 rend.enabled = true;
	 Reached = CheckPoint.Reachedpoint;
	 isRestart = GameManager.isRestarting;
	 Reset_3 = Lives.Reset;
	 rb.useGravity = true;
	 if (isRestart == true)
	 {
		 transform.position = Reached;
		 isRestart = false;
		 timer();
	 }

	 else
	 {
	 	 transform.position = transform.position;
		 CheckPoint.Reachedpoint = transform.position;
		 timer();
	 }
	}
	
	void timer()
	{
	  time ++ ;
      if (time <= 7)
	  {
	  rend.enabled = !rend.enabled;
	  Invoke("timer",0.3f);
	  }

	  else
	  {
	  rend.enabled = true;
	  }
	}
	
	void FixedUpdate ()
    {
        rb.AddForce(0, 0, force*Time.deltaTime);

        if (Input.touchCount > 0)
        {
               
           Touch touch = Input.GetTouch(0);
           Vector2 touchPosition = touch.position;
            float touchPositionx = touch.position.x;
            float screenwidth = Screen.width;
            if (touchPositionx > screenwidth/2)
            {
                rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (touchPositionx < screenwidth/2)
            {
                rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
           
        }
        if (rb.position.y < -1)
        {
			if( Reset_3 < 3)
			{
			FindObjectOfType<GameManager>().EndGame();
			}
			
			else 
			{
			GameOver.SetActive(true);
			LifeUi.gameObject.SetActive(false);
			rb.useGravity = false;
			Playermovement.enabled = false;
			}
        }
    }
}
