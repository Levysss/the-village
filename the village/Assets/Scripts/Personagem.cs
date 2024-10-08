using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimento;
    public float speed = 10;
    private Animator animator;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void setMovimento(InputAction.CallbackContext value)
    {
        movimento = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat(HORIZONTAL, movimento.x);
        animator.SetFloat (VERTICAL, movimento.y);

        Vector3 movi = new Vector3(movimento.x, movimento.y, 0) * Time.fixedDeltaTime * speed;
        transform.Translate(movi);
    }
}
