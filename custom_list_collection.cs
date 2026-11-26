using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//custom list datatype 
//under the hood, its an array managed dynamically 
//to a list i must be able to add elements dynamically
//the list is self has to manage its length capacity bu

public class CustomList
{
   private int[]  _ints; 
   private int _count; 

   //three different ways of constructors 
 //first way, by default the user can have an instance by "new customlist"
   public CustomList()
    {
        //4 is the capacity by default
        _ints= new int[4];    
        //
        _count=0; 
    }

   //the user can allocate a capacity to the list it custom way
   public CustomList(int capacity)
    {
        //we use the capacity parameter 
        _ints= new int[capacity]; 
        _count=0; 
    }
    //the user can also have memebers to instance
    public CustomList(int[] numbers)
    {
        //instance the ints array the same as the array thats given by the user
        _ints= new int[numbers.Length]; 
        _count= 0; 
        for(int i=0; i < numbers.Length; i++)
        {
            //assign the elements of the array 
            _ints[i]=numbers[i];
            _count++; 
        }
    }
   //a method to add to the list.
   public void Add(int number)
    {
        if(_count < _ints.Length){
         //to append the number in to the array 
            _ints[_count]= number;    
        _count++; 
        }else
        {
            //doubgle the size of the _ints array 
        this.Resize(); 
        _ints[_count]= number;    
         _count++;
        }
    }
    public int Length()
    {
        return _count; 
    }
    private void Resize()
    {
       //it takes a look at the size of the array 
       //it creates a new array with the double of the size and 
       //assigs that array to the _ints property 
       int doubled_capacity= _ints.Length*2; 
       int[] newarray= new int[doubled_capacity]; 
       for(int i=0; i<_ints.Length ; i++)
        {
            newarray[i]=_ints[i]; 
            //assign half of the values to the array 
        } 
        //then now the new array has been built 
        _ints=newarray; 
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        CustomList list= new CustomList(10); 
        list.Add(1);
        list.Add(1);
        list.Add(1);
        list.Add(1);
       System.Console.WriteLine($"{list.Length()}"); 
    }
}