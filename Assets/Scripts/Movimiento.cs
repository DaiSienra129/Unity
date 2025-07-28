using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

using UnityEngine.SceneManagement;

/*
--------------------------------------------------------------------
**Controlador del movimiento del personaje principal**

Controlar el movimiento horizontal, saltos simples y dobles, animaciones, 
mejoras en la física de salto, y garantizar que Frog no se duplique entre
escenas. También posiciona al personaje en el punto de aparición ("SpawnPoint") de cada nivel.
--------------------------------------------------------------------
*/


public class Movimiento : MonoBehaviour
{
    public float runSpeed = 2f; //Velocidad al correr
    public float jumpSpeed = 3f; //Fuerza del salto normal
    public float doubleJumpSpeed = 2.5f; //Fuerza del salto doble
    private bool canDoubleJump; //variable

    private Rigidbody2D rb2D; //variable

    public bool betterJump = false; //Activa la física de salto mejorada
    public float fallMultiplier = 0.5f; //Multiplica la gravedad al caer (más rápida la caída)
    public float lowJumpMultiplier = 1f; //Aumenta gravedad si se suelta la tecla en medio del salto

    public SpriteRenderer spriteRenderer; //Controla orientación del personaje (mirar a izquierda/derecha)
    public Animator animator;

    private static Movimiento instance; //Controla animaciones (saltar, correr, caer, etc.)


//Este evita que se dupliquen Frogs al cambiar de escena.
    void Awake()
    {
        // Singleton para evitar duplicados
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad hace que el objeto persista incluso al cargar otra escena.
            DontDestroyOnLoad(gameObject); // mantiene a Frog entre escenas
        }
        else
        {
            Destroy(gameObject); // destruye duplicados
        }
    }


//Detecta cuando se carga una nueva escena y reposiciona a Frog en el punto de aparición (SpawnPoint).
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Transform sp = GameObject.FindWithTag("SpawnPoint")?.transform;
        if (sp != null) transform.position = sp.position;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();


        GameObject spawn = GameObject.FindWithTag("SpawnPoint");
        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
        else
        {
            Debug.LogWarning("No se encontró el SpawnPoint con tag asignado.");
        }


    }

    void Update()
    {
        //saltos
        //Si está en el suelo → puede saltar y activar el doble salto.
        //Si está en el aire y se presiona espacio por primera vez → activa el doble salto.
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            }
            else if (Input.GetKeyDown("space") && canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
        }

        // Animaciones de salto
        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.linearVelocity.y < 0)
            animator.SetBool("Falling", true);
        else if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            animator.SetBool("Falling", false);
        //Controla los estados de animación: salto, doble salto, caída.
    }

    void FixedUpdate() //Movimiento físico
    {
        // Movimiento horizontal
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("Run", false);
        }
        //Movimiento horizontal según teclas A/D o ←/→.

        // Mejora de salto
        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            else if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }
    }
}

