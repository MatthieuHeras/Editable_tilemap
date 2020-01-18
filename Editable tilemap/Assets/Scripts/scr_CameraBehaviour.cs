using UnityEngine;

public class scr_CameraBehaviour : MonoBehaviour
{

    public Transform target;
    public Rigidbody2D rb;

    public float depth = -10f;
    public float horizontalAnticipation = 1f;
    public float verticalAnticipation = 1f;
    public float smoothness = 1f;
    public float mouseInfluence = 2f;
    public float horizontalLook = 1f;
    public float verticalLook = 1f;
    public float velocityReductor = 10f;

    private Camera mainCamera;
    private Vector3 movementAnticipation = Vector3.zero;
    private Vector3 mousePosition = Vector3.zero;
    private Vector3 pointToLookAt = Vector3.zero;
    private Vector2 halfScreenSize = Vector2.zero;

    // Start is called before the first frame update
    private void Start()
    {
        // set the camera position to the target position (except for Z axis because of 2D)
        transform.position = new Vector3(target.position.x, target.position.y, depth);
        mainCamera = GetComponent<Camera>();
        halfScreenSize.x = Screen.width / 2;
        halfScreenSize.y = Screen.height / 2;
    }
    
    // Update is called once per frame
    private void Update()
    {
        mousePosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x - halfScreenSize.x, Input.mousePosition.y - halfScreenSize.y, 0));
        movementAnticipation = new Vector3((rb.velocity.x / velocityReductor) * horizontalAnticipation, (rb.velocity.y / velocityReductor) * verticalAnticipation, 0);

        if (Input.GetKey(KeyCode.A) || movementAnticipation.x < -horizontalLook)
            movementAnticipation.x = -horizontalLook;
        else if (Input.GetKey(KeyCode.E) || movementAnticipation.x > horizontalLook)
            movementAnticipation.x = horizontalLook;
        if (Input.GetKey(KeyCode.Z) || movementAnticipation.y > verticalLook)
            movementAnticipation.y = verticalLook;
        else if (Input.GetKey(KeyCode.S) || movementAnticipation.y < -verticalLook)
            movementAnticipation.y = -verticalLook;


        pointToLookAt = new Vector3(transform.position.x, transform.position.y, depth)
                            + smoothness *
                            (new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0)
                            + movementAnticipation
                            + mouseInfluence * mousePosition);

        transform.position = pointToLookAt;
    }
}
