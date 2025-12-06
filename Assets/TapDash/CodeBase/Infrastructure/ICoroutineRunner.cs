using System.Collections;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}