using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Camera playerCam;
    private Rigidbody rb;
    Ray jumpRay;

    float inputX;
    float inputY;

    Ray interactRay;
    RaycastHit interactHit;
    GameObject pickupObj;

    public float speed = 5f;
    public float jumpHeight = 10f;
    public float jumpRayDistance = 1.1f;
    public float interactDistance = 1f;

    public PlayerInput input;
    public Transform weaponSlot;
    public Weapon currentWeapon;
    public Holdable currentHoldable;

    public int health = 5;
    public int maxHealth = 5;

    public bool attacking = false;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        interactRay = new Ray(transform.position, transform.forward);
        jumpRay = new Ray(transform.position, -transform.up);
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = Camera.main;
        weaponSlot = playerCam.transform.GetChild(0);
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //Camera Handler

        Quaternion playerRotation = Quaternion.identity;
        playerRotation.y = playerCam.transform.rotation.y;
        playerRotation.w = playerCam.transform.rotation.w;
        transform.rotation = playerRotation;

        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;

        interactRay.origin = playerCam.transform.position;
        interactRay.direction = playerCam.transform.forward;

        if (Physics.Raycast(interactRay, out interactHit, interactDistance))
        {
            if (interactHit.collider.tag == "weapon")
            {
                pickupObj = interactHit.collider.gameObject;
            }
            if (interactHit.collider.tag == "holdable")
            {
                pickupObj = interactHit.collider.gameObject;
            }
        }
        else
            pickupObj = null;

        if (currentWeapon)
            if (currentWeapon.holdToAttack && attacking)
                currentWeapon.fire();

        //Movement System

        Vector3 tempMove = rb.linearVelocity;
        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + (tempMove.y * transform.up) + (tempMove.z * transform.right);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (currentWeapon)
        {
            if (currentWeapon.holdToAttack)
            {
                if (context.ReadValueAsButton())
                    attacking = true;
                else
                    attacking = false;
            }

            else if (context.ReadValueAsButton())
                currentWeapon.fire();
        }
    }
    // public void fireModeSwitch()
    //   {
    //    if (currentWeapon.weaponID == 1)
    //    {
    //        currentWeapon.GetComponent<Rifle>().changeFireMode();
    //   }
    //  }

    public void Reload()
    {
        if (currentWeapon)
            if (!currentWeapon.reloading)
                currentWeapon.reload();
    }
    public void Interact()
    {
        if (pickupObj)
        {
            if (pickupObj.tag == "weapon")
            {
                if (currentWeapon)
                    DropWeapon();
                    DropHoldable();

                pickupObj.GetComponent<Weapon>().equip(this);
            }
            if (pickupObj.tag == "holdable")
            {
                if (currentHoldable)
                    DropHoldable();
                    DropWeapon();

                pickupObj.GetComponent<Holdable>().equip(this);
            }
            pickupObj = null;
        }
        else
            Reload();

    }
    public void DropWeapon()
    {
        if (currentWeapon)
        {
            currentWeapon.GetComponent<Weapon>().unequip();
        }
    }

    public void DropHoldable()
    {
        if (currentHoldable)
        {
            currentHoldable.GetComponent<Holdable>().unequip();
        }
    }


    public void Move(InputAction.CallbackContext context)
    {
        Vector2 InputAxis = context.ReadValue<Vector2>();

        inputX = InputAxis.x;
        inputY = InputAxis.y;
    }
    public void Jump()
    {
        if (Physics.Raycast(jumpRay, jumpRayDistance))
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "killzone")
        {
            health = 0;
        }

        if ((other.tag == "health") && (health < maxHealth))
        {
            health++;
            other.gameObject.SetActive(false);
        }
        if (other.tag == "enemy")
        {
            health -= 2;
        }
        if (other.tag == "largeenemy")
        {
            health -= 3;
        }
        if (other.tag == "airenemy")
        {
            health -= 1;
        }
    }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hazard")
        {
            health--;
        }
    }
}
        