using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class Sundial : MonoBehaviour
{
    [SerializeField, Range(-90f, 90f)] private float latitude;
    [SerializeField] private List<GameObject> scales;
    [SerializeField] private GameObject pole;

    [SerializeField] private Camera camera;

    public void OnValidate()
    {
        float latitudeRad = latitude * Mathf.Deg2Rad;
        
        int h = 6;
        foreach (var sit in scales)
        {
            float a = -Mathf.Atan(Mathf.Sin(latitudeRad) * Mathf.Tan(15 * h * Mathf.Deg2Rad)) * Mathf.Rad2Deg;
            Vector3 b = h == 18 ? new Vector3(90f, 0f, -a) : new Vector3(90f, 0f, a);
            sit.transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(b);

            h++;
        }

        pole.transform.rotation = Quaternion.Euler( 90f - Mathf.Abs( latitude), 0f, 0f);
    }
}
