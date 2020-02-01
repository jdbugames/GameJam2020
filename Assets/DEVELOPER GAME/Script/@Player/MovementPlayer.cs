using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] internal Vector2 direction;
    [SerializeField] internal Vector3 movement;
    [SerializeField] internal Animator animatorPlayer;

    [Range(0,100)]
    [SerializeField] internal float speed;

    private void Awake()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CallMovementPlayer();
    }

    public void CallMovementPlayer()
    {
        float h = direction.x;
        float v = direction.y;

        movement = new Vector3();
        movement.Set(h, 0, v);

        transform.Translate(movement * speed * Time.deltaTime);

        if (animatorPlayer == null)
            return;

        animatorPlayer.SetFloat("vertical", direction.y);
        animatorPlayer.SetFloat("horizontal", direction.x);
    }
}
