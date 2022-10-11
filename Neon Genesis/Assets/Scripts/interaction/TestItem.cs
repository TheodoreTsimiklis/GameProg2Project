using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.hasItem1) {
            Debug.Log("Touching Ball!");
            // Code for item buffs
        } else {
            Debug.Log("Cant touch Ball Without Item1!");
        }
        return false;
    }

}
