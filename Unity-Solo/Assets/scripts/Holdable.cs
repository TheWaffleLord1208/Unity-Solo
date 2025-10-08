using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Holdable : MonoBehaviour
{
    PlayerController player;

    void Start()
    {
   
    }

  
    public void equip(PlayerController player)
    {
        player.currentHoldable = this;

        transform.SetPositionAndRotation(player.weaponSlot.position, player.weaponSlot.rotation);
        transform.SetParent(player.weaponSlot);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().isTrigger = true;

        this.player = player;
    }

    public void unequip()
    {
        player.currentHoldable = null;

        transform.SetParent(null);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().isTrigger = false;

        this.player = null;
    }
}
