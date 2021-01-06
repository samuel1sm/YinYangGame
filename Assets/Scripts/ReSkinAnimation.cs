using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReSkinAnimation : MonoBehaviour
{


       public Sprite[] subSprites;

        void LateUpdate()
        {
            foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sprite = subSprites[int.Parse(renderer.sprite.name.Substring(8))];
            }
        }

}
