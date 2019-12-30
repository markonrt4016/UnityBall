using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnistavanjeLopte : MonoBehaviour {
	// Use this for initialization
    public int broj_unistenih=0;
    public Text skor;
    public GameObject eksplozioni_prefab;
    AudioSource eksplozija;
    ParticleSystem ps;
	void Start () {
        prikaz_skora();
        eksplozija = GetComponent<AudioSource>();
        ps = eksplozioni_prefab.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject lopta;
        if (other.CompareTag("Bingo"))
        {
            Destroy(other);
            lopta = other.gameObject;
            lopta.SetActive(false);
            broj_unistenih++;
            prikaz_skora();
            eksplozija.Play();
            ps.Play();
        }
    }
    void prikaz_skora()
    {
        skor.text = "Zadaci: " + broj_unistenih.ToString() + "/3";
    }
}
