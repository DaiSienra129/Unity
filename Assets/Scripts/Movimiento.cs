using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

using UnityEngine.SceneManagement;


public class Movimiento : MonoBehaviour
{
    public float runSpeed=2;
    public float jumpSpeed=3; //primer salto

    public float doubleJumpSpeed =2.5f;//para el doble salto

    private bool canDoubleJump; //saber cuando hacer el doble salto

    Rigidbody2D rd2D;

    public bool betterJump= false;

    public float fallMultipier = 0.5f;

    public float lowJumpMultipier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    [Obsolete]
     void Awake()
    {
        // ∴ evita duplicados
        if (FindObjectsOfType<Movimiento>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Unity llama a este método cada vez que se carga escena
    void OnEnable()           => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable()          => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // mueve al jugador al SpawnPoint de la nueva escena
        Transform sp = GameObject.FindWithTag("SpawnPoint")?.transform;
        if (sp != null) transform.position = sp.position;
    }
   
    void Start(){
        rd2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space")) //saltar
        {
            if (CheckGround.isGrounded)//comprobar si esta o no en el suelo
            {
                canDoubleJump = true;
                rd2D.linearVelocity = new Vector2(rd2D.linearVelocityX, jumpSpeed);

            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rd2D.linearVelocity = new Vector2(rd2D.linearVelocityX, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (CheckGround.isGrounded == false) //'cuando estemos en el suelo'
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        if (rd2D.linearVelocityY <0) {
             animator.SetBool("Falling", true);
         }  else
         
            if (rd2D.linearVelocityY > 0 && !Input.GetKey("space") )
            
        {
            animator.SetBool("Falling", false);
        } 
        
         
    }

    void FixedUpdate(){
        if(Input.GetKey("d")|| Input.GetKey("right") ){
           // rd2D.velocity = new Vector2(runSpeed,rd2D.linearVelocityY);
            rd2D.linearVelocity = new Vector2(runSpeed,rd2D.linearVelocityY);
            spriteRenderer.flipX = false; //para que mire a la derecha al moverse
            animator.SetBool("Run", true);
        }
        else if(Input.GetKey("a")|| Input.GetKey("left")){
             rd2D.linearVelocity = new Vector2(-runSpeed,rd2D.linearVelocityY);
              spriteRenderer.flipX = true; //para que mire a la izquierda al moverse
              animator.SetBool("Run", true);
        }
        else {
            rd2D.linearVelocity = new Vector2(0,rd2D.linearVelocityY);
            animator.SetBool("Run", false);
        }
     
        if(betterJump){
            if(rd2D.linearVelocityY<0){
                rd2D.linearVelocity += Vector2.up*Physics2D.gravity.y*(fallMultipier)*Time.deltaTime;
            }
            if(rd2D.linearVelocityY>0 && !Input.GetKey("space")){
            rd2D.linearVelocity += Vector2.up*Physics2D.gravity.y*(lowJumpMultipier)*Time.deltaTime;
            
            }
        }
    }
}

