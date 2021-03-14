using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class Timer
    {
        public float time { get; private set; }
        public bool running { get; private set; }
        MonoBehaviour _monoBehaviour;
        Coroutine timerCoroutine;
        public Timer(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        IEnumerator TimerCoroutine()
        {
            while (true)
            {
                yield return null;
                time += Time.deltaTime;
            }
        }
        public void Start()
        {
            if (timerCoroutine != null)
            {
                _monoBehaviour.StopCoroutine(timerCoroutine);
            }
            running = true;
            timerCoroutine = _monoBehaviour.StartCoroutine(TimerCoroutine());
        }
        public void Stop()
        {
            if (timerCoroutine != null)
            {
                _monoBehaviour.StopCoroutine(timerCoroutine);
            }
            running = false;
        }
        public void Reset()
        {
            time = 0;
        }
    }

}
