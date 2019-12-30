using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(1f, 1f, 1f);
        }
    }
}
