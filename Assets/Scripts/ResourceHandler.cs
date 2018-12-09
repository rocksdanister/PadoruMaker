using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourceHandler : MonoBehaviour {

    public GameObject bg; // background 
    public GameObject ch; // character
    public Animator anim;
    //public Animator bgAnim;
    public GameObject UIpanel;
    [HideInInspector] public static float chScale = 0.5f; // to restore size of sprite after reload
    [HideInInspector] public static float bgScale = 1.0f;
    [HideInInspector] public static float bgSpeed = 0.05f;
    [HideInInspector] public static Vector3 bgPos;
 

    [HideInInspector] public static bool isPlaying;
    AudioSource audioSource;
    float animationClipPos;
    Sprite[] arr = new Sprite[5]; // texture storing for later use.
	
    // Use this for initialization
	void Start () {
        
        //bgAnim.enabled = false;
        anim.enabled = false;
        audioSource = gameObject.GetComponent<AudioSource>();

        bg.transform.position = bgPos;
        bg.transform.localScale = new Vector3(bgScale, bgScale, 1);
        ch.transform.localScale = new Vector3(chScale, chScale, 1);

        StartCoroutine(ShowCurrentClipLength());
        LoadAssets();
    }

    public void PlayButton()
    {
        isPlaying = true;

        //gameObject.GetComponent<RecorderExample>();
        UIpanel.SetActive(false);
        audioSource.Play();
        anim.enabled = true;
        //bgAnim.enabled = true;

    }

    public void Reload() // full scene reloaded, including data files LoadAssets()
    {
        isPlaying = false; // since static
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadButton()
    {
        isPlaying = false; // since static
        chScale = 0.5f;
        bgScale = 1.0f;
        bgSpeed = 0.05f;
        bgPos = new Vector3(0, 0, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    enum SpriteNo
    {
        right = 1,
        left = 2,
        front = 3,
        back = 4
    }

    void LoadAssets()
    {
        //...loading sprites
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/Background/" + "bg.png",0));  // loading background
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/Character/" + "right.png",1)); // character sprites
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/Character/" + "left.png",2));
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/Character/" + "front.png",3));
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/Character/" + "back.png",4));

        //...loading audio
        StartCoroutine(Loader("file:///" + Application.dataPath + "/Resources/AudioClip/" + "audio.wav", 5));

    }

    // Use this for initialization
    IEnumerator Loader(string path, int i)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
            yield return null;
        if (i == 0)
        {
            arr[i] = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            bg.GetComponent<SpriteRenderer>().sprite = arr[i];
        }
        else if( i == 1)
        {
            arr[i] = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else if (i == 2)
        {
            arr[i] = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else if (i == 3)
        {
            arr[i] = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else if(i == 4)
        {
            arr[4] = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else
        {
            audioSource.clip = www.GetAudioClip();
        }


    }

    IEnumerator ShowCurrentClipLength() // have to be called end of frame
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            animationClipPos = anim.GetCurrentAnimatorStateInfo(0).normalizedTime * anim.GetCurrentAnimatorStateInfo(0).length * 24; // approx current animation playback frameno, 24 is fps
           // Debug.Log(animationClipPos);
        }

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isPlaying == true)
                Reload();
            else
                Application.Quit(); //exit
        }
    }

    private void LateUpdate()
    {
        ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.right];

        if(animationClipPos > 220)
        {
            Reload();
        }
        else if (animationClipPos > 156)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.right];
        }
        else if (animationClipPos > 152)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.back];
        }
        else if (animationClipPos > 148)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.left];
        }
        else if (animationClipPos > 144)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.front];
        }
        if (animationClipPos > 140)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.right];
        }
        else if (animationClipPos > 136)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.back];
        }
        else if (animationClipPos > 132)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.left];
        }
        else if (animationClipPos > 128)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.front];
        }
        else if (animationClipPos > 124)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.right];
        }
        else if (animationClipPos >120)
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.back];
        }
        else if (animationClipPos > 116 )
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.left];
        }
        else if(animationClipPos > 112 )
        {
            ch.GetComponent<SpriteRenderer>().sprite = arr[(int)SpriteNo.front];
        }
    }


}
