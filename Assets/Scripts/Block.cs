using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //config parameters - things we need to know before the game
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference - usually references to game objects
    Level level;
    GameStatus gamestatus;

    //state variables
    [SerializeField] int timesHit; //ONLY SERIALIZED FOR DEBUG

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            gamestatus = FindObjectOfType<GameStatus>();
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        gamestatus.AddToScore();
        int maxHits = hitSprites.Length;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing form array " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        level.CountBlocks();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        GameObject.Destroy(sparkles, 2f);
    }
}