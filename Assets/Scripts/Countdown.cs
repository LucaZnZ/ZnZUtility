using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZnZUtil
{
    public class Countdown : IEnumerator<WaitForSeconds>
    {
        public WaitForSeconds Current => new WaitForSeconds(waitTimeStep);
        object IEnumerator.Current => Current;

        private readonly float waitTimeStep;
        private readonly float totalTime;
        private float curTime;

        public Countdown(float countdown, float timestep = 0.1f)
        {
            waitTimeStep = timestep;
            totalTime = countdown;
            curTime = countdown;
        }

        public void Dispose()
        {
            // NOOP nothing to dispose of
        }

        public bool MoveNext()
        {
            curTime -= waitTimeStep;

            if (curTime <= 0) curTime = 0; // just make sure  it is null and not negative, for display reasons

            return curTime > 0;
        }

        public float GetTime()
        {
            return curTime;
        }

        public void Reset()
        {
            curTime = totalTime;
        }
    }
}