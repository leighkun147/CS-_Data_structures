using System;
using System.ComponentModel;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
//same structute but with added params and this implementations, 
//clean constructor organisation achived
//custom list datatype 
//under the hood, its an array managed dynamically 
//dynamically managed list
//list self manages the capacity

public class CustomList
{
  public int this[int index]
    {
        get
        {
            if(index < 0 || index >= _ints.Length)
            {
                throw new IndexOutOfRangeException(); 
            }
            return _ints[index]; 
        }
        set
        {
            if(index < 0 || index > _ints.Length)
            {
                throw new IndexOutOfRangeException(); 
            }
            _ints[index]=value; 
        }
    }
   private int[]  _ints; 
   private int _count; 

   //three different ways of constructors 
 //first way, by default the user can have an instance by "new customlist"
   public CustomList():this(4)
    {
        //nothing left to do 
    }

   //the user can allocate a capacity to the list it custom way
   //this will be the main constructor that were going to use 
   public CustomList(int capacity)
   
       {
        //we use the capacity parameter 
        _ints= new int[capacity]; 
        _count=0; 
    } 
    //the user can also have memebers to instance
    public CustomList(params int[] numbers):this(numbers.Length)
    {
        //instance the ints array the same as the array thats given by the user
       /* _ints= new int[numbers.Length]; 
        _count= 0;   */ 
        //no need for all that thing
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
        CustomList list2= new CustomList(new int[] {1, 3, 4, 5});
          CustomList list3= new CustomList(1, 3, 4, 5);
        list.Add(1);
        list.Add(1);
        list.Add(1);
        list.Add(1);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
        list3.Add(3);
       System.Console.WriteLine($"{list.Length()}"); 
       System.Console.WriteLine($"{list2.Length()}");
       System.Console.WriteLine($"{list3.Length()}");
       System.Console.WriteLine($"{list3[14]}, {list3[2]}");
    }
}