using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _pickUpSound;

    private float _healthToRestore = 30;
    private float _destructionDelay = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICureable>(out ICureable cureable))
        {
            _audioSource.PlayOneShot(_pickUpSound);

            cureable.Cure(_healthToRestore);

            Destroy(gameObject, _destructionDelay);
        }
    }
}
