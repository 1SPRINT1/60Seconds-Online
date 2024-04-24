using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class MenuManager : MonoBehaviourPunCallbacks
{
   public void CreateRoom()
   {
      RoomOptions roomOptions = new RoomOptions();
      roomOptions.MaxPlayers = 5;
      PhotonNetwork.CreateRoom("Room",roomOptions, TypedLobby.Default);
   }

   public void JoinRandomLobby()
   {
      PhotonNetwork.JoinRoom("Room");
   }

   public override void OnJoinedRoom()
   {
      PhotonNetwork.LoadLevel("Game"); 
      Debug.Log("Connected to Room");
   }
}
