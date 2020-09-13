using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D myRigidBody;
    private Vector3 Change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector2.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();
        MoveCharacter();
    }

    private void UpdateAnimation()
    {
        if (Change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", Change.x);
            animator.SetFloat("MoveY", Change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + Change.normalized * Speed * Time.deltaTime);
    }
}
