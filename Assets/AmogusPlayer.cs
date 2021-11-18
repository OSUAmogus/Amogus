using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class AmogusPlayer : MonoBehaviour
{

    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void OnPhotonInstantiate(PhotonMessageInfo info) { 
        
    }
   

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            if (Input.GetKey("w"))
            {
                transform.position += new Vector3(0.0f, 0.01f, 0.0f);
            }
            if (Input.GetKey("a"))
            {
                transform.position += new Vector3(-0.01f, 0.0f, 0.0f);
            }
            if (Input.GetKey("s"))
            {
                transform.position += new Vector3(0.0f, -0.01f, 0.0f);
            }
            if (Input.GetKey("d"))
            {
                transform.position += new Vector3(0.01f, 0.0f, 0.0f);
            }

        }
    }
}
