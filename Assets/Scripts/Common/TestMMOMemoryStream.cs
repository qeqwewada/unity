using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestMMOMemoryStream : MonoBehaviour
{
    [Header("User Configuration")]
    [SerializeField] private User defaultUser;

    void Start()
    {
        if (defaultUser == null)
        {
            defaultUser = new User
            {
                username = "testuser",
                password = "password123"
            };
        }
        Register(defaultUser);
    }

    void Register(User user)
    {
        string url = "http://localhost:8080/user/register";
        string jsonData = JsonUtility.ToJson(user);

        NetWorkHttp.Instance.Post(url, jsonData,
            onSuccess: (response) => {
                Debug.Log("User registered successfully: " + response);
            },
            onError: (error) => {
                Debug.LogWarning("Registration failed: " + error);
            }
        );
    }
}

[System.Serializable]
public class User
{
    [Header("User Info")]
    [Tooltip("用户名")]
    public string username;
    
    [Tooltip("密码")]
    public string password;
    
    [Tooltip("邮箱地址")]
    public string email;
}


