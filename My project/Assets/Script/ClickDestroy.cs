
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDestroy : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue()
            );

            RaycastHit2D hit = Physics2D.Raycast(
                mousePosition,
                Vector2.zero
            );

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("クリック成功！");
                    Destroy(gameObject);
                }
            }
        }
    }
}
