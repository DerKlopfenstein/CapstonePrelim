using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Player : PunBehaviour {

    [HideInInspector]
    public PlayerState currentState;

    /*********************************
     * ******** BIRD STUFF ***********
    **********************************/
    //for inspector cleanliness
    public bool BIRD_STUFF_BELOW;
    //Bird States
    [HideInInspector]
    public PlayerState birdIdleState;

    //Bird's Camera
    public GameObject birdCamera;

    //Bird's Rigidbody
    public Rigidbody birdRigidbody;

    //Bird Variables
    [HideInInspector] public float birdSpeed; //current speed of bird, public for state, don't touch
    public float birdMinSpeed; //min speed of bird, change in inspector
    public float birdMaxSpeed; //max speed of bird, change in inspector
    public float birdAcceleration; //bird's acceleration, change in inspector
    [HideInInspector] public float birdTurnSpeed; //rate of turning
    public float birdTurnSpeedDefault; //default rate of turning, change in inspector
    public float birdTurnSpeedMax; //Maximum rate of turning, change in inspector
    public float birdTurnAcceleration; // rate of change of the turn speed, change in inspector

    /*********************************
     * ******** ARCHER STUFF *********
    **********************************/
    //for inspector cleanliness
    public bool ARCHER_STUFF_BELOW;
    //Archer States
    [HideInInspector]
    public PlayerState archerIdleState;

    //Archer's Camera
    public GameObject archerCamera;



	// Use this for initialization
	void Start () {

        //activate correct camera for this player, birdCamera if bird and archerCamera if archer, for now just bird
        birdCamera.SetActive(true);

        //create our states for this player with 'this' player as the state's player
        birdIdleState = new BirdIdleState(this);
        archerIdleState = new ArcherIdleState(this);

        //initialize bird's speed
        birdSpeed = birdMinSpeed;

        //need to get if we're bird or archer and initialize currentState as proper state
        //for now just bird
        currentState = birdIdleState;
        //need to manually call initializeState the first time
        currentState.InitializeState();
	}
	
	// Update is called once per frame
	void Update () {
        //call current state's update, pushing all state specific calls to where we currently are
        currentState.UpdateState();
	}
}
