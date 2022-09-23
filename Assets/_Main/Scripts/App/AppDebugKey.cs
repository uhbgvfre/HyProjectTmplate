using UnityEngine;

public class AppDebugKey : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("DebugKeyPressed: Alpha1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("DebugKeyPressed: Alpha2");
        }
    }
}
