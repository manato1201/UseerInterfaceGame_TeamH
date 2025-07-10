using UnityEngine;

public class DataInstance : MonoBehaviour
{
    public static DataInstance Instance { get; private set; }

    // ===== 共有したいデータ =====
    public float mouseSensitivity = 100f;
    public bool isMouseReversed = false;
    // ============================

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいで保持
        }
        else
        {
            Destroy(gameObject); // 重複インスタンスを防ぐ
        }
    }
}
