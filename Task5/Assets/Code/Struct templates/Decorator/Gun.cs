using Code.Struct_templates.Decorator.Interfaces;
using Code.Struct_templates.Decorator.Model;
using UnityEngine;

namespace Code.Struct_templates.Decorator
{
    internal sealed class Gun : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        
        [Header("Launcher Gun")]
        [SerializeField] private AudioClip _audioClipLauncher;
        [SerializeField] private Transform _barrelPositionLauncher;
        [SerializeField] private GameObject _launcher;

        private void Start()
        {
            Bullet ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 2000.0f,
                _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
                _barrelPosition, _muffler);
            ModificationWeapon modificationWeaponMuffler = new
                    ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeaponMuffler.ApplyModification(weapon);
            _fire = modificationWeaponMuffler;
            
            var launcher = new Launcher(_audioClipLauncher, _barrelPositionLauncher, _launcher);
            ModificationWeapon modificationWeaponLauncher = new
                ModificationLauncher(_audioSource, launcher, _barrelPositionLauncher.position);
            modificationWeaponLauncher.ApplyModification(weapon);
            _fire = modificationWeaponLauncher;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
            if (Input.GetMouseButtonDown(1))
            {
                _fire.Fire();
            }
            
            /*if (Input.GetButtonDown("1"))
            {
                AddMufler(_muffler);
            }*/
        }

        /*private void AddMufler(Weapon weapon)
        {
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
                _barrelPosition, _muffler);
            ModificationWeapon modificationWeaponMuffler = new
                ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeaponMuffler.ApplyModification(weapon);
            _fire = modificationWeaponMuffler;
        }*/
    }
}