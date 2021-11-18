using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoinRoom : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roomName;

    public void Connect()
    {
        Debug.Log(roomName.text);
    }
}
