using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIdleState : PlayerState {

    private readonly Player player;

    //constructor that set's this state's player
    public BirdIdleState(Player initPlayer)
    {
        player = initPlayer;
    }

    //use for initialization (called in NextState)
    public void InitializeState() {
        player.birdRigidbody.velocity = -player.transform.forward * player.birdMinSpeed;
	}
	
	// Update is called once per frame
    public void UpdateState() {
        //movement may want to be moved.
        if(Input.GetKey(KeyCode.E))
        {
            //if we're going under max speed
            if(player.birdSpeed < player.birdMaxSpeed)
            {
                //increase velocity in the direction we're facing times the time between frames times the bird's acceleration
                player.birdSpeed += player.birdAcceleration * Time.deltaTime;
            }
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            if (player.birdSpeed > player.birdMinSpeed)
            {
                //increase velocity in the direction we're facing times the time between frames times the bird's acceleration
                player.birdSpeed += -player.birdAcceleration * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            //lean left
            player.birdRigidbody.transform.Rotate(Vector3.forward, -player.birdTurnSpeed);
            if (player.birdTurnSpeed < player.birdTurnSpeedMax)
            {
                player.birdTurnSpeed += player.birdTurnAcceleration * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //lean right
            player.birdRigidbody.transform.Rotate(Vector3.forward, player.birdTurnSpeed);
            if (player.birdTurnSpeed < player.birdTurnSpeedMax)
            {
                player.birdTurnSpeed += player.birdTurnAcceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Ascend
            player.birdRigidbody.transform.Rotate(Vector3.right, player.birdTurnSpeed);
            if (player.birdTurnSpeed < player.birdTurnSpeedMax)
            {
                player.birdTurnSpeed += player.birdTurnAcceleration * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Descend
            player.birdRigidbody.transform.Rotate(Vector3.right, -player.birdTurnSpeed);
            if (player.birdTurnSpeed < player.birdTurnSpeedMax)
            {
                player.birdTurnSpeed += player.birdTurnAcceleration * Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            player.birdTurnSpeed = player.birdTurnSpeedDefault;
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            player.birdTurnSpeed = player.birdTurnSpeedDefault;
        }

        player.birdRigidbody.velocity = -player.birdSpeed * player.birdRigidbody.transform.forward;
    }

    //Use to go to the next state
    public void NextState(PlayerState nextState)
    {
        player.currentState = nextState;
        player.currentState.InitializeState();
    }
}
