using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidualBody : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] spriteColors;
    [SerializeField] private LayerMask layer2BeAffected;
    [SerializeField] private float affectArea;
    private RaycastHit2D[] boxes;
    private bool auraIsActive;
    private Transform parent;
    private SpriteRenderer sprite;
    private Transform child;
    private void Awake()
    {
        boxes = new RaycastHit2D[0];
    auraIsActive = false;
        parent = transform.parent;
        sprite = GetComponent<SpriteRenderer>();
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (auraIsActive)
        {
            RaycastHit2D[] newBoxes = Physics2D.CircleCastAll(transform.position, affectArea, Vector3.left, 0, layer2BeAffected);

            if(newBoxes.Length > 0)
            {
                foreach (RaycastHit2D box in newBoxes)
                {
                    MovebleItems moveble = box.transform.gameObject.GetComponent<MovebleItems>();
                    if (!moveble.IsActivate)
                        moveble.resetValues(true);

                }
                boxes = newBoxes;
            }
          


        }
   
    }


    private void OnDrawGizmos()
    {
        if (auraIsActive)
        {
            Gizmos.DrawWireSphere(transform.position, affectArea);
        }


    }


    public void ActivateAura(bool activate)
    {

        child.gameObject.SetActive(activate);
        auraIsActive = activate;
        if (!activate)
        {
            foreach (RaycastHit2D box in boxes)
            {
                MovebleItems moveble = box.transform.gameObject.GetComponent<MovebleItems>();
                moveble.resetValues(false);

            }

            boxes = new RaycastHit2D[0];
        }
    }

    public void ResetParent()
    {
        if (transform.parent == null)
        {
            transform.parent = parent;
        }
        else
        {
            transform.parent = null;
        }
    }

    public void ResetSpriteRenderer(PlayerTypes playerType)
    {
        sprite.sprite = playerType == PlayerTypes.YIN ? spriteColors[0] : spriteColors[1];

        sprite.enabled = !sprite.enabled;
    }


    public Transform GetTransform()
    {
        return transform;
    }
}
