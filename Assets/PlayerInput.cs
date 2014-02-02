using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public const int READY = 0;
	public const int STARTING = 1;
	public const int RUNNING = 2;
	public const int DONE = 3;

	public float mainKnockback = 400f;
	public float knockback = 30f;
	// Update is called once per frame
	void Update () {
		DrawGui();
		if(Input.GetMouseButtonDown(0) && TimerScript.state == RUNNING)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, .2f);

			if(colliders.Length != 0)
			{
				if(colliders[0].GetComponent<Kernel>() != null)
				{


					Collider2D popCorn = colliders[0];
					popCorn.GetComponent<Kernel>().pop();
					Vector2 popCornCenter = popCorn.transform.position;

					popCorn.rigidbody2D.AddForce(Vector2.up * mainKnockback);

					colliders = Physics2D.OverlapCircleAll(popCornCenter, 1f);

					for(int i = 0; i < colliders.Length; i++)
					{
						if(colliders[i].GetComponent<Kernel>() != null)
						{
							Vector2 dif = (Vector2)colliders[i].transform.position - (Vector2)popCornCenter;

							if(colliders[i] != popCorn)
							{
								colliders[i].rigidbody2D.AddForce(dif.normalized * knockback / Mathf.Min(1f, dif.magnitude));

							}
						}
					}
				}
			}

		}
	}

	void DrawGui()
	{

	}
}
