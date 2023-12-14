using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI playerCount;
    void Start()
    {
      InvokeRepeating(nameof(Call),1f,1f);
    }
    void Call()
     {
          playerCount.text="Oyuncu sayiis: "+PhotonNetwork.CountOfPlayers+"/ 20";
     }
     public void SearchGame()
     {
          ServerManager.Instance.joinrm();
     }

   
}
