using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectableScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private int currentSprite = -1;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (currentSprite < 0)
            currentSprite = Random.Range(0, sprites.Length);
        else if (currentSprite > sprites.Length)
            currentSprite = sprites.Length - 1;

        spriteRenderer.sprite = sprites[currentSprite];


    }

    // Update is called once per frame
    void Update()
    {

    }





}//class
