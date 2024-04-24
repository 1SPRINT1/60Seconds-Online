using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameSystem : MonoBehaviourPunCallbacks 
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _transform;
    public IsMine _IsMine; 

    private void Start()
    {
        PhotonNetwork.Instantiate(_player.name,_transform.position,Quaternion.identity);
        if (PhotonNetwork.InRoom)
        {
            Debug.Log("Игрок находится в комнате: " + PhotonNetwork.CurrentRoom.Name);
        }
        else
        {
            Debug.Log("Игрок не находится в комнате.");
        }

        foreach (Player _player in PhotonNetwork.PlayerList)
        {
            Debug.Log("Игрок в комнате: " + _player.UserId);
        }

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Новый игрок вошел в комнату: " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Игрок вышел из комнаты: " + otherPlayer.NickName);
    }
}
