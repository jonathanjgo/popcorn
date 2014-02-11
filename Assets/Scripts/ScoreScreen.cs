using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

	public float CamPanAmount = .4f;
	public float CamPanSpeed = .1f;
	float pannum = 0f;
	bool pan = false;
	float camstartX = 0f;

	// Use this for initialization
	void Start () {
		camstartX = Camera.main.transform.position.x;
		GetComponent<MeshRenderer> ().enabled = false;
	}

	public void Show(){
		GetComponent<MeshRenderer> ().enabled = true;
		pan = true;

	}
	public void Hide(){
		GetComponent<MeshRenderer> ().enabled = false;
		pan = false;
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("k"))
			Show ();

		if (pan) {
			float t = ((CamPanAmount - pannum)*CamPanSpeed);
			pannum = pannum + (t * Time.deltaTime * 60f);

			Camera.main.transform.position = new Vector3(camstartX + pannum,Camera.main.transform.position.y,Camera.main.transform.position.z);
		}
		else{
			float t = ((0 - pannum)*CamPanSpeed);
			pannum = pannum + (t * Time.deltaTime * 60f);
			
			Camera.main.transform.position = new Vector3(camstartX + pannum,Camera.main.transform.position.y,Camera.main.transform.position.z);
		}
	}
}
