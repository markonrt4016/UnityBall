using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Prelazak : MonoBehaviour {
    public GameObject rupa, igrac, most1,most2;
    int poeni;
    Rigidbody rb;
    BoxCollider bcd;
    public Text txtZadaci;
    bool proslo = false;
    public Material crveno;
    Renderer render;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bcd = GetComponent<BoxCollider>();
        render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        poeni = rupa.GetComponent<UnistavanjeLopte>().broj_unistenih;
        if (poeni == 3)
            render.material = crveno;
        if (igrac.transform.position.x > 10.30 && igrac.transform.position.x < 12.4 && igrac.transform.position.z < 6.7 && igrac.transform.position.z > 4.6 && poeni == 3 && !proslo && igrac.transform.position.y<0.9)
        {
            bcd.isTrigger = true;
            //txtZadaci.text = "Zadaci: 0/3";

            proslo = true;
        }

        if (this.transform.position.y <= -0.1)
        {
            bcd.isTrigger = false;
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            most1.GetComponent<KretanjeMosta>().brzina = 2.5f;
            most2.GetComponent<KretanjeMosta>().brzina = 2.5f;
        }

	}
}
