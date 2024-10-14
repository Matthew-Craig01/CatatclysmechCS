#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections;
using System.Threading;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // Summary:
    //     MonoBehaviour is a base class that many Unity scripts derive from.
    [ExtensionOfNativeClassAttribute]
    [NativeHeaderAttribute("Runtime/Scripting/DelayedCallUtility.h")]
    [NativeHeaderAttribute("Runtime/Mono/MonoBehaviour.h")]
    [RequiredByNativeCodeAttribute]
    public class MonoBehaviour : Behaviour
    {
        public MonoBehaviour();

        //
        // Summary:
        //     Cancellation token raised when the MonoBehaviour is destroyed (Read Only).
        public CancellationToken destroyCancellationToken { get; }
        //
        // Summary:
        //     Disabling this lets you skip the GUI layout phase.
        public bool useGUILayout { get; set; }
        //
        // Summary:
        //     Allow a specific instance of a MonoBehaviour to run in edit mode (only available
        //     in the editor).
        public bool runInEditMode { get; set; }

        //
        // Summary:
        //     Logs message to the Unity Console (identical to Debug.Log).
        //
        // Parameters:
        //   message:
        public static void print(object message);
        //
        // Summary:
        //     Cancels all Invoke calls with name methodName on this behaviour.
        //
        // Parameters:
        //   methodName:
        public void CancelInvoke(string methodName);
        //
        // Summary:
        //     Cancels all Invoke calls on this MonoBehaviour.
        public void CancelInvoke();
        //
        // Summary:
        //     Invokes the method methodName in time seconds.
        //
        // Parameters:
        //   methodName:
        //
        //   time:
        public void Invoke(string methodName, float time);
        //
        // Summary:
        //     Invokes the method methodName in time seconds, then repeatedly every repeatRate
        //     seconds.
        //
        // Parameters:
        //   methodName:
        //     The name of a method to invoke.
        //
        //   time:
        //     Start invoking after n seconds.
        //
        //   repeatRate:
        //     Repeat every n seconds.
        public void InvokeRepeating(string methodName, float time, float repeatRate);
        //
        // Summary:
        //     Is any invoke on methodName pending?
        //
        // Parameters:
        //   methodName:
        public bool IsInvoking(string methodName);
        //
        // Summary:
        //     Is any invoke pending on this MonoBehaviour?
        public bool IsInvoking();
        //
        // Summary:
        //     Starts a coroutine named methodName.
        //
        // Parameters:
        //   methodName:
        //
        //   value:
        [ExcludeFromDocs]
        public Coroutine StartCoroutine(string methodName);
        //
        // Summary:
        //     Starts a coroutine named methodName.
        //
        // Parameters:
        //   methodName:
        //
        //   value:
        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);
        //
        // Summary:
        //     Starts a Coroutine.
        //
        // Parameters:
        //   routine:
        public Coroutine StartCoroutine(IEnumerator routine);
        [Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", false)]
        public Coroutine StartCoroutine_Auto(IEnumerator routine);
        //
        // Summary:
        //     Stops all coroutines running on this behaviour.
        public void StopAllCoroutines();
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(IEnumerator routine);
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(Coroutine routine);
        //
        // Summary:
        //     Stops the first coroutine named methodName, or the coroutine stored in routine
        //     running on this behaviour.
        //
        // Parameters:
        //   methodName:
        //     Name of coroutine.
        //
        //   routine:
        //     Name of the function in code, including coroutines.
        public void StopCoroutine(string methodName);
    }
}