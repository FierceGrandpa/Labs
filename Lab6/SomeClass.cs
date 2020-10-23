using System;

namespace Lab6
{
    #region Attribute

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UInfoAttribute : Attribute
    {
        public string Desc;
        public UInfoAttribute() { }
        public UInfoAttribute(string str)
        {
            Desc = str;
        }
    }

    #endregion

    public class SomeClass
    {
        public int SomeProperty1 { get; }

        [UInfo(Desc = "Некоторое свойство")]
        public string SomeProperty2 { get; set; }

        public SomeClass()
        {

        }
        public SomeClass(int a)
        {
            SomeProperty1 = a;
        }
        public SomeClass(string b)
        {
            SomeProperty2 = b;
        }
        public SomeClass(int a, string b)
        {
            SomeProperty1 = a;
            SomeProperty2 = b;
        }

        public void SomeMethod()
        {
            Console.WriteLine(SomeProperty2 ?? "Некоторый текст");
        }
    }
}