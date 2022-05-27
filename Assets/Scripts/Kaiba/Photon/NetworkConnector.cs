using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConnector : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject canvas;


    [SerializeField]
    string mainSceneName;

    bool IsHost { get => TerunoManager.IsNetworkHost; set => TerunoManager.IsNetworkHost=value; }

    private void Start()
    {

    }

    private void EnableUI()
    {
        canvas.SetActive(false);
    }

    private void DisableUI()
    {
        canvas.SetActive(false);
    }

    public void ConnectAsVRPlayer()
    {
        IsHost = true;
        Connect();
    }

    public void ConnectAsTabletPlayer()
    {
        IsHost = false;
        Connect();
    }

    void Connect()
    {
        DisableUI();
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        EnableUI();
        Debug.Log(cause);
    }

    public override void OnErrorInfo(ErrorInfo errorInfo)
    {
        base.OnErrorInfo(errorInfo);
        EnableUI();
        Debug.Log(errorInfo.Info);
    }

    public override void OnJoinedLobby()
    {
        if (IsHost)
            PhotonNetwork.CreateRoom("Room", new RoomOptions() { MaxPlayers = 2 });
        else
            PhotonNetwork.JoinRoom("Room");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.IsMessageQueueRunning = false;
        PhotonNetwork.AutomaticallySyncScene = true;
        TerunoManager.isOffline = false;

        if (IsHost)
        {
            PhotonNetwork.LoadLevel(mainSceneName);

        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Create Room Failed! Error : " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("Join Room Failed! Error : " + message);
    }
}
