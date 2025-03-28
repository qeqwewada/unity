using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoginPanel : BasePanel
{
    public Animator animator;
    public Text UIText;
    private Sequence blinkSequence;
    public Button GuestLoginButton;
    public Button ServiceLoginButton;

    public Button CloseButton;
    public Button ConfirmButton;
    public GameObject loginMask;


    void Start()
    {
        // 创建动画序列
        blinkSequence = DOTween.Sequence();
        blinkSequence.Append(UIText.DOFade(0, 0.5f))  // 0.5秒渐隐
                     .Append(UIText.DOFade(1, 0.5f))  // 0.5秒渐显
                     .SetLoops(-1); // 无限循环
        blinkSequence.Play();
        GuestLoginButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX(SFXConst.LoginSFX,.8f);
            gameObject.SetActive(false);
            animator.SetTrigger("LoginSuccess");
        });
        ServiceLoginButton.onClick.AddListener(() => {
            loginMask.SetActive(true);
        });
        ConfirmButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
            animator.SetTrigger("LoginSuccess");
        });
        CloseButton.onClick.AddListener(() => {
            loginMask.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy() {
        blinkSequence?.Kill(); // 防止内存泄漏
    }
}
