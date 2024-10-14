#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Security;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // Summary:
    //     Base class for all objects Unity can reference.
    [NativeHeaderAttribute("Runtime/GameCode/CloneObject.h")]
    [NativeHeaderAttribute("Runtime/Export/Scripting/UnityEngineObject.bindings.h")]
    [NativeHeaderAttribute("Runtime/SceneManager/SceneManager.h")]
    [RequiredByNativeCodeAttribute(GenerateProxy = true)]
    public class Object
    {
        public Object();

        //
        // Summary:
        //     Should the object be hidden, saved with the Scene or modifiable by the user?
        public HideFlags hideFlags { get; set; }
        //
        // Summary:
        //     The name of the object.
        public string name { get; set; }

        //
        // Summary:
        //     Removes a GameObject, component or asset.
        //
        // Parameters:
        //   obj:
        //     The object to destroy.
        //
        //   t:
        //     The optional amount of time to delay before destroying the object.
        [ExcludeFromDocs]
        public static void Destroy(Object obj);
        //
        // Summary:
        //     Removes a GameObject, component or asset.
        //
        // Parameters:
        //   obj:
        //     The object to destroy.
        //
        //   t:
        //     The optional amount of time to delay before destroying the object.
        [NativeMethodAttribute(Name = "Scripting::DestroyObjectFromScripting", IsFreeFunction = true, ThrowsException = true)]
        public static void Destroy(Object obj, [DefaultValue("0.0F")] float t);
        //
        // Summary:
        //     Destroys the object obj immediately. You are strongly recommended to use Destroy
        //     instead.
        //
        // Parameters:
        //   obj:
        //     Object to be destroyed.
        //
        //   allowDestroyingAssets:
        //     Set to true to allow assets to be destroyed.
        [NativeMethodAttribute(Name = "Scripting::DestroyObjectFromScriptingImmediate", IsFreeFunction = true, ThrowsException = true)]
        public static void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets);
        //
        // Summary:
        //     Destroys the object obj immediately. You are strongly recommended to use Destroy
        //     instead.
        //
        // Parameters:
        //   obj:
        //     Object to be destroyed.
        //
        //   allowDestroyingAssets:
        //     Set to true to allow assets to be destroyed.
        [ExcludeFromDocs]
        public static void DestroyImmediate(Object obj);
        [ExcludeFromDocs]
        [Obsolete("use Object.Destroy instead.")]
        public static void DestroyObject(Object obj);
        [Obsolete("use Object.Destroy instead.")]
        public static void DestroyObject(Object obj, [DefaultValue("0.0F")] float t);
        //
        // Summary:
        //     Do not destroy the target Object when loading a new Scene.
        //
        // Parameters:
        //   target:
        //     An Object not destroyed on Scene change.
        [FreeFunctionAttribute("GetSceneManager().DontDestroyOnLoad", ThrowsException = true)]
        public static void DontDestroyOnLoad([NotNullAttribute("NullExceptionObject")] Object target);
        public static T FindAnyObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object;
        public static T FindAnyObjectByType<T>() where T : Object;
        //
        // Summary:
        //     Retrieves any active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        // Returns:
        //     Returns an arbitrary active loaded object that matches the specified type. If
        //     no object matches the specified type, returns null.
        public static Object FindAnyObjectByType(Type type);
        //
        // Summary:
        //     Retrieves any active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        // Returns:
        //     Returns an arbitrary active loaded object that matches the specified type. If
        //     no object matches the specified type, returns null.
        public static Object FindAnyObjectByType(Type type, FindObjectsInactive findObjectsInactive);
        public static T FindFirstObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object;
        public static T FindFirstObjectByType<T>() where T : Object;
        //
        // Summary:
        //     Retrieves the first active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        // Returns:
        //     Returns the first active loaded object that matches the specified type. If no
        //     object matches the specified type, returns null.
        public static Object FindFirstObjectByType(Type type, FindObjectsInactive findObjectsInactive);
        //
        // Summary:
        //     Retrieves the first active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        // Returns:
        //     Returns the first active loaded object that matches the specified type. If no
        //     object matches the specified type, returns null.
        public static Object FindFirstObjectByType(Type type);
        //
        // Summary:
        //     Returns the first active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //
        // Returns:
        //     Object The first active loaded object that matches the specified type. It returns
        //     null if no Object matches the type.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public static Object FindObjectOfType(Type type);
        public static T FindObjectOfType<T>(bool includeInactive) where T : Object;
        public static T FindObjectOfType<T>() where T : Object;
        //
        // Summary:
        //     Returns the first active loaded object of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //
        // Returns:
        //     Object The first active loaded object that matches the specified type. It returns
        //     null if no Object matches the type.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public static Object FindObjectOfType(Type type, bool includeInactive);
        public static T[] FindObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Object;
        //
        // Summary:
        //     Retrieves a list of all loaded objects of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        //   sortMode:
        //     Whether and how to sort the returned array. Not sorting the array makes this
        //     function run significantly faster.
        //
        // Returns:
        //     The array of objects found matching the type specified.
        [FreeFunctionAttribute("UnityEngineObjectBindings::FindObjectsByType")]
        [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
        public static Object[] FindObjectsByType(Type type, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode);
        public static T[] FindObjectsByType<T>(FindObjectsSortMode sortMode) where T : Object;
        //
        // Summary:
        //     Retrieves a list of all loaded objects of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   findObjectsInactive:
        //     Whether to include components attached to inactive GameObjects. If you don't
        //     specify this parameter, this function doesn't include inactive objects in the
        //     results.
        //
        //   sortMode:
        //     Whether and how to sort the returned array. Not sorting the array makes this
        //     function run significantly faster.
        //
        // Returns:
        //     The array of objects found matching the type specified.
        public static Object[] FindObjectsByType(Type type, FindObjectsSortMode sortMode);
        //
        // Summary:
        //     Gets a list of all loaded objects of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //     If true, components attached to inactive GameObjects are also included.
        //
        // Returns:
        //     The array of objects found matching the type specified.
        public static Object[] FindObjectsOfType(Type type);
        public static T[] FindObjectsOfType<T>(bool includeInactive) where T : Object;
        public static T[] FindObjectsOfType<T>() where T : Object;
        //
        // Summary:
        //     Gets a list of all loaded objects of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //     If true, components attached to inactive GameObjects are also included.
        //
        // Returns:
        //     The array of objects found matching the type specified.
        [FreeFunctionAttribute("UnityEngineObjectBindings::FindObjectsOfType")]
        [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
        public static Object[] FindObjectsOfType(Type type, bool includeInactive);
        //
        // Summary:
        //     Returns a list of all active and inactive loaded objects of Type type.
        //
        // Parameters:
        //   type:
        //     The type of object to find.
        //
        // Returns:
        //     The array of objects found matching the type specified.
        [Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
        public static Object[] FindObjectsOfTypeAll(Type type);
        //
        // Summary:
        //     Returns a list of all active and inactive loaded objects of Type type, including
        //     assets.
        //
        // Parameters:
        //   type:
        //     The type of object or asset to find.
        //
        // Returns:
        //     The array of objects and assets found matching the type specified.
        [FreeFunctionAttribute("UnityEngineObjectBindings::FindObjectsOfTypeIncludingAssets")]
        [Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
        public static Object[] FindObjectsOfTypeIncludingAssets(Type type);
        [Obsolete("warning use Object.FindObjectsByType instead.")]
        public static Object[] FindSceneObjectsOfType(Type type);
        public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object;
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original);
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Scene scene);
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace);
        public static T Instantiate<T>(T original) where T : Object;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object;
        //
        // Summary:
        //     Clones the object original and returns the clone.
        //
        // Parameters:
        //   original:
        //     An existing object that you want to make a copy of.
        //
        //   position:
        //     Position for the new object.
        //
        //   rotation:
        //     Orientation of the new object.
        //
        //   parent:
        //     Parent that will be assigned to the new object.
        //
        //   instantiateInWorldSpace:
        //     When you assign a parent Object, pass true to position the new object directly
        //     in world space. Pass false to set the Object’s position relative to its new parent.
        //
        //
        //   scene:
        //
        // Returns:
        //     The instantiated clone.
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Transform parent);
        public static T Instantiate<T>(T original, Transform parent) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent, Vector3 position, Quaternion rotation) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Vector3 position, Quaternion rotation) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Vector3 position, Quaternion rotation) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, Vector3 position, Quaternion rotation) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations) where T : Object;
        public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count) where T : Object;
        public override bool Equals(object other);
        public override int GetHashCode();
        //
        // Summary:
        //     Gets the instance ID of the object.
        //
        // Returns:
        //     Returns the instance ID of the object.
        [SecuritySafeCritical]
        public int GetInstanceID();
        //
        // Summary:
        //     Returns the name of the object.
        //
        // Returns:
        //     The name returned by ToString.
        public override string ToString();

        public static bool operator ==(Object x, Object y);
        public static bool operator !=(Object x, Object y);

        public static implicit operator bool(Object exists);
    }
}