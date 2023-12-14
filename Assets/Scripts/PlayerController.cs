using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
   [SerializeField]private List<GameObject> allies= new List<GameObject>();
   private PhotonView photonView;
  [SerializeField] private GameObject tower;
   Vector2 towerpoint=new Vector2(7.68f,-1.89f);
    void Start()
    {
        photonView=GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
           if (PhotonNetwork.IsMasterClient)
           {
              towerpoint=new Vector2(-7.7f,-1.89f);
           }
            PhotonNetwork.Instantiate(tower.name,towerpoint,Quaternion.identity);
        }
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            Spawn();
        }
    }
    void Spawn()
    {
         if(Input.GetKeyDown(KeyCode.Mouse0))
         {
            Vector2 mouspos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newallies= PhotonNetwork.Instantiate(allies[0].name,new Vector2(mouspos.x,allies[0].transform.position.y),Quaternion.identity);
         }
    }
}
