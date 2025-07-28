using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float runSpeed = 2f;
    public float jumpSpeed = 3f;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    private Rigidbody2D rb2D;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private static Movimiento instance;

    void Awake()
    {
        // 🧠 Singleton para evitar duplicados
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // mantiene a Frog entre escenas
        }
        else
        {
            Destroy(gameObject); // destruye duplicados
        }
    }

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
    }

    void FixedUpdate()
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

