using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevencijaPada : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -5f)
        {
            this.transform.position = new Vector3(Random.Range(-1f, 5f), 2, Random.Range(-10f, 2f));
            rb.velocity = Vector3.zero;
        }
	}
}
