using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class OnSceneJoin : PunBehaviour {

	// Use this for initialization
	[PunRPC]
	void Start () {
        GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
        player.GetComponent<Player>().enabled = true;
    }
}
