using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeActionManager : MonoBehaviour {
	
    public AnimeAction currentAction = null;

    public void RunAction(AnimeAction action) {
        currentAction = action;

        this.Run();
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {   
        if(currentAction != null && currentAction.IsStarted()) {
            currentAction.Update(Time.deltaTime);
        }        
    }

    public void Run() {
        if(currentAction == null) {
            Debug.Log("AnimeActionManager: action isn't defined");
            return;
        }

        if(currentAction.IsStarted() == true) {
            Debug.Log("AnimeActionManager: action already started");
            return;
        }

        if(currentAction.IsDone() == true) {
            Debug.Log("AnimeActionManager: action has done");
            return;
        }

        currentAction.Start();
    }    
}

	
