
//we will use the already built in Icomparable<T> interface.
//Icomparable<T> has the contract to implement compareto(Type other) method. 
//lets have two different objects of a class ans lets compare them 
using System.Runtime.InteropServices;

//accepting D-type? with the ? 
//here we will use the fact that strings and ints are data types/ classes which implement the icomparable
//interface to our advanatage to make the method smaller
public class Student:IComparable<Student>
{

    private string Name
    {
        get; init; 
    }
    private int _gpa; 
    public int Gpa
    {
        get
        {
           return _gpa; 
        }
        set
        {
            _gpa=value; 
        }
    }
    public Student(string name, int gpa)
    {
        Name=name; 
        _gpa=gpa;
    }

public int CompareTo(Student? other)
{
    if (other == null) return 1;
    return this.Gpa.CompareTo(other.Gpa);
}

public class Program
{
    public static void Main (string[] args)
    {
        //create two opjects 
        //use the compare to method to get the result 
        //obj1 
        Student student1=new Student("frwerfwe", 3);
        Student student2=new Student("rffwe", 4);
        Console.WriteLine($"{student1.CompareTo(student2)}");  
    }
}
}