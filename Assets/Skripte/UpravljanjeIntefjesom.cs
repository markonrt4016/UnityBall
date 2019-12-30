using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UpravljanjeIntefjesom : MonoBehaviour {
    public GameObject panelPocetni, panelPauziranje, igrac;
    public GameObject panelZavrsetak, panelIgraAktivna;
    public Text zadaci, poeni;
    bool PAUZIRANO = false, odbrojavanje=false;
    AudioSource muzika_pozadina;
    public GameObject kamera;
    bool drugi_put_zadaci = false;
    int brojac = 0;
	// Use this for initialization

	void Start () {
        Time.timeScale = 0;
        muzika_pozadina = kamera.GetComponent<AudioSource>();
        panelIgraAktivna.SetActive(false);



	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pauza();
        if (zadaci.text == "Zadaci: 3/3"&&!drugi_put_zadaci)
        {
            odbrojavanje = true;
            zadaci.text = "Imate nove zadatke!";
            drugi_put_zadaci = true;
        }
        if (zadaci.text == "Zadaci: 3/3" && drugi_put_zadaci)
        {
            zadaci.text = "Nastavite pravo ka cilju!";
        }
        if(odbrojavanje)
            brojac++;
        if (brojac > 800)
        {
            brojac = 0;
            odbrojavanje = false;
            zadaci.text = "Zadaci: 0/3";
        }
        if (igrac.transform.position.x > 125f&&igrac.transform.position.y>2f)
            Kraj_Igre();
	}

    public void Pocetak_Igre()
    {
        panelPocetni.SetActive(false);
        panelIgraAktivna.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pauza()
    {
            PAUZIRANO = !PAUZIRANO;
            if (PAUZIRANO)
            {
                Time.timeScale = 0;
                panelPauziranje.SetActive(true);
                muzika_pozadina.Pause();
            }
            else if (!PAUZIRANO)
            {
                Time.timeScale = 1;
                panelPauziranje.SetActive(false);
                muzika_pozadina.UnPause();
            }
    }

    public void Kraj_Igre()
    {
        panelZavrsetak.SetActive(true);
        Time.timeScale = 0;
    }

    public void Izlaz()
    {
        Application.Quit();
    }

    public void Ponovi_igru()
    {
        SceneManager.LoadScene("lvl1");
    }
}
