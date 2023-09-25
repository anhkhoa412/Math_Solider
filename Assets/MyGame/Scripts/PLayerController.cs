using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;
    public float rotationSpeed = 30f; // Maximum rotation angle in degrees
    private float xRot = 0f;
    int score = 0;
    public TMP_Text scoreText;

    Quaternion prior;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
      
    }

    private void Update()
    {
        // Move forward continuously
        Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
        controller.Move(moveDirection);

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");
       

        xRot += mouseX;
        xRot = Mathf.Clamp(xRot, -20f, 20f);
        transform.rotation = Quaternion.Euler(0, xRot, 0);
        // Rotate the player based on mouse input
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }

    public bool isCollide = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!isCollide)
        {
            if (other.CompareTag("LeftCube") || other.CompareTag("RightCube"))
            {
                isCollide = true;
                Debug.Log("Collided with " + other.tag + " Cube");

                int result = int.Parse(EquationGenerator.Instance.resultText.text);
                float resultL = EquationGenerator.Instance.resultL;
                float resultR = EquationGenerator.Instance.resultR;

                Debug.Log("Chosen Result: " + result + ", ResultL: " + resultL + ", ResultR: " + resultR);

                if ((other.CompareTag("LeftCube") && result == resultL) ||
                    (other.CompareTag("RightCube") && result == resultR))
                {
                    score += 1;
                    Debug.Log("Correct Equation Chosen - Score +1");
                }
                else
                {
                    score -= 5;
                    Debug.Log("Incorrect Equation Chosen - Score -1");
                }

                // Update the scoreText AFTER modifying the score
                scoreText.text = score.ToString();
            }
        }
        else if (other.CompareTag("CheckPoint"))
        {
            isCollide = false;
        }
    }


}

