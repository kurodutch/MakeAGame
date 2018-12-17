using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float RotationSpeed = 100;
    public float JumpHeight = 8;
    private bool IsFalling = false;
    private bool aire = false;
    private Rigidbody rb;
    public Rigidbody rbejeX;
    public Transform tf;
    private int i = 0;
    private bool playOnce = true;
    private int TheHit;
    private AudioSource Hit01Source;
    private AudioSource Hit02Source;
    private AudioSource Hit03Source;
    public AudioClip Hit01Clip;
    public AudioClip Hit02Clip;
    public AudioClip Hit03Clip;
    private float disToGround;
    private Collider ColliderPrueba;
    //RotationSpeed = 100;

    private void Start()
    {
        //Sacando la sidtancia desde el centro al suelo.
        ColliderPrueba = GetComponent<Collider>();

        disToGround = ColliderPrueba.bounds.extents.y;
    }
    void Update () {
        //float RotationSpeed = 100;
        rb = GetComponent<Rigidbody>();
        rbejeX = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        // Rotación de la bola
        float Rotation;
        //float aux;
        Rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        Rotation *= Time.deltaTime;
        GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * Rotation);
        Hit01Source = GetComponent<AudioSource>();
        Hit02Source = GetComponent<AudioSource>();
        Hit03Source = GetComponent<AudioSource>();
        //hacer saltar la bola

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded()) // GetJeyDOwn = cuando se preta solamente 1 vez
        {

            rb.velocity = new Vector3(0, JumpHeight, 0);
            //aux = GetComponent<Rigidbody>().velocity.y;
            //Debug.Log("aux es" + aux);

            //Debug.Log("rb es "  + rb.velocity);
            //JumpHeight = aux;
            //Debug.Log("jump es " + JumpHeight);
            //IsFalling = true;
            aire = true;
        }
        
        //hacer que la bola salte hacia delante
        if (Input.GetKey(KeyCode.D)  && Input.GetKeyDown(KeyCode.W))
        {
            //rbejeX.velocity = new Vector3(1, 0, 0);
            while (i<=JumpHeight) {

                rbejeX.velocity = new Vector3 (-3, JumpHeight, 0);
                //Debug.Log("asdasdasd");
                i += 1;
            }
        }

        //IsFalling = true;
        //hacer que la bolta salte hacia atras
        if(Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.W))
        {
            //rbejeX.velocity = new Vector3(1, 0, 0);
            while (i <= JumpHeight)
            {

                rbejeX.velocity = new Vector3 (3, JumpHeight, 0);
                //Debug.Log("asdasdasd");
                i += 1;
            }
        }

        //hacer que se mueva la bola simplemente apretnado "D" cuando ya está en el aire.
        if (Input.GetKeyDown(KeyCode.W) && (aire ==true))
        {
            //rbejeX.velocity = new Vector3(1, 0, 0);
            Debug.Log("ENTRANDO EN MODULO");
            if (Input.GetKeyDown(KeyCode.D)) {
                Debug.Log("SE APRETO LA D");
                while (i <= JumpHeight)
                {

                    rbejeX.velocity = new Vector3(2, JumpHeight, 0);
                    Debug.Log("moverse en el AIRE");
                    i += 1;
                }

            }
            
        }
        if (aire ==true) {
            //Debug.Log("ESTOY EN EL AIRE");

        }
         PlayOnceTrue();

    }
    public bool  IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, disToGround);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (playOnce == true)
        {
            TheHit = Random.Range(0, 3);
            if (TheHit == 0)
            {
                StartCoroutine("PlayHit01");
            }
            else if (TheHit == 1)
             {
                StartCoroutine("PlayHit02");
             }
            else
            {
                StartCoroutine("PlayHit03");
            }

            playOnce = false;
        }
        IsFalling = false;
        i = 0;
    }

    private  void PlayOnceTrue()
    {
        //yield return new WaitForSeconds(0.2);
        playOnce = true;
    }


    IEnumerator PlayHit01()
    {
        //Hit02 = GetComponent<AudioClip>()
        Debug.Log("Dentro de PlayHit01");
        //Hit01Source.Play();
        yield return new WaitForSeconds(Hit01Source.clip.length);
        Hit01Source.clip = Hit01Clip;
        Hit01Source.Play();
    }

    IEnumerator PlayHit02() 
    {
        //Hit02 = GetComponent<AudioClip>()
        Debug.Log("Dentro de PlayHit02");
        //Hit02Source.Play();
        yield return new WaitForSeconds(Hit02Source.clip.length);
        Hit02Source.clip = Hit02Clip;
        Hit02Source.Play();
    }

    IEnumerator PlayHit03()
    {
        //Hit02 = GetComponent<AudioClip>()
        Debug.Log("Dentro de PlayHit03");
        //Hit03Source.Play();
        yield return new WaitForSeconds(Hit03Source.clip.length);
        Hit03Source.clip = Hit03Clip;
        Hit03Source.Play();
    }

}
