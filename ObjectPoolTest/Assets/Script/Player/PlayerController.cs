using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class PlayerData
{
    public PlayerData(string playerName, float health, float mana, float armor) 
    {
        this.playerName = playerName;
        this.health = health;
        this.mana = mana;
        this.armor = armor;
    }
    public string playerName;
    public float health;
    public float mana;
    public float armor;
}

//[ExecuteInEditMode]
public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 1.0f;

    [SerializeField]private GameObject CameraTarget = null;

    private Rigidbody playerRigidBody;

    private float movementX = 0.0f;
    private float movementZ = 0.0f;

    public List<Item> tracedObject;

    public LayerMask layerMask;

    private PlayerData playerData = new PlayerData("Ashen One", 100.0f, 50.0f, 10.0f);

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        SaveManager.LoadData<PlayerData>(ref playerData);
        Debug.Log(playerData.playerName);
        Debug.Log(playerData.health);
        Debug.Log(playerData.mana);
        Debug.Log(playerData.armor);
    }

    private void Update()
    {
        Movement();
        RotateYawOnCamera();
        RayCast();

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveManager.SaveData<PlayerData>(playerData);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveManager.LoadData<PlayerData>(ref playerData);
            Debug.Log(playerData.playerName);
            Debug.Log(playerData.health);
            Debug.Log(playerData.mana);
            Debug.Log(playerData.armor);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeData();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResetData();
        }
    }

    // Set player yaw rotation base on camera yaw rotation 
    private void RotateYawOnCamera()
    {
        transform.rotation = Quaternion.Euler(0.0f, CameraTarget.transform.eulerAngles.y, 0.0f);
    }

    // Player movement 
    private void Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime; // Move left right value
        movementZ = Input.GetAxisRaw("Vertical") * Time.deltaTime; // Move forward backward value

        Vector3 moveDirection = (transform.forward * movementZ + transform.right * movementX); // Movement direction 
        moveDirection.Normalize();

        playerRigidBody.velocity = moveDirection * moveSpeed; // Set velocity to move player
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteract interactInterface = other.gameObject.GetComponent<IInteract>();

        if (interactInterface == null) return;

        interactInterface.InteractEffect();
    }
    private void RayCast()
    {
        RaycastHit rayCastHit;

        if (Physics.Raycast(transform.position, transform.forward * 5.0f, out rayCastHit,layerMask))
        {
            Debug.DrawRay(transform.position, rayCastHit.point - transform.position, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 5.0f, Color.red);
        }
    }
    private void ChangeData()
    {
        playerData.playerName = "Ashen";
        playerData.health = 50.0f;
        playerData.mana = 20.0f;
        playerData.armor = 5.0f;
    }
    private void ResetData()
    {
        //"Ashen One", 100.0f, 50.0f, 10.0f
        playerData.playerName = "Ashen One";
        playerData.health = 100.0f;
        playerData.mana = 50.0f;
        playerData.armor = 10.0f;
    }
}
