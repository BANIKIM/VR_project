using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] BGMs; 
    private AudioClip BGM;
    public bool Play_On = false;
    public bool Play_end = false;

    //½Ì±ÛÅæ ¼±¾ð
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Play_On && !Play_end)
        {
      
            BGM = BGMs[0];
            audioSource.clip = BGM;
            audioSource.PlayOneShot(BGM);
            Play_end = true;
            Debug.Log("Player");
            
            if (Play_On)
            {
                
                Play_On = false;
            }
        }
    }

}
