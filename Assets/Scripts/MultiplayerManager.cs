using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private LeanFingerDown leanFingerDown;
    [SerializeField] private LeanSelectByFinger leanSelectByFinger;
    [SerializeField] private LeanDragTranslate[] leanDragTranslates;
    [SerializeField] private LeanTwistRotate[] leanTwistRotates;
    [SerializeField] private LeanPinchScale[] leanPinchScales;

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
        Rooms.EmptyRoomTtl = 0;

        PhotonNetwork.CreateRoom("Room1", Rooms = null, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("On Joined Room");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    public void ApplyCurrentCamera(Camera activeCamera)
    {
        leanFingerDown.ScreenDepth.Camera = activeCamera;
        leanSelectByFinger.ScreenQuery.Camera = activeCamera;
        foreach (var leanDragTranslate in leanDragTranslates)
        {
            leanDragTranslate.Camera = activeCamera;
        }

        foreach (var leanTwistRotate in leanTwistRotates)
        {
            leanTwistRotate.Camera = activeCamera;
        }

        foreach (var leanPinchScale in leanPinchScales)
        {
            leanPinchScale.Camera = activeCamera;
        }
    }
}