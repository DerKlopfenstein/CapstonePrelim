using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIdleState : PlayerState {

    private readonly Player player;

    //constructor that set's this state's player
    public ArcherIdleState(Player initPlayer)
    {
        player = initPlayer;
    }

    //use for initialization (called in NextState)
    public void InitializeState()
    {

    }

    // Update is called once per frame
    public void UpdateState() {
		
	}

    //use to go to the next state
    public void NextState(PlayerState nextState)
    {
        player.currentState = nextState;
        player.currentState.InitializeState();
    }
}
