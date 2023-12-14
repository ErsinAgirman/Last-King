using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;



public class ServerManager : MonoBehaviourPunCallbacks
{
    public static ServerManager Instance;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Awake() 
   {
     if (Instance==null)
     {
        Instance=this;
        DontDestroyOnLoad(gameObject);

     }
     else
     {
        Destroy(gameObject);
     }
   }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Photon'a bağlandı.");

        PhotonNetwork.NickName = "PON" + Random.Range(1000, 9999);

    }
    public void joinrm()
    {
          SceneManager.LoadScene("GameScene");
      PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Hiçbir oda bulunamadı, yeni bir oda oluşturuluyor.");

        string roomName = "Oda" + Random.Range(1000, 9999);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2; 
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya katıldınız: " + PhotonNetwork.CurrentRoom.Name);
    }
   
}
