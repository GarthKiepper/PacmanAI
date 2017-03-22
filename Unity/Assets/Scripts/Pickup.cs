using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    enum itemType { pellet, superPellet, fruit, blueGhost };
    [SerializeField] itemType myType;
    int layer_pacman = 8;

    private void OnTriggerEnter(Collider other)
    {
        //Only let the player pick this item up
        if (other.gameObject.layer != layer_pacman)
            return;

        switch (myType)
        {
            case itemType.pellet:
                break;
            case itemType.superPellet:
                Debug.Log("SUPER MODE ACTIVATE");
                break;
            case itemType.fruit:
                break;
            case itemType.blueGhost:
                break;
        }

        GameObject.Destroy(this.gameObject);
    }
}
