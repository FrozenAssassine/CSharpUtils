using CSharpHelper;
using CSharpHelper.Extensions;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        //SafeConvert:
        Console.WriteLine("SafeConvert:");
        Console.WriteLine("ToDouble: " + "5".ToDouble());
        Console.WriteLine("ToFloat: " + "10".ToFloat());
        Console.WriteLine("ToInt: " + "15".ToInt());
        Console.WriteLine("ToBool: " + "true".ToBool());
        Console.WriteLine("ToLong: " + "124012412312321301204124".ToLong());
        Console.WriteLine("ToByte: " + "50".ToByte());

        //SafeCompare:
        Console.WriteLine("\nSafeCompare:");
        Console.WriteLine("IsClass: " + new TestClass().IsClass<TestClass>());
        Console.WriteLine("IsStruct: " + new TestStruct().IsStruct<TestStruct>());
        Console.WriteLine("IsEnum: " + TestEnum.Value.IsEnum<TestEnum>());
        Console.WriteLine("IsBool: " + true.IsBool());
        Console.WriteLine("IsByte: " + ((byte)5).IsByte());
        Console.WriteLine("IsDouble: " + 5.0.IsDouble());
        Console.WriteLine("IsFloat: " + 1.0f.IsFloat());
        Console.WriteLine("IsInt: " + 10.IsInt());
        Console.WriteLine("IsLong: " + ((long)100).IsLong());
        Console.WriteLine("IsIterable<int>: " + new int[] { 0,10,0,0 }.IsIterable());
        Console.WriteLine("IsIterable<List>: " + new List<int> { 0,10,0,0 }.IsIterable());


        //Wrong values:
        Console.WriteLine("\n\nWrong:");
        Console.WriteLine("Convert:");
        Console.WriteLine("ToDouble: " + "a5".ToDouble());
        Console.WriteLine("ToFloat: " + "b10".ToFloat());
        Console.WriteLine("ToInt: " + "c15".ToInt());
        Console.WriteLine("ToBool: " + "dtrue".ToBool());
        Console.WriteLine("ToLong: " + "e124012412312321301204124".ToLong());
        Console.WriteLine("ToByte: " + "f50".ToByte());

        Console.WriteLine("\nCompare:");
        Console.WriteLine("IsClass: " + new TestStruct().IsClass<TestClass>());
        Console.WriteLine("IsStruct: " + TestEnum.Value.IsStruct<TestStruct>());
        Console.WriteLine("IsEnum: " + new TestClass().IsEnum<TestEnum>());
        Console.WriteLine("IsBool: " + "1".IsBool());
        Console.WriteLine("IsByte: " + "1".IsByte());
        Console.WriteLine("IsDouble: " + "1".IsDouble());
        Console.WriteLine("IsFloat: " + "1".IsFloat());
        Console.WriteLine("IsInt: " + "1".IsInt());
        Console.WriteLine("IsLong: " + "1".IsLong());
        Console.WriteLine("IsIterable: " + "1".IsIterable());

        //SafeString
        string testData = "Hello World";
        Console.WriteLine("\n\nSafeString:");
        Console.WriteLine("SafeSubstring:" + testData.SafeSubstring(0, 5));
        Console.WriteLine("SafeSubstring:" + testData.SafeSubstring(5, 15));
        Console.WriteLine("SafeSubstring:" + testData.SafeSubstring(20, 50));
        Console.WriteLine("SafeSubstring:" + testData.SafeSubstring(-20, -50));

        Console.WriteLine("SafeRemove:" + testData.SafeRemove(0, 5));
        Console.WriteLine("SafeRemove:" + testData.SafeRemove(5, 15));
        Console.WriteLine("SafeRemove:" + testData.SafeRemove(20, 50));
        Console.WriteLine("SafeRemove:" + testData.SafeRemove(-20, -50));

        string regexTestData = "Hello World 12345 12345 12 15";
        Console.WriteLine("IndexOfRegex: " + regexTestData.IndexOfRegex("(1|2)"));
        Console.WriteLine("AllIndexOfRegex: " + string.Join(", ", regexTestData.AllIndexOfRegex("(1|2)")));
        Console.WriteLine("LastIndexOfRegex: " + regexTestData.LastIndexOfRegex("(1|2)"));
        
        
        Console.WriteLine("ReplacePosition: " + regexTestData.ReplaceRange(0, 5, "Julius"));

        Console.ReadLine();
    }
    public class TestClass
    {

    }
    public struct TestStruct
    {

    }
    public enum TestEnum
    {
        Value
    }
}