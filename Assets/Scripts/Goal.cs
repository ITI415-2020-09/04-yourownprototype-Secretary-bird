using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject winText;
    void Start()
    {
        winText.SetActive(false);
    }
    static public bool goalMet = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Goal.goalMet = true;
            winText.SetActive(true);
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
