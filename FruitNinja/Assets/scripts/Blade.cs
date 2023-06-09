using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private float mousePosZ;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        setBladeToMouse();
    }

    private void setBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = mousePosZ;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
