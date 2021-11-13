using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Tooltip("Max # of players/room")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;


    #region Private Serializable Fields

    #endregion
    #region Private Fields

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
    #region Public Methods

    public void Connect() {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
    #endregion

    #region MonoBehaviourPunCallbacks Callbacks
    public override void OnConnectedToMaster() {
        Debug.Log("OnConnectedToMaster called");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("OnDisconnected called b/c ${}", cause);
    }
    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("OnJoinRandomFailed() called, so one has been created.");
        PhotonNetwork.CreateRoom(null, new RoomOptions{ MaxPlayers = maxPlayersPerRoom });
    }
    public override void OnJoinedRoom() {
        Debug.Log("OnJoinedRoom() called. Client is in a room.");
        PhotonNetwork.Instantiate("Joe", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }

    #endregion


}
