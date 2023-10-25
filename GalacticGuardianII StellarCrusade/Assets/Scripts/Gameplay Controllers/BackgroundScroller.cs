using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float speed = -0.1f;
    [SerializeField] private float yAxis;

    private Material backgroundMaterial;

    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        yAxis += speed * Time.deltaTime;
        backgroundMaterial.SetTextureOffset("_MainTex", new Vector2 (0, yAxis));
    }
}
