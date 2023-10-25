using UnityEngine;

public class ObjectDragRotation : MonoBehaviour
{
    [Tooltip("���콺 �̵��� ���� ������Ʈ ȸ�� �ӵ�")]
    [SerializeField] float rotationSpeed = 1000f;

    bool isDrag = false;
    float mX = 0, mY = 0;
    float inputMouseX = 0, inputMouseY = 0;

    // OnMouseDrag�� Updateó�� �����Ӹ��� Time.deltaTime ȣ����� ������ �� �����Ƿ�
    // �Ʒ� �κ��� update���� �����ϰ� �� ��.
    private void Update()
    {
        // �巡�� ������ ��, ������Ʈ�� ȸ���ϰ� �Ѵ�.
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

    // ���콺 �巡�� �� ���콺 �̵����� ����.
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
