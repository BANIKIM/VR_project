using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cubes;
    [SerializeField] private Transform[] Point;

    private int poolSize = 10; // Ǯ ũ��
    private List<GameObject> Red_pools = new List<GameObject>(); // Ǯ
    private List<GameObject> Blue_pools = new List<GameObject>(); // Ǯ

    //�������
    //60/128
    public float bpm = 95f;
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
        Timmer = 0f;
        //Red
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Red_cude = Instantiate(Cubes[0]);
            Red_cude.gameObject.SetActive(false);
            Red_pools.Add(Red_cude);
        } // Ǯ �ʱ�ȭ

        //Blue
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Blue_cude = Instantiate(Cubes[1]);
            Blue_cude.gameObject.SetActive(false);
            Blue_pools.Add(Blue_cude);
        } // Ǯ �ʱ�ȭ
    }

    private void Update()
    {
        int Random_index = Random.Range(0, 2);
        if (Timmer > beat)
        {
            for (int i = 0; i < poolSize; i++)
            {
                if(Random_index.Equals(0))
                {
                    if (!Red_pools[i].activeInHierarchy) // ���̶�Ű â�� pools[i]�� ��Ȱ��ȭ�� ��
                    {
                        float y = Random.Range(0.5f, 1.5f);

                        Red_pools[i].transform.position = new Vector3(
                            Point[Random_index].transform.position.x,
                            y,
                            Point[Random_index].transform.position.z);
                        Red_pools[i].transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
                        Timmer -= beat;
                        Red_pools[i].SetActive(true); // źȯ ���
                        break;
                    }
                }
                else if(Random_index.Equals(1))
                {
                    if (!Blue_pools[i].activeInHierarchy) // ���̶�Ű â�� pools[i]�� ��Ȱ��ȭ�� ��
                    {
                        float y = Random.Range(0.5f, 1.5f);

                        Blue_pools[i].transform.position = new Vector3(
                            Point[Random_index].transform.position.x,
                            y,
                            Point[Random_index].transform.position.z);
                        Blue_pools[i].transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
                        Timmer -= beat;
                        Blue_pools[i].SetActive(true); // źȯ ���
                        break;
                    }
                }

            }
          /*  int Random_index = Random.Range(0, 2);
            GameObject cube = Instantiate(Cubes[Random_index]);

            float y = Random.Range(0.5f, 1.5f);

            cube.transform.position = new Vector3(
                Point[Random_index].transform.position.x,
                y,
                Point[Random_index].transform.position.z);

            cube.transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
            Timmer -= beat;
            //audio manger �����ϸ� Play �־��ּ���. todo 12.14*/
        }
        Timmer += Time.deltaTime;
    }

}
