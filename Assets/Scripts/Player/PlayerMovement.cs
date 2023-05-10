using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movingSpeed;
    float horizontalAxis, verticalAxis;

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        FlipPlayerSide();
    }

    private void FlipPlayerSide(){
        if(horizontalAxis > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalAxis < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FixedUpdate()
    {
        Vector3 movingDir = new Vector3(horizontalAxis, verticalAxis, 0);

        transform.Translate(movingDir * movingSpeed * Time.deltaTime);
    }
}
