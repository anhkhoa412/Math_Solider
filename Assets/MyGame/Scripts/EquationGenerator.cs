using UnityEngine;
using TMPro;

public class EquationGenerator : MonoBehaviour
{
    private static EquationGenerator instance;
    public TMP_Text rightEquationText;
    public TMP_Text leftEquationText;
    public TMP_Text resultText;


    public int resultL;
    public int resultR;

    int result;

    public GameObject playerPrefab;
    //public Transform spawnPoint;

    public static EquationGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EquationGenerator>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("EquationGenerator_Instance");
                    instance = obj.AddComponent<EquationGenerator>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance of the EquationGenerator exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate instance
            return;
        }

        instance = this; // Set the instance to this object
        DontDestroyOnLoad(gameObject); // Keep the object when loading scenes
    }

    private void Start()
    {
 
        GenerateAndDisplayEquation();
    }

    void GenerateAndDisplayEquation()
    {
        int operand1R = Random.Range(1, 10);
        int operand2R = Random.Range(1, 10);
        int operand1L = Random.Range(1, 10);
        int operand2L = Random.Range(1, 10);
      //  char[] operators = { '+','-','*' };
        char[] operators = { '+', '-', '*', '/' };
        char randomOperator = operators[Random.Range(0, operators.Length)];

        string equation1 = $"{operand1R} {randomOperator} {operand2R}";
        string equation2 = $"{operand1L} {randomOperator} {operand2L}";

        resultR = EvaluateEquation(operand1R, operand2R, randomOperator);
        resultL = EvaluateEquation(operand1L, operand2L, randomOperator);

        Debug.Log($"Equation 1: {equation1}, Result: {resultR}");
        Debug.Log($"Equation 2: {equation2}, Result: {resultL}");

        int result = Random.Range(0, 2); // Generates either 0 or 1
        resultText.text = (result == 0) ? resultL.ToString() : resultR.ToString();
        rightEquationText.text = $"{equation1}";
        leftEquationText.text = $"{equation2}";
    }


  

    int EvaluateEquation(int operand1, int operand2, char op)
    {
        switch (op)
        {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                return (int)operand1 / operand2;
            default:
                return 0;
        }
    }
   



    // public void SpawnPlayers(float numPlayers)
    //{
    //    for (int i = 0; i < numPlayers; i++)
    //    {
    //       Vector3 spawnPosition = spawnPoint.position + Vector3.right * i * 2f; // Adjust position for spacing
    //       Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    //  }
    //}
}
