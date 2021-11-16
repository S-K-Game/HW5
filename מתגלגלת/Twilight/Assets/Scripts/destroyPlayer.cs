using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class destroyPlayer : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    //private int life = 3;

    
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == triggeringTag && enabled) {
            lifeController.life -= 1;
            Destroy(other.gameObject);
        }
        // if (life > 1 && other.tag == triggeringTag && enabled) {
        //     life --; 
        //     Destroy(other.gameObject);
        // }
        // else if(lives == 1 && other.tag == triggeringTag && enabled){
        //     Destroy(other.gameObject);
        //     Destroy(this.gameObject);
        // }
    }

}