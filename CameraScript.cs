using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public float Sensitivity;
    [SerializeField] Transform player;
    [SerializeField] Transform orientationOrigin;
    private float xRot = 0f, yRot = 0f;
    private PlayerInput playerInput;
    private InputAction mouseAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
        mouseAction = playerInput.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 1.0f, player.position.z);
        CameraRotation();
    }
    
    void CameraRotation()
    {
        Vector2 lookDirection = mouseAction.ReadValue<Vector2>();
        float deltaX = Sensitivity * Time.deltaTime * lookDirection.x;
        float deltaY = Sensitivity * Time.deltaTime * lookDirection.y;

        xRot += deltaX;

        yRot -= deltaY;
        yRot = Mathf.Clamp(yRot, -90.0f, 90.0f);

        player.transform.eulerAngles = new Vector3(0, xRot, 0);
        transform.eulerAngles = new Vector3(yRot, player.transform.eulerAngles.y, 0);
    }
}
