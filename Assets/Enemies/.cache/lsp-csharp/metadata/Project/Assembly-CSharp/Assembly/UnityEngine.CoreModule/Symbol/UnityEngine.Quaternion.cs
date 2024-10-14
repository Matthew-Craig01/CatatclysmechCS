#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // Summary:
    //     Quaternions are used to represent rotations.
    [DefaultMember("Item")]
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeHeaderAttribute("Runtime/Math/MathScripting.h")]
    [NativeTypeAttribute(Header = "Runtime/Math/Quaternion.h")]
    [UsedByNativeCodeAttribute]
    public struct Quaternion : IEquatable<Quaternion>, IFormattable
    {
        public const float kEpsilon = 1E-06F;
        //
        // Summary:
        //     X component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float x;
        //
        // Summary:
        //     Y component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float y;
        //
        // Summary:
        //     Z component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float z;
        //
        // Summary:
        //     W component of the Quaternion. Do not directly modify quaternions.
        public float w;

        //
        // Summary:
        //     Constructs new Quaternion with given x,y,z,w components.
        //
        // Parameters:
        //   x:
        //
        //   y:
        //
        //   z:
        //
        //   w:
        public Quaternion(float x, float y, float z, float w);

        public float this[int index] { get; set; }

        //
        // Summary:
        //     The identity rotation (Read Only).
        public static Quaternion identity { get; }
        //
        // Summary:
        //     Returns or sets the euler angle representation of the rotation in degrees.
        public Vector3 eulerAngles { get; set; }
        //
        // Summary:
        //     Returns this quaternion with a magnitude of 1 (Read Only).
        public Quaternion normalized { get; }

        //
        // Summary:
        //     Returns the angle in degrees between two rotations a and b. The resulting angle
        //     ranges from 0 to 180.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static float Angle(Quaternion a, Quaternion b);
        //
        // Summary:
        //     Creates a rotation which rotates angle degrees around axis.
        //
        // Parameters:
        //   angle:
        //
        //   axis:
        [FreeFunctionAttribute("QuaternionScripting::AngleAxis", IsThreadSafe = true)]
        public static Quaternion AngleAxis(float angle, Vector3 axis);
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees")]
        public static Quaternion AxisAngle(Vector3 axis, float angle);
        //
        // Summary:
        //     The dot product between two rotations.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static float Dot(Quaternion a, Quaternion b);
        //
        // Summary:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parameters:
        //   euler:
        public static Quaternion Euler(Vector3 euler);
        //
        // Summary:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis; applied in that order.
        //
        // Parameters:
        //   x:
        //
        //   y:
        //
        //   z:
        public static Quaternion Euler(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerAngles(Vector3 euler);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerAngles(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerRotation(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerRotation(Vector3 euler);
        //
        // Summary:
        //     Creates a rotation from fromDirection to toDirection.
        //
        // Parameters:
        //   fromDirection:
        //     A non-unit or unit vector representing a direction axis to rotate.
        //
        //   toDirection:
        //     A non-unit or unit vector representing the target direction axis.
        //
        // Returns:
        //     A unit quaternion which rotates from fromDirection to toDirection.
        [FreeFunctionAttribute("FromToQuaternionSafe", IsThreadSafe = true)]
        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection);
        //
        // Summary:
        //     Returns the Inverse of rotation.
        //
        // Parameters:
        //   rotation:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static Quaternion Inverse(Quaternion rotation);
        //
        // Summary:
        //     Interpolates between a and b by t and normalizes the result afterwards.
        //
        // Parameters:
        //   a:
        //     Start unit quaternion value, returned when t = 0.
        //
        //   b:
        //     End unit quaternion value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio. The value is clamped to the range [0, 1].
        //
        // Returns:
        //     A unit quaternion interpolated between quaternions a and b.
        [FreeFunctionAttribute("QuaternionScripting::Lerp", IsThreadSafe = true)]
        public static Quaternion Lerp(Quaternion a, Quaternion b, float t);
        //
        // Summary:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        [FreeFunctionAttribute("QuaternionScripting::LerpUnclamped", IsThreadSafe = true)]
        public static Quaternion LerpUnclamped(Quaternion a, Quaternion b, float t);
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        [ExcludeFromDocs]
        public static Quaternion LookRotation(Vector3 forward);
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        [FreeFunctionAttribute("QuaternionScripting::LookRotation", IsThreadSafe = true)]
        public static Quaternion LookRotation(Vector3 forward, [DefaultValue("Vector3.up")] Vector3 upwards);
        //
        // Summary:
        //     Converts this quaternion to a quaternion with the same orientation but with a
        //     magnitude of 1.0.
        //
        // Parameters:
        //   q:
        public static Quaternion Normalize(Quaternion q);
        //
        // Summary:
        //     Rotates a rotation from towards to.
        //
        // Parameters:
        //   from:
        //     The unit quaternion to be aligned with to.
        //
        //   to:
        //     The target unit quaternion.
        //
        //   maxDegreesDelta:
        //     The maximum angle in degrees allowed for this rotation.
        //
        // Returns:
        //     A unit quaternion rotated towards to by an angular step of maxDegreesDelta.
        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta);
        //
        // Summary:
        //     Spherically linear interpolates between unit quaternions a and b by a ratio of
        //     t.
        //
        // Parameters:
        //   a:
        //     Start unit quaternion value, returned when t = 0.
        //
        //   b:
        //     End unit quaternion value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio. Value is clamped to the range [0, 1].
        //
        // Returns:
        //     A unit quaternion spherically interpolated between quaternions a and b.
        [FreeFunctionAttribute("QuaternionScripting::Slerp", IsThreadSafe = true)]
        public static Quaternion Slerp(Quaternion a, Quaternion b, float t);
        //
        // Summary:
        //     Spherically linear interpolates between unit quaternions a and b by t.
        //
        // Parameters:
        //   a:
        //     Start unit quaternion value, returned when t = 0.
        //
        //   b:
        //     End unit quaternion value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio. Value is unclamped.
        //
        // Returns:
        //     A unit quaternion spherically interpolated between unit quaternions a and b.
        [FreeFunctionAttribute("QuaternionScripting::SlerpUnclamped", IsThreadSafe = true)]
        public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t);
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Vector3 ToEulerAngles(Quaternion rotation);
        public bool Equals(Quaternion other);
        public override bool Equals(object other);
        public override int GetHashCode();
        public void Normalize();
        //
        // Summary:
        //     Set x, y, z and w components of an existing Quaternion.
        //
        // Parameters:
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        //
        //   newW:
        public void Set(float newX, float newY, float newZ, float newW);
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetAxisAngle(Vector3 axis, float angle);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(Vector3 euler);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(Vector3 euler);
        //
        // Summary:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parameters:
        //   fromDirection:
        //
        //   toDirection:
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection);
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        [ExcludeFromDocs]
        public void SetLookRotation(Vector3 view);
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vector3 view, [DefaultValue("Vector3.up")] Vector3 up);
        public void ToAngleAxis(out float angle, out Vector3 axis);
        [Obsolete("Use Quaternion.ToAngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void ToAxisAngle(out Vector3 axis, out float angle);
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vector3 ToEuler();
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vector3 ToEulerAngles();
        //
        // Summary:
        //     Returns a formatted string for this quaternion.
        //
        // Parameters:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format, IFormatProvider formatProvider);
        //
        // Summary:
        //     Returns a formatted string for this quaternion.
        //
        // Parameters:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format);
        //
        // Summary:
        //     Returns a formatted string for this quaternion.
        //
        // Parameters:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public override string ToString();

        public static Vector3 operator *(Quaternion rotation, Vector3 point);
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs);
        public static bool operator ==(Quaternion lhs, Quaternion rhs);
        public static bool operator !=(Quaternion lhs, Quaternion rhs);
    }
}