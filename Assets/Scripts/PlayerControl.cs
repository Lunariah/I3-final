using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerControl : MonoBehaviour
{
    [Header("Object references")]
    [SerializeField] private Transform launchPoint;
    [SerializeField] private Transform chargeJauge;
    [SerializeField] private GameObject bullet;

    [Header("Tweaks")]
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private float chargeSpeed = 1;
    [SerializeField] private float power = 12.5f;
    [SerializeField] private float leftBound = 470;
    [SerializeField] private float rightBound = 1430;
    private const float minCharge = 0.2f; // Charge level required to shoot

    private float charge = 0;
    private float chargeUI = 0;


    private void Start()
    {
        if (launchPoint == null) { launchPoint = transform; }
    }

    private void Update()
    {
        // Movement
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < rightBound || Input.GetAxis("Horizontal") < 0 && transform.position.x > leftBound)
        {
            transform.position += new Vector3(movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        }

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
                GameObject new_bullet = Instantiate(bullet, launchPoint.position, Quaternion.identity);
                new_bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, charge * power), ForceMode2D.Impulse);
            }
            charge = 0;
        }
        // Have the jauge catch up to the actual charge value
        chargeUI = Mathf.Clamp(chargeUI - 3 * Time.deltaTime, charge, 1);
        chargeJauge.localScale = new Vector3(chargeUI, chargeJauge.localScale.y, chargeJauge.localScale.z);
    }
}