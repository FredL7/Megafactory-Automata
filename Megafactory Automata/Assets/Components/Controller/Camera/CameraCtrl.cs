using UnityEngine;
// https://catlikecoding.com/unity/tutorials/hex-map/part-5/

public class CameraCtrl : MonoBehaviour {
  [SerializeField] private Transform swivel;
  [SerializeField] private Transform stick;

  private float zoom = 0.5f;
  private float stickMinZoom = -250f, stickMaxZoom = -45f;
  private float swivelMinZoom = 90f, swivelMaxZoom = 45f;
  private float moveSpeedMinZoom = 400f, moveSpeedMaxZoom = 100f;
  private float rotationSpeed = 180f;
  private float rotationAngle;

  private Vector2 xBounds = new Vector3(-100f, 100f);
  private Vector2 zBounds = new Vector3(-100f, 100f);

  void Awake() {
    AdjustZoom(0f);
    AdjustRotation(0f);
    AdjustPosition(0f, 0f);
  }

  void Update() {
    float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
    if (zoomDelta != 0f)
      AdjustZoom(zoomDelta);

    //?
    /*
    float rotationDelta = Input.GetAxis("Rotation");
    if (rotationDelta != 0f)
      AdjustRotation(rotationDelta);
    */

    float xDelta = Input.GetAxis("Horizontal");
    float yDelta = Input.GetAxis("Vertical");
    if (xDelta != 0f || yDelta != 0f)
      AdjustPosition(xDelta, yDelta);
  }

  private void AdjustZoom(float delta) {
    zoom = Mathf.Clamp01(zoom + delta);

    float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
    stick.localPosition = new Vector3(0f, 0f, distance);

    float angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
    swivel.localRotation = Quaternion.Euler(angle, 0f, 0f);
  }

  private void AdjustRotation(float delta) {
    rotationAngle += delta * rotationSpeed * Time.deltaTime;
    if (rotationAngle < 0f) rotationAngle += 360f;
    if (rotationAngle > 360f) rotationAngle -= 360f;
    transform.localRotation = Quaternion.Euler(0f, rotationAngle, 0f);
  }

  private void AdjustPosition(float xDelta, float yDelta) {
    Vector3 direction = transform.localRotation * new Vector3(xDelta, 0f, yDelta).normalized;
    float damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(yDelta));
    float distance = Mathf.Lerp(moveSpeedMinZoom, moveSpeedMaxZoom, zoom) * damping * Time.deltaTime;

    Vector3 position = transform.localPosition;
    position += direction * distance;
    position.x = Mathf.Clamp(position.x, xBounds.x, xBounds.y);
    position.z = Mathf.Clamp(position.z, zBounds.x, zBounds.y);
    transform.localPosition = position;
  }
}
