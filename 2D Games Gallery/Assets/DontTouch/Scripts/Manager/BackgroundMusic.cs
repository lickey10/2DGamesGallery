using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

    public static BackgroundMusic instance;

    [SerializeField]
    private AudioClip[] clips;
    private AudioSource source;

    void Awake()
    {
        MakeSingleton();
    }

        void MakeSingleton()
    {
        //this state that if the gameobject to which this script is attached , if it is present in scene then destroy the new one , and if its not present
        //then create new 
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () 
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomMusic());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager_DontTouch.singleton.isGameOver && source.isPlaying == true)
        {
            source.Stop();
        }
        else if (!GameManager_DontTouch.singleton.isGameOver && source.isPlaying == false)
        {
            source.Play();
        }

    }

    IEnumerator PlayRandomMusic()
    {
        int i = Random.Range(0, clips.Length);
        int j = 0;

        while (i == j)
        {
            i = Random.Range(0, clips.Length);
        }

        j = i;

        source.clip = clips[i];
        source.Play();
        float time = 4 * source.clip.length;

        yield return new WaitForSeconds(time);
        source.Stop();
        StartCoroutine(PlayRandomMusic());
    }
}
