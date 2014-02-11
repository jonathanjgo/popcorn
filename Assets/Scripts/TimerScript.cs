using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public const int READY = 0;
	public const int STARTING = 1;
	public const int RUNNING = 2;
	public const int DONE = 3;

	public AudioClip sound;

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
			}
		}

		if (state == DONE)
		{
			ShowScore();
			time -= Time.deltaTime;
			if (time < -5f)
			{
				GetComponent<TextMesh>().text = "RESET" + "\n" + finalCount.ToString();	
				if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
				{	
					state = READY;
					time = 33.18f;
					popped = 0;
				}
			}
			else
			{
				GetComponent<TextMesh>().text = "DONE" + "\n" + finalCount.ToString();
			}
		}

	}

	void ShowScore(){
		GameObject s = GameObject.Find("ScoreBox");
		s.GetComponent<ScoreScreen>().Show ();

	}
}
