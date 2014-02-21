using UnityEngine;
using System.Collections;

public class OutDetect : MonoBehaviour {

	public GameObject ScoreBox;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Kernel") {
			print ("tagged");
			col.GetComponent<Kernel>().outofbounds = true;
		}
	}
}
