//we will use the already built in Icomparable<T> interface.
//Icomparable<T> has the contract to implement compareto(Type other) method. 
//lets have two different objects of a class ans lets compare them 
using System.Runtime.InteropServices;

//accepting D-type? with the ? 

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
        //check if other is null ?
        if (other != null)
        {
            //compare the gpa's of the students 
            if(this.Gpa > other.Gpa)
            {
                return 1; 
            }
            else if (this.Gpa == other.Gpa)
            {
                return  0; 
            }
            return -1; 
        }
        throw new Exception();
    }
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