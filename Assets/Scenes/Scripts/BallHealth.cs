using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class BallHealth : MonoBehaviour
{

    public int MaxFallDistance = -10;
    private bool isRestarting = false;
    public AudioClip GameOverSound;
    private AudioSource GameOver;
    //string Mensaje = "Presiona R para reiniciar";
    //public static void LoadScene(Level01,SceneManagement.LoadSceneMode Single = LoadSceneMode.Single);


    // Update is called once per frame
    private void Start()
    {
        GameOver = GetComponent<AudioSource>();
        GameOverSound = GetComponent<AudioClip>();
    }
    void Update () {
		if (transform.position.y <= MaxFallDistance)
        {
            //Debug.Log("Probando");
            //#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            //          Application.LoadLevel("Level01");
            //#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            
            if (isRestarting == false)
            {
                
                StartCoroutine("RestartLevel");

            }


        }


	}

    IEnumerator RestartLevel()
    {
        Debug.Log("DENTRO DEL IENUMERATOR");
        isRestarting = true;
        //GetComponent<AudioSource>();
        //GameOverSound.play;
        GameOver.Play();
        yield return new WaitForSeconds(GameOver.clip.length);
        SceneManager.LoadScene("Level01");
        //private void OnGUI()
        //{
        //   GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Presione R para Reiniciar");

        //}

    }
}
