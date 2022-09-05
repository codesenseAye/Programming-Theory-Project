using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ABSTRACTION
public abstract class Plane : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Color m_planeColor;

    public Color planeColor;

    private void Start()
    {
        SetColor(planeColor);
    }

    public virtual void Action() // can override if necessary
    {
        // check if they can do an action (not too frequent and enough ammo)
        if (!CanDoAction()) return;
        Ammo--;

        GameObject projectile = Instantiate(projectilePrefab); // shoot a bullet
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
    }

    [SerializeField] protected float speed = 10;
    [SerializeField] protected float turnSpeed = 10;

    private float? lastDidAction;
    protected float actionDelay = 5;

    protected bool CanDoAction()
    {
        if (m_ammo < 1)
        {
            Debug.LogWarning("Not enough ammo");
            return false;
        }
        
        float now = Time.realtimeSinceStartup;

        if (lastDidAction is null || (float)lastDidAction + actionDelay < now)
        {
            lastDidAction = now;
            return true;
        }

        Debug.LogWarning("Too frequently trying to use action");
        return false;
    }

    [SerializeField] protected const int DefaultAmmo = 30;
    private int m_ammo = DefaultAmmo;
    
    // ENCAPSULATION
    public int Ammo {
        get {
            return m_ammo;
        } 
        set { 
            if (m_ammo - value > 1)
            {
                Debug.LogError("Cannot take more than 1 ammo at a time");
                return;
            }

            m_ammo = value; 
        }
    }

    protected void SetColor(Color color)
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.color = color;

        foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>()) {
            Material childMat = renderer.material;
            childMat.color = color;
        }
    }

    // Update is called once per frame
    protected void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    protected void CheckAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Action();
        }

        float turn = Input.GetAxis("Turn");
        transform.Rotate(Vector3.up * (turn * turnSpeed * Time.deltaTime), Space.Self);

        float pitch = -Input.GetAxis("Pitch");
        transform.Rotate(Vector3.forward * (pitch * turnSpeed * Time.deltaTime), Space.Self);

        float roll = -Input.GetAxis("Roll");
        transform.Rotate(Vector3.right * (roll * turnSpeed * Time.deltaTime), Space.Self);
    }

    protected virtual void LateUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameObject menu = GameObject.Find("Menu");
            Destroy(gameObject);

            Menu.Restart();
        }
    }
}
