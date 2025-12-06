using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TapDash.CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) => _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        public IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}