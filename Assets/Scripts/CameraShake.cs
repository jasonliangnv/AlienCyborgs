using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Variable declarations
    public AnimationCurve curve;
    public float duration = 2f;
    public bool start;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }
    
    IEnumerator Shake()
    {
        yield return new WaitForSeconds(2f);
        
        startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPos + (Random.insideUnitSphere * Random.Range(0.0f, 0.5f));
            yield return null;
        }

        transform.position = startPos;
    }
}