using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SetupGame : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject playercontroller;
     public override void OnJoinedRoom()
    {  
        Debug.Log("You joined the room!");
      PhotonNetwork.Instantiate(playercontroller.name,transform.position,Quaternion.identity);     
    }

}
