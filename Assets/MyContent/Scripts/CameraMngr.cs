using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMngr : MonoBehaviour
{
    public Vector3 Velocity;
    public float JumpForce;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();


        //if (characterController.gameObject != null)
        //{
        //    FloatPrecisionMngr.Instance.Add(characterController.gameObject, characterController.gameObject.transform.position);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("EndlessRunning");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();
#endif
        }

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical"));

        Jump();
        characterController.Move(Vector3.Scale(Velocity, dir) * Time.deltaTime);
    }

    private void Jump()
    {
        if (characterController.isGrounded)
        {
            Velocity.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = JumpForce;
            }
        }

        Velocity.y += Physics.gravity.y * Time.deltaTime;
    }
}
