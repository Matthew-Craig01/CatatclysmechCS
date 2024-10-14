#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using Unity.Collections;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // Summary:
    //     Base class for all entities in Unity Scenes.
    [ExcludeFromPreset]
    [NativeHeaderAttribute("Runtime/Export/Scripting/GameObject.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class GameObject : Object
    {
        //
        // Summary:
        //     Creates a new GameObject, named name.
        //
        // Parameters:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject();
        //
        // Summary:
        //     Creates a new GameObject, named name.
        //
        // Parameters:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject(string name);
        //
        // Summary:
        //     Creates a new GameObject, named name.
        //
        // Parameters:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject(string name, params Type[] components);

        //
        // Summary:
        //     The ParticleSystem attached to this GameObject (Read Only). (Null if there is
        //     none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property particleSystem has been deprecated. Use GetComponent<ParticleSystem>() instead. (UnityUpgradable)", true)]
        public Component particleSystem { get; }
        //
        // Summary:
        //     The Transform attached to this GameObject.
        public Transform transform { get; }
        //
        // Summary:
        //     The layer the GameObject is in.
        public int layer { get; set; }
        [Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.")]
        public bool active { get; set; }
        //
        // Summary:
        //     The local active state of this GameObject. (Read Only)
        public bool activeSelf { get; }
        //
        // Summary:
        //     Defines whether the GameObject is active in the Scene.
        public bool activeInHierarchy { get; }
        //
        // Summary:
        //     Gets and sets the GameObject's StaticEditorFlags.
        public bool isStatic { get; set; }
        //
        // Summary:
        //     The tag of this GameObject.
        public string tag { get; set; }
        //
        // Summary:
        //     Scene that the GameObject is part of.
        public Scene scene { get; }
        //
        // Summary:
        //     Scene culling mask Unity uses to determine which scene to render the GameObject
        //     in.
        public ulong sceneCullingMask { get; }
        public GameObject gameObject { get; }
        //
        // Summary:
        //     The Rigidbody2D component attached to this GameObject. (Read Only)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property rigidbody2D has been deprecated. Use GetComponent<Rigidbody2D>() instead. (UnityUpgradable)", true)]
        public Component rigidbody2D { get; }
        //
        // Summary:
        //     The Camera attached to this GameObject (Read Only). (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property camera has been deprecated. Use GetComponent<Camera>() instead. (UnityUpgradable)", true)]
        public Component camera { get; }
        //
        // Summary:
        //     The Light attached to this GameObject (Read Only). (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property light has been deprecated. Use GetComponent<Light>() instead. (UnityUpgradable)", true)]
        public Component light { get; }
        //
        // Summary:
        //     The Animation attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property animation has been deprecated. Use GetComponent<Animation>() instead. (UnityUpgradable)", true)]
        public Component animation { get; }
        //
        // Summary:
        //     The ConstantForce attached to this GameObject (Read Only). (Null if there is
        //     none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property constantForce has been deprecated. Use GetComponent<ConstantForce>() instead. (UnityUpgradable)", true)]
        public Component constantForce { get; }
        //
        // Summary:
        //     The Renderer attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property renderer has been deprecated. Use GetComponent<Renderer>() instead. (UnityUpgradable)", true)]
        public Component renderer { get; }
        //
        // Summary:
        //     The AudioSource attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property audio has been deprecated. Use GetComponent<AudioSource>() instead. (UnityUpgradable)", true)]
        public Component audio { get; }
        //
        // Summary:
        //     The NetworkView attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property networkView has been deprecated. Use GetComponent<NetworkView>() instead. (UnityUpgradable)", true)]
        public Component networkView { get; }
        //
        // Summary:
        //     The Collider attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property collider has been deprecated. Use GetComponent<Collider>() instead. (UnityUpgradable)", true)]
        public Component collider { get; }
        //
        // Summary:
        //     The Collider2D component attached to this object.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property collider2D has been deprecated. Use GetComponent<Collider2D>() instead. (UnityUpgradable)", true)]
        public Component collider2D { get; }
        //
        // Summary:
        //     The Rigidbody attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property rigidbody has been deprecated. Use GetComponent<Rigidbody>() instead. (UnityUpgradable)", true)]
        public Component rigidbody { get; }
        //
        // Summary:
        //     The HingeJoint attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property hingeJoint has been deprecated. Use GetComponent<HingeJoint>() instead. (UnityUpgradable)", true)]
        public Component hingeJoint { get; }

        //
        // Summary:
        //     Creates a GameObject with a primitive mesh renderer and appropriate collider.
        //
        //
        // Parameters:
        //   type:
        //     The type of primitive object to create.
        [FreeFunctionAttribute("GameObjectBindings::CreatePrimitive")]
        public static GameObject CreatePrimitive(PrimitiveType type);
        //
        // Summary:
        //     Finds a GameObject by name and returns it.
        //
        // Parameters:
        //   name:
        [FreeFunctionAttribute(Name = "GameObjectBindings::Find")]
        public static GameObject Find(string name);
        //
        // Summary:
        //     Returns an array of active GameObjects tagged tag. Returns empty array if no
        //     GameObject was found.
        //
        // Parameters:
        //   tag:
        //     The name of the tag to search GameObjects for.
        [FreeFunctionAttribute(Name = "GameObjectBindings::FindGameObjectsWithTag", ThrowsException = true)]
        public static GameObject[] FindGameObjectsWithTag(string tag);
        [FreeFunctionAttribute(Name = "GameObjectBindings::FindGameObjectWithTag", ThrowsException = true)]
        public static GameObject FindGameObjectWithTag(string tag);
        //
        // Summary:
        //     Returns one active GameObject tagged tag. Returns null if no GameObject was found.
        //
        //
        // Parameters:
        //   tag:
        //     The tag to search for.
        public static GameObject FindWithTag(string tag);
        //
        // Summary:
        //     Returns the Scene of a GameObject given by instance ID.
        //
        // Parameters:
        //   instanceID:
        //     The instance ID of a GameObject.
        //
        // Returns:
        //     Scene of GameObject of instance ID.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetSceneByInstanceID")]
        public static Scene GetScene(int instanceID);
        public static void InstantiateGameObjects(int sourceInstanceID, int count, NativeArray<int> newInstanceIDs, NativeArray<int> newTransformInstanceIDs, Scene destinationScene = default);
        public static void SetGameObjectsActive(ReadOnlySpan<int> instanceIDs, bool active);
        public static void SetGameObjectsActive(NativeArray<int> instanceIDs, bool active);
        //
        // Summary:
        //     Adds a component class of type componentType to the GameObject. C# Users can
        //     use a generic version.
        //
        // Parameters:
        //   componentType:
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component AddComponent(Type componentType);
        public T AddComponent<T>() where T : Component;
        //
        // Summary:
        //     Adds a component class named className to the GameObject.
        //
        // Parameters:
        //   className:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GameObject.AddComponent with string argument has been deprecated. Use GameObject.AddComponent<T>() instead. (UnityUpgradable).", true)]
        public Component AddComponent(string className);
        //
        // Parameters:
        //   methodName:
        //
        //   options:
        public void BroadcastMessage(string methodName, SendMessageOptions options);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject or
        //     any of its children.
        //
        // Parameters:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject or
        //     any of its children.
        //
        // Parameters:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName, object parameter);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject or
        //     any of its children.
        //
        // Parameters:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [FreeFunctionAttribute(Name = "Scripting::BroadcastScriptingMessage", HasExplicitThis = true)]
        public void BroadcastMessage(string methodName, [Internal.DefaultValue("null")] object parameter, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // Summary:
        //     Is this GameObject tagged with tag ?
        //
        // Parameters:
        //   tag:
        //     The tag to compare.
        [FreeFunctionAttribute(Name = "GameObjectBindings::CompareTag", HasExplicitThis = true)]
        public bool CompareTag(string tag);
        [SecuritySafeCritical]
        public T GetComponent<T>();
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of Component to search for.
        //
        // Returns:
        //     A Component of the matching type, otherwise null if no Component is found.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponent(Type type);
        //
        // Summary:
        //     The string-based version of this method.
        //
        // Parameters:
        //   type:
        //     The name of the type of Component to search for.
        //
        // Returns:
        //     A Component of the matching type, otherwise null if no Component is found.
        public Component GetComponent(string type);
        //
        // Summary:
        //     Gets a reference to a component of type T at a specific index on the specified
        //     GameObject.
        //
        // Parameters:
        //   index:
        //     The component index.
        //
        // Returns:
        //     A reference to a component of the type T at an index. Otherwise, returns null.
        public Component GetComponentAtIndex(int index);
        public T GetComponentAtIndex<T>(int index) where T : Component;
        //
        // Summary:
        //     Returns the number of components on this GameObject.
        //
        // Returns:
        //     The number of components.
        public int GetComponentCount();
        [ExcludeFromDocs]
        public T GetComponentInChildren<T>();
        public T GetComponentInChildren<T>([Internal.DefaultValue("false")] bool includeInactive);
        //
        // Summary:
        //     This is the non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Whether to include inactive child GameObjects in the search.
        //
        // Returns:
        //     A component of the matching type, if found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type type);
        //
        // Summary:
        //     This is the non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Whether to include inactive child GameObjects in the search.
        //
        // Returns:
        //     A component of the matching type, if found.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentInChildren", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type type, bool includeInactive);
        //
        // Summary:
        //     Gets the index of the component specified on the specified GameObject.
        //
        // Parameters:
        //   component:
        //     The component to search for.
        //
        // Returns:
        //     The component index. Otherwise, returns -1.
        public int GetComponentIndex(Component component);
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        //   includeInactive:
        //     Whether to include inactive parent GameObjects in the search.
        //
        // Returns:
        //     A Component of the matching type, otherwise null if no Component is found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type type);
        public T GetComponentInParent<T>([Internal.DefaultValue("false")] bool includeInactive);
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        //   includeInactive:
        //     Whether to include inactive parent GameObjects in the search.
        //
        // Returns:
        //     A Component of the matching type, otherwise null if no Component is found.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentInParent", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type type, bool includeInactive);
        [ExcludeFromDocs]
        public T GetComponentInParent<T>();
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        // Returns:
        //     An array containing all matching components of type type.
        public Component[] GetComponents(Type type);
        public void GetComponents<T>(List<T> results);
        public T[] GetComponents<T>();
        public void GetComponents(Type type, List<Component> results);
        public void GetComponentsInChildren<T>(List<T> results);
        public T[] GetComponentsInChildren<T>();
        public void GetComponentsInChildren<T>(bool includeInactive, List<T> results);
        public T[] GetComponentsInChildren<T>(bool includeInactive);
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        //   includeInactive:
        //     Whether to include inactive child GameObjects in the search.
        //
        // Returns:
        //     An array of all found components matching the specified type.
        public Component[] GetComponentsInChildren(Type type, [Internal.DefaultValue("false")] bool includeInactive);
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        //   includeInactive:
        //     Whether to include inactive child GameObjects in the search.
        //
        // Returns:
        //     An array of all found components matching the specified type.
        [ExcludeFromDocs]
        public Component[] GetComponentsInChildren(Type type);
        [ExcludeFromDocs]
        public Component[] GetComponentsInParent(Type type);
        public void GetComponentsInParent<T>(bool includeInactive, List<T> results);
        public T[] GetComponentsInParent<T>(bool includeInactive);
        public T[] GetComponentsInParent<T>();
        //
        // Summary:
        //     The non-generic version of this method.
        //
        // Parameters:
        //   type:
        //     The type of component to search for.
        //
        //   includeInactive:
        //     Whether to include inactive parent GameObjects in the search.
        //
        // Returns:
        //     An array of all found components matching the specified type.
        public Component[] GetComponentsInParent(Type type, [Internal.DefaultValue("false")] bool includeInactive);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("gameObject.PlayAnimation is not supported anymore. Use animation.Play()", true)]
        public void PlayAnimation(Object animation);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GameObject.SampleAnimation(AnimationClip, float) has been deprecated. Use AnimationClip.SampleAnimation(GameObject, float) instead (UnityUpgradable).", true)]
        public void SampleAnimation(Object clip, float time);
        //
        // Parameters:
        //   methodName:
        //
        //   options:
        public void SendMessage(string methodName, SendMessageOptions options);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject.
        //
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessage(string methodName);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject.
        //
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessage(string methodName, object value);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject.
        //
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [FreeFunctionAttribute(Name = "Scripting::SendScriptingMessage", HasExplicitThis = true)]
        public void SendMessage(string methodName, [Internal.DefaultValue("null")] object value, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // Parameters:
        //   methodName:
        //
        //   options:
        public void SendMessageUpwards(string methodName, SendMessageOptions options);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject and
        //     on every ancestor of the behaviour.
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject and
        //     on every ancestor of the behaviour.
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName, object value);
        //
        // Summary:
        //     Calls the method named methodName on every MonoBehaviour in this GameObject and
        //     on every ancestor of the behaviour.
        //
        // Parameters:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [FreeFunctionAttribute(Name = "Scripting::SendScriptingMessageUpwards", HasExplicitThis = true)]
        public void SendMessageUpwards(string methodName, [Internal.DefaultValue("null")] object value, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // Summary:
        //     ActivatesDeactivates the GameObject, depending on the given true or false/ value.
        //
        //
        // Parameters:
        //   value:
        //     Activate or deactivate the object, where true activates the GameObject and false
        //     deactivates the GameObject.
        [NativeMethodAttribute(Name = "SetSelfActive")]
        public void SetActive(bool value);
        [NativeMethodAttribute(Name = "SetActiveRecursivelyDeprecated")]
        [Obsolete("gameObject.SetActiveRecursively() is obsolete. Use GameObject.SetActive(), which is now inherited by children.")]
        public void SetActiveRecursively(bool state);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("gameObject.StopAnimation is not supported anymore. Use animation.Stop()", true)]
        public void StopAnimation();
        public bool TryGetComponent(Type type, out Component component);
        [SecuritySafeCritical]
        public bool TryGetComponent<T>(out T component);
    }
}