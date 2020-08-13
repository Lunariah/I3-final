using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform trans;
    public Transform chargeJauge;

    public float movementSpeed = 3;
    public float chargeSpeed = 1;

    private float charge = 0; // Between 0 and 1
    private float minCharge = 0.2f;


    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void Update()
    {
        // Movement
        trans.position += new Vector3(movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        // Charge
        if (Input.GetButton("Fire1"))
        {
            charge = Mathf.Min(charge + chargeSpeed * Time.deltaTime, 1);

        }
        else
        {
            if (Input.GetButtonUp("Fire1") && charge >= minCharge)
            {
                // Fire
                Debug.Log("Pew!");
            }
            charge = Mathf.Max(charge - 3 * Time.deltaTime, 0);
        }
        chargeJauge.localScale = new Vector3(charge, chargeJauge.localScale.y, chargeJauge.localScale.z);
    }
}
