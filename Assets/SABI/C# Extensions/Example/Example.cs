using UnityEngine;

namespace SABI
{
    public class Example : MonoBehaviour
    {
        private void Start()
        {
            int number = 93434;
            Debug.Log(
                $"[C# Extensions] {number}.RoundToMultipleOf(5) : {number.RoundToMultipleOf(5)}"
            );
            Debug.Log(
                $"[C# Extensions] {number}.ToAbbreviatedString() : {number.ToAbbreviatedString()}"
            );
            this.DelayedExecution(
                3,
                () => Debug.Log($"[C# Extensions] 3 seconds delayed execution")
            );
        }
    }
}
