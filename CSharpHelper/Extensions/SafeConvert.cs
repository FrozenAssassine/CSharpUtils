using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHelper.Extensions
{
    public static class SafeConvert
    {
        /// <summary>
        /// Converts the given input to a double. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a double</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A double out of the given input value or the default value</returns>
        public static double ToDouble<T>(this T value, double defaultValue = 0)
        {
            if (value != null)
            {
                if (value is double res)
                    return res;

                if (double.TryParse(value.ToString(), out double converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to an int. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to an int</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>An int out of the given input value or the default value</returns>
        public static int ToInt<T>(this T value, int defaultValue = 0)
        {
            if (value != null)
            {
                if (value is int res)
                    return res;

                if (int.TryParse(value.ToString(), out int converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to a float. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a float</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A float out of the given input value or the default value</returns>
        public static float ToFloat<T>(this T value, float defaultValue = 0)
        {
            if (value != null)
            {
                if (value is float res)
                    return res;

                if (float.TryParse(value.ToString(), out float converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to a bool. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a bool</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A bool out of the given input value or the default value</returns>
        public static bool ToBool<T>(this T value, bool defaultValue = false)
        {
            if (value != null)
            {
                if (value is bool res)
                    return res;

                if (bool.TryParse(value.ToString(), out bool converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to a long. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a long</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A long out of the given input value or the default value</returns>
        public static long ToLong<T>(this T value, long defaultValue = 0)
        {
            if (value != null)
            {
                if (value is long res)
                    return res;

                if (long.TryParse(value.ToString(), out long converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to a byte. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a byte</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A byte out of the given input value or the default value</returns>
        public static byte ToByte<T>(this T value, byte defaultValue = 0)
        {
            if (value != null)
            {
                if (value is byte res)
                    return res;

                if (byte.TryParse(value.ToString(), out byte converted))
                    return converted;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the given input to a string. When it fails it returns the defaultValue
        /// </summary>
        /// <param name="value">The value to convert to a string</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>A string out of the given input value or the default value</returns>
        public static string ToString<T>(this T value, string defaultValue = "")
        {
            if (value == null)
                return defaultValue;

            if (value is string res)
                return res;

            return value.ToString() ?? defaultValue;
        }
        /// <summary>
        /// Converts the given input to an enum of the given type. When it fails it returns the defaultValue
        /// </summary>
        /// <typeparam name="TEnum">The type of enum</typeparam>
        /// <param name="value">The value to convert to enum</param>
        /// <param name="defaultValue">The value to return when an error occurs</param>
        /// <returns>An enum of the given type or the default value</returns>
        public static TEnum ToEnum<TEnum, T>(this T value, TEnum defaultValue) where TEnum : struct
        {
            if (value != null)
            {
                if (value is TEnum res)
                    return res;

                if (Enum.TryParse(typeof(TEnum), value.ToString(), out object? result))
                    return result == null ? defaultValue : (TEnum)result;
            }
            return defaultValue;
        }
    }
}
