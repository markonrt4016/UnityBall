using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPratiIgraca : MonoBehaviour {

public GameObject igrac;


    private Vector3 razlika;
    bool usao = true, kamera=true;
    // Use this for initialization
    void Start () 
    {
        razlika = transform.position - igrac.transform.position;
    }
    
    void LateUpdate () 
    {
        if (Input.GetKeyDown(KeyCode.T))
            kamera = !kamera;
        if (igrac.transform.position.x > 40)
            igrac.GetComponent<KretanjeIgraca>().jacinaskoka = 300f;
        else
            igrac.GetComponent<KretanjeIgraca>().jacinaskoka = 500f;

        if (kamera)
        {
            transform.position = igrac.transform.position + razlika;
            if (!usao)
            {
                this.transform.Rotate(-45, 0, 0);
                usao = true;
            }
        }
        else if (!kamera)
        {
            kameraIznad();
            if (usao)
            {
                this.transform.Rotate(45, 0, 0);
                usao = false;
            }
        }
    }


    void kameraIznad()
    {
        float PozicijaX = igrac.transform.position.x;
        float PozicijaZ = igrac.transform.position.z;
        float cameraOffset = 18.0f;
        this.transform.position = new Vector3(PozicijaX, cameraOffset, PozicijaZ);

    }
}