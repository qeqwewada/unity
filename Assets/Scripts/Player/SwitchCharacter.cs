using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] characters; // 角色预制体数组
    private int currentCharacterIndex = 0; // 当前角色索引

    void Start()
    {
        // 初始化时确保只有当前角色是激活的
        UpdateCharactersVisibility();
    }

    void Update()
    {
        // 检测切换角色的输入
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToPreviousCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextCharacter();
        }
    }

    private void SwitchToPreviousCharacter()
    {
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characters.Length - 1;
        }
        UpdateCharactersVisibility();
    }

    private void SwitchToNextCharacter()
    {
        currentCharacterIndex++;
        if (currentCharacterIndex >= characters.Length)
        {
            currentCharacterIndex = 0;
        }
        UpdateCharactersVisibility();
    }

    private void UpdateCharactersVisibility()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == currentCharacterIndex);
        }
    }
}
