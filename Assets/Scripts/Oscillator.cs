using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 4f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == Mathf.Epsilon) {return;}

        float cycles = Time.time / period;  // időarányosan növekszik
        
        const float tau = Mathf.PI * 2;     // constans érték 2 * 3.14 = 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // a sinus hullám amplitudója -1 to 1
        movementFactor = (rawSinWave +1f) / 2;  // az amplitudó értékét 0-1-re konvertálja

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
