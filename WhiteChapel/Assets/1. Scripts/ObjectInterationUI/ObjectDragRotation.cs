using UnityEngine;

public class ObjectDragRotation : MonoBehaviour
{
    [Tooltip("마우스 이동에 따른 오브젝트 회전 속도")]
    [SerializeField] float rotationSpeed = 1000f;

    bool isDrag = false;
    float mX = 0, mY = 0;
    float inputMouseX = 0, inputMouseY = 0;

    // OnMouseDrag가 Update처럼 프레임마다 Time.deltaTime 호출됨을 보장할 수 없으므로
    // 아래 부분은 update에서 동작하게 한 것.
    private void Update()
    {
        // 드래그 상태일 때, 오브젝트가 회전하게 한다.
        if (isDrag)
        {
            Debug.Log("Update");
            mX += inputMouseX * Time.deltaTime;
            mY += inputMouseY * Time.deltaTime;

            if (mX > 180)
                mX -= 360;
            else if (mX < -180)
                mX = 360 - mX;

            if (mY > 180)
                mY -= 360;
            else if (mY < -180)
                mY = 360 - mY;

            transform.rotation = Quaternion.Euler(mY, -mX, rotationSpeed);
        }
    }

    // 마우스 드래그 시 마우스 이동값을 저장.
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        inputMouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        inputMouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }
}
