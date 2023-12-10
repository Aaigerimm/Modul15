using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modul15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExploreType<Class1>();
            CreateInstanceUsingReflection();
            ManipulateObject();
            InvokePrivateMethod();
        }
        static void ExploreType<T>()
        {
            Type type = typeof(T);

            Console.WriteLine($"Имя класса: {type.Name}");

            Console.WriteLine("Конструкторы:");
            foreach (var constructor in type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("Поля и свойства:");
            foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (member is FieldInfo field)
                    Console.WriteLine($"{field.FieldType} {field.Name}");
                else if (member is PropertyInfo property)
                    Console.WriteLine($"{property.PropertyType} {property.Name}");
            }

            Console.WriteLine("Методы:");
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{method.ReturnType} {method.Name}");
            }

            Console.WriteLine();
        }


        static void CreateInstanceUsingReflection()
        {
            Type type = typeof(Class1);
            object instance = Activator.CreateInstance(type);

            Console.WriteLine("Экземпляр Class1 создан с использованием рефлексии.");
            Console.WriteLine();
        }


        static void ManipulateObject()
        {
            Class1 myObject = new Class1();

            PropertyInfo publicProperty = typeof(Class1).GetProperty("PublicProperty");
            publicProperty.SetValue(myObject, 99);

            MethodInfo calculateSumMethod = typeof(Class1).GetMethod("CalculateSum");
            int result = (int)calculateSumMethod.Invoke(myObject, new object[] { 5, 7 });

            Console.WriteLine($"Измененное значение PublicProperty: {myObject.PublicProperty}");
            Console.WriteLine($"Результат вызова метода CalculateSum: {result}");
            Console.WriteLine();
        }


        static void InvokePrivateMethod()
        {
            Class1 myObject = new Class1();

            MethodInfo privateMethod = typeof(Class1).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(myObject, null);

            Console.WriteLine();
        }
    }
}
