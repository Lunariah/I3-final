using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Object references")]
    public Transform chargeJauge;
    public GameObject bullet;
    private Transform trans;

    [Header("Tweaks")]
    public float movementSpeed = 3;
    public float chargeSpeed = 1;
    public float power = 12.5f;

    private float charge = 0; // Between 0 and 1
    private float chargeUI = 0;
    private float minCharge = 0.2f;


    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void Update()
    {
        // Movement
        trans.position += new Vector3(movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        // Load & Fire
        if (Input.GetButton("Fire1"))
        {
            charge = Mathf.Min(charge + chargeSpeed * Time.deltaTime, 1);
        }
        else
        {
            if (Input.GetButtonUp("Fire1") && charge >= minCharge)
            {
                // Fire
                Instantiate(bullet, GetComponent<Transform>().position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(0, charge * power), ForceMode2D.Impulse);
            }
            charge = 0;
        }
        // Have the jauge catch up to the actual charge value
        chargeUI = Mathf.Clamp(chargeUI - 3 * Time.deltaTime, charge, 1);
        chargeJauge.localScale = new Vector3(chargeUI, chargeJauge.localScale.y, chargeJauge.localScale.z);
    }
}
