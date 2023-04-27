using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] Sprite[] skins;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int randomNumber = Random.Range(0, skins.Length);
        spriteRenderer.sprite = skins[randomNumber];
    }
}
