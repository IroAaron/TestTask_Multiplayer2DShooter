using Unity.Netcode;
using UnityEngine;

public class CharacterStats : NetworkBehaviour
{
    public string PlayerName;

    [SerializeField] private float _speed = 3;
    [SerializeField] private float _bonusDamage = 1;
    [SerializeField] private float _hp = 100;

    public NetworkVariable<float> Speed = new NetworkVariable<float>();
    public NetworkVariable<float> BonusDamage = new NetworkVariable<float>();
    public NetworkVariable<float> HP = new NetworkVariable<float>();

    private void Update()
    {
        Speed.Value = _speed;
        BonusDamage.Value = _bonusDamage;
        HP.Value = _hp;
    }
}
