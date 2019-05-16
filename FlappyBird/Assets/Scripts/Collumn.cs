using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collumn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.BirdScored();
        }
    }
}
