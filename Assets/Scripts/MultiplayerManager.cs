using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI PlayerName;
    // private string NickName;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnected()
    {
        base.OnConnected();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("COnnected To Master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Disconnected");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Failed to Create Room" + message);
        NewRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("Failed To Jion Random Room");
        NewRoom();
    }

    public void NewRoom()
    {
        RoomOptions Rooms = new RoomOptions();
        Rooms.MaxPlayers = 0;

        PhotonNetwork.CreateRoom("Room1", Rooms = null, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("On Joined Room");


        //PhotonNetwork.LoadLevel("Forest");


        //PhotonNetwork.Instantiate("Player", SpwanPosition.position, Quaternion.identity);
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

    }


    //public void NickNameSet()
    //{
    //    var Name = FindObjectOfType<Keyboard>().text;
    //    print(Name.ToString());
    //    PhotonNetwork.NickName = Name.ToString();

    //    PhotonNetwork.JoinRandomRoom();

    //}
}