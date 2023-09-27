using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using WebXR;

public class PlayerSync : MonoBehaviour
{
    private PhotonView View;
    public GameObject  Cameras;
    // Start is called before the first frame update
    void Start()
    {
        View = GetComponent<PhotonView>();
        if (View.IsMine)
        {
            Cameras.SetActive(true);
            //GetComponent<WebXRManager>().enabled = true;
        }
        else
        {
            Cameras.SetActive(false);
        }
       
    }

   
}
