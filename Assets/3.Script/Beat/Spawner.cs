using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cubes;
    [SerializeField] private Transform[] Point;

    private int poolSize = 10; // 풀 크기
    private List<GameObject> Red_pools = new List<GameObject>(); // 풀
    private List<GameObject> Blue_pools = new List<GameObject>(); // 풀

    //리듬게임
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
        } // 풀 초기화

        //Blue
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Blue_cude = Instantiate(Cubes[1]);
            Blue_cude.gameObject.SetActive(false);
            Blue_pools.Add(Blue_cude);
        } // 풀 초기화
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
                    if (!Red_pools[i].activeInHierarchy) // 하이라키 창에 pools[i]가 비활성화일 때
                    {
                        float y = Random.Range(0.5f, 1.5f);

                        Red_pools[i].transform.position = new Vector3(
                            Point[Random_index].transform.position.x,
                            y,
                            Point[Random_index].transform.position.z);
                        Red_pools[i].transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
                        Timmer -= beat;
                        Red_pools[i].SetActive(true); // 탄환 사용
                        break;
                    }
                }
                else if(Random_index.Equals(1))
                {
                    if (!Blue_pools[i].activeInHierarchy) // 하이라키 창에 pools[i]가 비활성화일 때
                    {
                        float y = Random.Range(0.5f, 1.5f);

                        Blue_pools[i].transform.position = new Vector3(
                            Point[Random_index].transform.position.x,
                            y,
                            Point[Random_index].transform.position.z);
                        Blue_pools[i].transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
                        Timmer -= beat;
                        Blue_pools[i].SetActive(true); // 탄환 사용
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
            //audio manger 생성하면 Play 넣어주세요. todo 12.14*/
        }
        Timmer += Time.deltaTime;
    }

}
