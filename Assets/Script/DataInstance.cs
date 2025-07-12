using UnityEngine;

public class DataInstance : MonoBehaviour
{
    public static DataInstance Instance { get; private set; }

    // ===== ���L�������f�[�^ =====
    public float mouseSensitivity = 100f;
    public bool isMouseReversed = false;
    // ============================

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ŕێ�
        }
        else
        {
            Destroy(gameObject); // �d���C���X�^���X��h��
        }
    }
}
