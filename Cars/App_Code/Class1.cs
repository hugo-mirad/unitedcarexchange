using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public Class1()
    {
        //
        // TODO: Add constructor logic here
        //
    }


}



/// <summary>
/// Stores signatures of various important methods related to the site.
/// </summary>
public interface ISiteInterface
{
    void Hi();
};

/// <summary>
/// Skeleton of the singleton that inherits the interface.
/// </summary>
class SiteStructure : ISiteInterface
{
    // Implements all ISiteInterface methods.
    // [omitted]
    public void Hi()
    {

    }
}
interface IFoo
{
string Message {get;}
}



/// <summary>
/// Here is an example class where we use a singleton with the interface.
/// </summary>
class TestClass
{
    ISiteInterface obj;
    

    /// <summary>
    /// Sample.
    /// </summary>
    public TestClass()
    {
        // Send singleton object to any function that can take its interface.
        SiteStructure site = new SiteStructure();
        CustomMethod((ISiteInterface)site);
    }

    /// <summary>
    /// Receives a singleton that adheres to the ISiteInterface interface.
    /// </summary>
    private void CustomMethod(ISiteInterface interfaceObject)
    {
        // Use the singleton by its interface.
    }
}




/// <summary>
/// Factory Pattern
/// </summary>

#region FactoryPatten


class Program
{
    abstract class Position
    {
        public abstract string Title { get; }
    }


    class Manager : Position
    {
        public override string Title
        {
            get
            {
                return "Manager";
            }
        }
    }

    class Clerk : Position
    {
        public override string Title
        {
            get
            {
                return "Clerk";
            }
        }
    }

    class Programmer : Position
    {
        public override string Title
        {
            get
            {
                return "Programmer";
            }
        }
    }

    static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Position Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Manager();
                case 1:
                case 2:
                    return new Clerk();
                case 3:
                default:
                    return new Programmer();
            }
        }
    }

    static void Main()
    {
        for (int i = 0; i <= 3; i++)
        {
            var position = Factory.Get(i);
            Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
        }
    }
}

#endregion FactoryPatten