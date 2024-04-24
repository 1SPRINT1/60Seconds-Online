using UnityEngine;
public class CameraController : MonoBehaviour
{
    public bool clickToMoveCamera = false;
    public bool canZoom = true;
    public float sensitivity = 5f;
    public Vector2 cameraLimit = new Vector2(-45, 40);
    public float touchAreaHeightPercentage = 0.5f;
    public bool isUsingJoystick = false; // Переменная, отслеживающая использование джойстика
    public Animator anim;

    float mouseX;
    float mouseY;
    float offsetDistanceY;

   [SerializeField] private Transform player;

    void Start()
    {
        offsetDistanceY = transform.position.y;

        if (!clickToMoveCamera)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        transform.position = player.position + new Vector3(0, offsetDistanceY, 0);

        if (anim.GetBool("run") == true) // Проверяем, использует ли игрок джойстик
        {
            return; // Если использует, прекращаем выполнение метода Update
        }

        if (canZoom && Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Camera.main.fieldOfView += deltaMagnitudeDiff * sensitivity * 0.01f;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20, 100);
        }

        if (clickToMoveCamera)
        {
            if (Input.touchCount != 1 || Input.GetTouch(0).phase != TouchPhase.Moved)
                return;

            Touch touch = Input.GetTouch(0);

            if (touch.position.y > Screen.height * touchAreaHeightPercentage)
            {
                mouseX += touch.deltaPosition.x * sensitivity * 0.1f;
                mouseY += touch.deltaPosition.y * sensitivity * 0.1f;

                mouseY = Mathf.Clamp(mouseY, cameraLimit.x, cameraLimit.y);

                transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
            }
        }
    }

}