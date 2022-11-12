using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    //private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private Interactable interactable;

    void Update() {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0) {
            interactable = colliders[0].GetComponent<Interactable>();

            if (interactable != null ) {
                //if (!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(interactable.interactionPrompt);

                if (Input.GetKeyDown(KeyCode.E)) interactable.Interact(this);
            }

        } else {
            if (interactable != null) interactable = null;
            //if (interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
 