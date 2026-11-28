//used Nullable<float> instead of float 
//used Icomparable generic and we added T accordingly

public interface Icomparablegeneric<T>
{
    int CompareMeWith(T obj); 
}
//lets say we will compare both names and gpa we hard code inside and with students
//with the names and gpa od the other students. so here icomparable will be used in three different ways
public class Student : Icomparablegeneric<string?>, Icomparablegeneric<float?>, Icomparablegeneric<Student>
{
    //define the student class 
    public string Name { get; set; }
    public Nullable<float> Gpa { get; set; }
    //constructor 
    public Student(string name, float gpa)
    {
        Name=name; 
        Gpa=gpa; 
    }
    //implementation of the three interfaces 
     public int CompareMeWith(string? input_name)
    {
        //compare this.Name with inout name implementation 
        //if the input is null by default we exit with 0 
        throw new ArgumentOutOfRangeException();

    }
    public int CompareMeWith(float? input_Gpa)
    {
        //compare this.Gpa with the input gpa implementation 
        //if the input is null by default we exit with 0 
        throw new ArgumentOutOfRangeException();

    }
    public int CompareMeWith(Student? student)
    {
        //compare the input student implemenation 
        //if the input is null by default we exit with 0 
         throw new ArgumentOutOfRangeException();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        
    }
}