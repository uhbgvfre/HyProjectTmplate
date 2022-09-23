using UnityEngine;

public class CursorControl : MonoBehaviour
{
    public bool hideOnStart = true;
    public KeyCode toggleKey = KeyCode.Mouse1;

    private void Start()
    {
        if (hideOnStart) Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            Cursor.visible = !Cursor.visible;
        }
    }
}
