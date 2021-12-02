using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

enum ConnectionMode
{
    JOIN_RANDOM,
    CREATE
};

public class Launcher : MonoBehaviourPunCallbacks
{

    [Tooltip("Max # of players/room")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;


    #region Private Serializable Fields

    #endregion
    #region Private Fields

    ConnectionMode connectionMode = ConnectionMode.JOIN_RANDOM;

    string gameVersion = "0.0.0";

    #endregion
    #region MonoBehaviour CallBacks

    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;

    }
    void Start() {
        // Connect();
    }

    #endregion

    #region Private Methods
    string GetRoomName() { 
        return GameObject.Find("RoomNameInput").GetComponent<InputField>().text;
    }
    
    #endregion

    #region Public Methods



    public void Connect() {
        connectionMode = ConnectionMode.JOIN_RANDOM;
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("JOINED RANDOM ROOM!");
            PhotonNetwork.JoinRoom(GetRoomName());
        }
        else {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public void CreateRoom() {
        connectionMode = ConnectionMode.CREATE;
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("CREATED NEW ROOM!");
            PhotonNetwork.CreateRoom(GetRoomName(), new RoomOptions { });
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks
    public override void OnConnectedToMaster() {
        Debug.Log("OnConnectedToMaster called");
        if (connectionMode == ConnectionMode.JOIN_RANDOM)
        {
            Debug.Log("JOINED RANDOM ROOM!");
            PhotonNetwork.JoinRoom(GetRoomName());
        }
        else if (connectionMode == ConnectionMode.CREATE)
        {
            Debug.Log("CREATED NEW ROOM!");
            Debug.Log(PhotonNetwork.IsConnectedAndReady);
            PhotonNetwork.CreateRoom(GetRoomName(), new RoomOptions { });
            //PhotonNetwork.JoinRoom(roomName);
        }
    }
    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("OnDisconnected called b/c ${}", cause);
    }
    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("OnJoinRandomFailed() called! No existing rooms exist.");
        //PhotonNetwork.CreateRoom(null, new RoomOptions{ MaxPlayers = maxPlayersPerRoom });
    }
    public override void OnJoinedRoom() {
        Debug.Log("OnJoinedRoom() called. Client is in a room.");
        GameObject.Find("JoinServerUI").SetActive(false);
        PhotonNetwork.Instantiate("AmogusPlayer", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }

    #endregion


}
