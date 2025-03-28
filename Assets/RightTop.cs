using DG.Tweening;
using UnityEngine;

public class RightTop : BasePanel
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.DOMoveY(transform.position.y+300f, 1).From();
    }

}
