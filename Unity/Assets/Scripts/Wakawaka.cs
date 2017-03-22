using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakawaka : MonoBehaviour
{
    [SerializeField] float moveSpd;
    const int layer_level = 11;

    private void FixedUpdate()
    {
        //Update heading
        if (Input.GetButton("Up"))
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (Input.GetButton("Down"))
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else if (Input.GetButton("Left"))
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        else if (Input.GetButton("Right"))
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        if (!FacingWall())
        {
            transform.Translate(Vector3.forward * moveSpd * Time.deltaTime);

            //Animation

            //Wakawaka SFX
        }
    }

    //Raycasts right in front of PacMan to detect a wall.  Because Math, it will keep PacMan "on the grid" (center of the lanes) reasonably well
    private bool FacingWall()
    {
        return Physics.Raycast(transform.position, transform.forward, 0.5f, 1 << layer_level);
    }
}
