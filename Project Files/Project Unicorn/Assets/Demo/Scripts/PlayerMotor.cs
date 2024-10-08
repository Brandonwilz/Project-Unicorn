using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File: PlayerMotor.cs
 * Description: A demo implementation of the player's movement
 * Author: Bryan Sanchez (Tegomlee)
 * Date: 2024-09-20
 */

namespace ProjectUnicorn.Demo
{
    // This class is irrelevant to the actual project and is meant to showcase the system, not difinitive of the final vision.
    public class PlayerMotor : MonoBehaviour
    {
        public float speed = 15f;

        public void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(x, y);

            transform.Translate(speed * Time.deltaTime * movement);
        }
    }
}
