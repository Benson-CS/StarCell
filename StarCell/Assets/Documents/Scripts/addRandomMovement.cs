using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Made by dnglchlk
public class addRandomMovement : MonoBehaviour
{
    Renderer m_Renderer;
    private Control_Dominate sending;
    private float minSpinSpeed;
    private float maxSpinSpeed;
    private float spinSpeed;
    [Range(0.01f, 1f)] public float updateSpeed;

    void Awake() // why not start, this isn't a pellet, it will always run
    {
        // a bunch of stupid hooking in that is unnessecary and pains me
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        minSpinSpeed = sending.minSpinSpeed;
        maxSpinSpeed = sending.maxSpinSpeed;
        spinSpeed = sending.spinSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        Rigidbody rb = GetComponent<Rigidbody>();
        InvokeRepeating("AsteroidUpdate", 0.0f, updateSpeed);
    }


    void AsteroidUpdate()
    {
        if (m_Renderer.isVisible)
        {
            transform.Rotate(Vector3.up, spinSpeed);
        }

    }
}
