using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KretanjeIgraca : MonoBehaviour {
    public float brzinakretanja = 50f;
    public float jacinaskoka = 200f;
    public GameObject ograda;
    public int poeni = 0;
    public Text txtPoeni, txtZadaci;
    Rigidbody rb;
    AudioSource skupljanje_poena;
    int zadaci_drugi = 0;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        skupljanje_poena = this.GetComponent<AudioSource>();
        txtPoeni.text = "Poeni: " + poeni.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        ObicnoKretanje();
        Skakanje();
	}

    void ObicnoKretanje()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(brzinakretanja * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(0, 0, brzinakretanja * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-brzinakretanja * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(0, 0, -brzinakretanja * Time.deltaTime);

        if (this.transform.position.y < -5)
            this.transform.position= new Vector3(0, 1, 0);
    }

    bool DodirZemlje()
    {
        bool SKOK = true;
        float razdaljina = 1f;
        Vector3 dir = new Vector3(0, -1, 0);

        if (Physics.Raycast(transform.position, dir, razdaljina))
            SKOK = true;
        else
            SKOK = false;
        return SKOK;
    }

    void Skakanje()
    {
        if (DodirZemlje() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jacinaskoka, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("poen"))
        {
            poeni++;
            txtPoeni.text = "Poeni: " + poeni.ToString();
            Destroy(other.gameObject);
            skupljanje_poena.Play();
        }

        if(other.CompareTag("kljuc"))
        {
            zadaci_drugi++;
            other.gameObject.SetActive(false);
            txtZadaci.text = "Zadaci: " + zadaci_drugi.ToString() + "/3";
            if (zadaci_drugi == 3)
                ograda.SetActive(false);
        }
    }

}
