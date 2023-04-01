using UnityEngine;

public class LockCursor : MonoBehaviour
{
    [SerializeField]
    private CursorLockMode _lockMode = CursorLockMode.None;

    [SerializeField]
    private bool _visible = true;
    
    private void Awake()
    {
        Cursor.lockState = _lockMode;
        Cursor.visible = _visible;
    }
}