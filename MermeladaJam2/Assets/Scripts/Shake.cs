using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 1.5f;

    public float magnitude = 1.5f;

    private void OnEnable()
    {
        StartCoroutine(Movi());
    }
    IEnumerator Movi()
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f,1f)*magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x,y,originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition=originalPosition;
    }
}
