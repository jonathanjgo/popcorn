using UnityEngine;
using System.Collections;

public class Kernel : MonoBehaviour {

	public float startsize = 1.4f;
	public float popsize = 1f;

	// Use this for initialization
	void Start () {
		transform.localScale *= startsize;
	}


	// Update is called once per frame
	void Update () {
	
	}

	public AudioClip pop1 = new AudioClip();

	public void pop()
	{
		if(popped == false)
		{
			popped = true;
			collider2D.rigidbody2D.mass /= 2f;
			GetComponent<CircleCollider2D>().radius = .5f;
			collider2D.transform.localScale = collider2D.transform.localScale * 2;

			transform.localScale *= popsize;
	

			int popNum = Random.Range(0,3);
			if (popNum == 0)
			{
				GetComponent<SpriteRenderer>().sprite = poppedTexture4;
			}
			else if (popNum == 1)
			{
				GetComponent<SpriteRenderer>().sprite = poppedTexture;
			}
			else if (popNum == 2)
			{
				GetComponent<SpriteRenderer>().sprite = poppedTexture2;
			}
			else if (popNum == 3)
			{
				GetComponent<SpriteRenderer>().sprite = poppedTexture3;
			}

			audio.PlayOneShot(pop1);
			TimerScript.popped += 1;
		}
	}

	public Sprite poppedTexture;
	public Sprite poppedTexture2;
	public Sprite poppedTexture3;
	public Sprite poppedTexture4;

	private bool popped = false;
	public bool isPopped()
	{
		return popped;
	}
}
