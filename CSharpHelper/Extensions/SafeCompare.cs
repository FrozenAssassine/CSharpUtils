using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHelper.Extensions
{
    public static class SafeCompare
    {
        /// <summary>
        /// Returns true when the given object is the given class
        /// </summary>
        /// <typeparam name="TClass">The class to compare it to</typeparam>
        /// <param name="value">The object to compare to the class</param>
        /// <returns>True when it is the given class and false when it is not</returns>
        public static bool IsClass<TClass>(this object value) where TClass : class
        {
            if (value == null)
                return false;

            return value is TClass;
        }
        /// <summary>
        /// Returns true when the given object is the given struct
        /// </summary>
        /// <typeparam name="IsStruct">The struct to compare it to</typeparam>
        /// <param name="value">The object to compare to the struct</param>
        /// <returns>True when it is the given struct and false when it is not</returns>
        public static bool IsStruct<IsStruct>(this object value) where IsStruct : struct 
        {
            if (value == null)
                return false;

            return value is IsStruct;
        }
        /// <summary>
        /// Returns true when the given object is of the given enum
        /// </summary>
        /// <typeparam name="IsStruct">The enum to compare it to</typeparam>
        /// <param name="value">The object to compare to the enum</param>
        /// <returns>True when it is the given enum and false when it is not</returns>
        public static bool IsEnum<TEnum>(this object value) where TEnum : Enum
        {
            if (value == null)
                return false;

            return value is TEnum;
        }
        /// <summary>
        /// Returns true when the given object is of type int
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is an int and false when it is not</returns>
        public static bool IsInt(this object value)
        {
            if (value == null)
                return false;

            return value is int;
        }
        /// <summary>
        /// Returns true when the given object is of type float
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a float and false when it is not</returns>
        public static bool IsFloat(this object value)
        {
            if (value == null)
                return false;

            return value is float;
        }
        /// <summary>
        /// Returns true when the given object is of type double
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a double and false when it is not</returns>
        public static bool IsDouble(this object value)
        {
            if (value == null)
                return false;

            return value is double;
        }
        /// <summary>
        /// Returns true when the given object is of type bool
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a bool and false when it is not</returns>
        public static bool IsBool(this object value)
        {
            if (value == null)
                return false;

            return value is bool;
        }
        /// <summary>
        /// Returns true when the given object is of type byte
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a byte and false when it is not</returns>
        public static bool IsByte(this object value)
        {
            if (value == null)
                return false;

            return value is byte;
        }
        /// <summary>
        /// Returns true when the given object is of type long
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a long and false when it is not</returns>
        public static bool IsLong(this object value)
        {
            if (value == null)
                return false;

            return value is long;
        }
        /// <summary>
        /// Returns true when the given object is of type string
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a string and false when it is not</returns>
        public static bool IsString(this object value)
        {
            if (value == null)
                return false;

            return value is string;
        }
        /// <summary>
        /// Returns true when the given object is of type char
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is a char and false when it is not</returns>
        public static bool IsChar(this object value)
        {
            if (value == null)
                return false;

            return value is char;
        }
        /// <summary>
        /// Returns true when the given object is iterable
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is iterable and false when it is not</returns>
        public static bool IsIterable(this object value)
        {
            if (value == null)
                return false;

            if (value is Array) return true;

            return value.GetType().GetGenericArguments().Length > 0 && (typeof(ICollection<>).MakeGenericType(value.GetType().GetGenericArguments()[0])).IsAssignableFrom(value.GetType());
        }
        /// <summary>
        /// Returns true when the given object is of type array
        /// </summary>
        /// <param name="value">The object to compare to</param>
        /// <returns>True when the object is an array and false when it is not</returns>
        public static bool IsArray(this object value)
        {
            if (value == null)
                return false;

            return value is Array;
        }
    }
}
