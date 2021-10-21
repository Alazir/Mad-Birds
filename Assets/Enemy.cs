using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void destroyMonster()
    {
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
            return;

        Bird bird = collision.collider.GetComponent<Bird>();
        // The eney was hitten by a bird.
        if (bird != null)
        {
            destroyMonster();
            return;
        }
        
        if (collision.contacts[0].normal.y < - 0.5)
        {
            destroyMonster();
            return;
        }
    }
}
