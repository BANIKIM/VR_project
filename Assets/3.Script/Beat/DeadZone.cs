using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    /*    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Cube"))
            {
                Destroy(collision.gameObject);
            }
        }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
