using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour {
    static int staticID = 0;
    [SerializeField] private TMP_Text[] numbersText;

    [HideInInspector] public int CubeID;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
    [HideInInspector] public Rigidbody CubeRigidbody;
    [HideInInspector] public bool IsMainCube;

    private MeshRenderer cubeMeshRenderer;
    private bool canMove = true;
    private float moveSpeed = 5f; // Adjust the value according to your needs


    private void Awake() {
        CubeID = staticID++;
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        CubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color color) {
        CubeColor = color;
        cubeMeshRenderer.material.color = color;
    }

    public void SetNumber(int number) {
        CubeNumber = number;
        for (int i = 0; i < 6; i++) {
            numbersText[i].text = number.ToString();
        }
    }

    public void SetCubeMovement(bool canMove) {
        this.canMove = canMove;
    }

 private void Update() {
    if (!canMove) {
        // No movement allowed
        return;
    }

    // Example input handling for cube movement
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Calculate movement direction
    Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

    // Calculate movement amount based on moveSpeed and Time.deltaTime
    float moveAmount = moveSpeed * Time.deltaTime;

    // Move the cube based on the calculated movement
    transform.Translate(moveDirection * moveAmount);
}

}


