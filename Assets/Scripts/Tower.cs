using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private PhotonView photonView;
    void Start()
    {
        photonView=GetComponent<PhotonView>();
        if(!photonView.IsMine)
        gameObject.tag="enemytower";
       
    }

}
