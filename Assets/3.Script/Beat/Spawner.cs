using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cubes;
    [SerializeField] private Transform[] Point;
    //∏ÆµÎ∞‘¿”
    //60/128
    public float bpm = 128f;
    [SerializeField] private float beat
    {
        get
        {
            return 60f / bpm;
        }
    }

    public float Timmer;

    private void Start()
    {
        Point = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Point[i] = transform.GetChild(i);
        }
    }

}
