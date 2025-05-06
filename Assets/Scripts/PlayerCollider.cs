
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerCollider : UdonSharpBehaviour
{
    [SerializeField]
    public int TeamLayer;

    [SerializeField]
    public int EnemyLayer;

    public void OnTriggerEnter(Collider other)
    {
        // プレイヤー自体のColliderが衝突した場合、 引数のotherはnullとなっているのでnullチェックして回避
        if (other != null)
        {
            // otherのレイヤーが敵チームレイヤー番号と一致したらHit判定
            if (other.gameObject.layer == EnemyLayer)
            {
                Debug.Log("Hit!!");
            }

        }
    }
}
