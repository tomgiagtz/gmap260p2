using UnityEngine;

[ExecuteInEditMode]
public class Platform : MonoBehaviour
{
    
    private BoxCollider2D _collider;
    private SpriteRenderer sprite;

    private void Awake() {
       runInEditMode = true; 
    }
    private void Start() {
        _collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update() {
        _collider.offset = new Vector2(0,sprite.bounds.size.y / 2f);
        _collider.size = new Vector3(sprite.bounds.size.x / transform.lossyScale.x,
                                    sprite.bounds.size.y / transform.lossyScale.y,
                                    sprite.bounds.size.z / transform.lossyScale.z);
    }
}
