using UnityEngine;

public class characterRespawn : MonoBehaviour {
	// This is the height at which the character dies
	//[Tooltip("The point at which the character dies")] public float deathHeight = 0f;
	
	// If you assign a value here, the character will return to that checkpoint when the game is reset
	public Vector3 checkpointFlag; 

	private void Update() {
		// Here we want to check if the player is past the "deathHeight" on the y-axis (up and down)
		//if (transform.position.y < deathHeight) {
            //transform.position = checkpointFlag;
        
	}

	// TODO In order for this function to trigger, the player must collide with another GameObject that has a collider wiht "isTrigger" set to true
	private void OnTriggerEnter2D(Collider2D collision) {
		//If the player hits layer 10, update the checkpoint
		if (collision.gameObject.layer == 10) {
			checkpointFlag = collision.transform.position;
			Debug.Log("Checkpoint set for player at " + checkpointFlag);
		}
    }
}