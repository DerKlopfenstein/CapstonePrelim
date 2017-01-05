using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState {

    // Use for activation of state (called in NextState)
    void InitializeState();

    // Update is called once per frame
    void UpdateState();

    // Go to our next state
    void NextState(PlayerState nextState);
}
