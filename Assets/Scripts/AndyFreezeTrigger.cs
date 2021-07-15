using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyFreezeTrigger : MonoBehaviour
{
    AICharacterController aiController;
    CharacterController playerController;
    BoxCollider boxCollider;
    Rigidbody rigidbody;
    SpriteRenderer renderer;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name != "Andy" && col.gameObject.name != "Andi" && col.gameObject.name != "ground" && col.gameObject.tag != "freeze")
        {
            renderer = col.gameObject.GetComponent<SpriteRenderer>();
            if(renderer != null)
            {
                renderer.color = Color.blue;
            }

            playerController = col.gameObject.GetComponent<CharacterController>();

            if(col.gameObject.tag != "Player")
            {
                aiController = col.gameObject.GetComponent<AICharacterController>();
                if(aiController != null)
                {
                    aiController.enabled = false;
                }
            }

            boxCollider = col.gameObject.GetComponent<BoxCollider>();

            if(boxCollider != null)
            {
                boxCollider.enabled = false;
            }

            rigidbody = col.gameObject.GetComponent<Rigidbody>();

            if(rigidbody != null)
            {
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;
            }

            if(playerController != null)
            {
                playerController.canIMove = false;

                if(aiController != null)
                {
                    playerController.ResetAfterFrozen(playerController, boxCollider, renderer, aiController);
                }
                else
                {
                    playerController.ResetAfterFrozen(playerController, boxCollider, renderer);
                }
            }
        }
    }
}
