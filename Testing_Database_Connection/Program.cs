using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

public class ServerClass
{

    static int count = 0;
    // The method that will be called when the thread is started.
    public void InstanceMethod()
    {
        Console.WriteLine(
            "ServerClass.InstanceMethod is running on another thread.");

        int data = count++;
        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(3000);
        Console.WriteLine(
            "The instance method called by the worker thread has ended. " + data);
    }
}

public class Program
{
    public static void Main()
    {
        /*        for (int i = 0; i < 10; i++)
                {
                    CreateThreads();
                }
                Task task = Task.Factory.StartNew(CreateThreads);*/
        DateTime now = DateTime.Now;
        Task<string> someString = Task.Factory.StartNew( () =>
        {
            Console.WriteLine("Something else");
            
            return "100";
        }
        );
        Console.WriteLine("Do something meanwhile");
        Console.WriteLine("{0} is the result of awaitng async method after {1}", someString.Result, DateTime.Now - now);
        Func<string, string> allMethods = DelegateMethod;
        allMethods += DelegateMethod;
        allMethods += DelegateMethod1;
        allMethods += DelegateMethod2;
        allMethods += (x) => "Nothing Concrete";
        string asd = string.Empty;
        foreach (Func<string, string> item in allMethods.GetInvocationList().Reverse())
        {
            Console.WriteLine(item("Concrete method delegate"));
        }
        List<string> dir = new List<string>();
        dir.Add(Directory.GetCurrentDirectory());
        dir.Add(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));
        dir.Add(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
        dir.Add(Environment.CommandLine);
        dir.Add(Environment.NewLine);
        Environment.SetEnvironmentVariable("key1","value1");
        dir.Add(Environment.GetEnvironmentVariable("key1"));
        dir.Add(Environment.CurrentDirectory);
        Thread thread = new Thread(() => Console.WriteLine("Additional thread"));
        thread.Name = "Very important thread";

        foreach (var item in dir)
        {
            Console.WriteLine(item);
        }
    }

    public static string SomeString()
    {

        Console.WriteLine("Something else");

        return "100";
    }

    public delegate string Volcano();

    public static string DelegateMethod(string value)
    {
        return "1" + value;
    }

    public static string DelegateMethod1(string value)
    {
        return "2" + value;
    }

    public static string DelegateMethod2(string value)
    {
        return "3" + value;
    }





    public static void CreateThreads()
    {
        ServerClass serverObject = new ServerClass();

        Thread InstanceCaller = new Thread(new ThreadStart(serverObject.InstanceMethod));
        // Start the thread.
        InstanceCaller.Start();

        Console.WriteLine("The Main() thread calls this after "
            + "starting the new InstanceCaller thread.");

    }
}