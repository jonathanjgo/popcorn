using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
	}

	public void Show(){
		GetComponent<MeshRenderer> ().enabled = true;

	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
