using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public const int READY = 0;
	public const int STARTING = 1;
	public const int RUNNING = 2;
	public const int DONE = 3;

	public AudioClip sound;

	public float ENDSCORE;

	// Use this for initialization
	void Start () {

	}

	public static float time = 33.18f;


	public static int popped = 0;

	public int finalCount;
	public static int state = READY;

	void Update () {
		// ready to start the game
		if (state == READY)
		{
			GetComponent<TextMesh>().text = "READY";
			if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
			{
				audio.PlayOneShot(sound);
				state = STARTING;
			}
		}

		if (state == STARTING || state == RUNNING)
		{
			time -= Time.deltaTime;
			if (time < 30.5f)
			{
				GetComponent<TextMesh>().text = time.ToString("F0") + "\n" + popped.ToString();
				finalCount = popped;
				state = RUNNING;
			}

			if (time < 0)
			{
				state = DONE;
				CalculateScore();
			}
		}

		if (state == DONE)
		{
			ShowScore();
			time -= Time.deltaTime;
			if (time < -5f)
			{
				GetComponent<TextMesh>().text = "RESET" + "\n" + ENDSCORE.ToString();	
				if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
				{	
					state = READY;
					time = 33.18f;
					popped = 0;
					GameObject s = GameObject.Find("ScoreBox");

					s.GetComponent<ScoreScreen>().Hide ();
				}
			}
			else
			{
				GetComponent<TextMesh>().text = "DONE" + "\n" + ENDSCORE.ToString();
			}
		}

	}

	void CalculateScore(){
		foreach (GameObject k in GameObject.FindGameObjectsWithTag("Kernel")){
			if (k.GetComponent<Kernel>().outofbounds)
				ENDSCORE += 1;
			else
				ENDSCORE += 2;
		}
		print (ENDSCORE);
	}

	void ShowScore(){
		GameObject s = GameObject.Find("ScoreBox");
		s.GetComponent<ScoreScreen>().Show ();

	}
}
