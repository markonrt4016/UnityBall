using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeMosta : MonoBehaviour {
    public float PozicijaA, PozicijaB;
    public float brzina;
    int smer = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x <= PozicijaA)
            smer = 1;
        if (this.transform.position.x >= PozicijaB)
            smer = -1;
        this.transform.Translate(smer * brzina * Time.deltaTime, 0, 0);
	}
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour {
//    public float PozicijaA, PozicijaB;
//    public float brzina;
//    int smer = 1;
//    // Update is called once per frame
//    void Update () {
//        if (this.transform.position.x <= PozicijaA)
//            smer = 1;
//        if(this.transform.position.x>=PozicijaB)
//            smer = -1;
//        this.transform.Translate(smer*brzina * Time.deltaTime, 0, 0);
//    }
//}

