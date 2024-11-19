# CSharpUtils - Utility Functions for C#

[![GitHub Stars](https://img.shields.io/github/stars/FrozenAssassine/CSharpUtils?style=flat)](https://github.com/FrozenAssassine/CSharpUtils/stargazers)
[![GitHub PRs](https://img.shields.io/github/issues-pr/FrozenAssassine/CSharpUtils?style=flat)](https://github.com/FrozenAssassine/CSharpUtils/pulls)
[![Repo Size](https://img.shields.io/github/repo-size/FrozenAssassine/CSharpUtils?style=flat)](https://github.com/FrozenAssassine/CSharpUtils)

## 🤔 What is this project?
CSharpUtils is my collection of utility functions and extensions for C#. I made it to simplify common programming tasks. Since I kept reusing these utilities in different projects, I decided to combine them into one library to make them easier to use and share.

## 🛠️ Features

### EnumerableExtension
```csharp
public static int CountWords(this IEnumerable<string> items)
public static int CountCharacters(this IEnumerable<string> items)
public static int LongestStringIndex(IEnumerable<string> items)
public static string ToString(this IEnumerable<string> items, string separator)
```

### SafeCompare
```cs
public static bool IsClass<TClass>(this object value) where TClass : class
public static bool IsStruct<IsStruct>(this object value) where IsStruct : struct
public static bool IsEnum<TEnum>(this object value) where TEnum : Enum
public static bool IsInt<T>(this T value)
public static bool IsFloat<T>(this T value)
public static bool IsDouble<T>(this T value)
public static bool IsBool<T>(this T value)
public static bool IsByte<T>(this T value)
public static bool IsLong<T>(this T value)
public static bool IsString<T>(this T value)
public static bool IsChar<T>(this T value)
public static bool IsIterable<T>(this T value)
public static bool IsArray<T>(this T value)
```

### SafeConvert
```cs
public static double ToDouble<T>(this T value, double defaultValue = 0)
public static int ToInt<T>(this T value, int defaultValue = 0)
public static float ToFloat<T>(this T value, float defaultValue = 0)
public static bool ToBool<T>(this T value, bool defaultValue = false)
public static long ToLong<T>(this T value, long defaultValue = 0)
public static byte ToByte<T>(this T value, byte defaultValue = 0)
public static string ToString<T>(this T value, string defaultValue = "")
public static TEnum ToEnum<TEnum, T>(this T value, TEnum defaultValue) where TEnum : struct
```

### SafeString
```cs
public static string SafeSubstring(this string str, int start, int length)
public static string SafeSubstring(this string str, int start)
public static string SafeRemove(this string str, int start, int length)
public static string SafeRemove(this string str, int start)
public static int IndexOfRegex(this string str, string pattern, int start, RegexOptions options)
public static int IndexOfRegex(this string str, string pattern, int start)
public static int IndexOfRegex(this string str, string pattern)
public static int IndexOfRegex(this string str, string pattern, RegexOptions options)
public static int[] AllIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
public static int[] AllIndexOfRegex(this string str, string pattern, int start)
public static int[] AllIndexOfRegex(this string str, string pattern)
public static int[] AllIndexOfRegex(this string str, string pattern, RegexOptions options)
public static int LastIndexOfRegex(this string str, string pattern, int start, RegexOptions options)
public static int LastIndexOfRegex(this string str, string pattern, int start)
public static int LastIndexOfRegex(this string str, string pattern)
public static int LastIndexOfRegex(this string str, string pattern, RegexOptions options)
public static string SafeInsert(this string str, int startIndex, string value)
public static string ReplaceRange(this string str, int startIndex, int length, string value)
```

### StringExtension
```cs
public static int CountWords(this string text)
public static string Repeat(this string text, int count)
```
