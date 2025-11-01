using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class SimpleAnimation : MonoBehaviour
    {
        private void Start()
        {
            transform.DORotate(new Vector3(180, 180, 180), 3f).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}