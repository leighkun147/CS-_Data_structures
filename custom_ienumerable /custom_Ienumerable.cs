using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
//same structute but with added params and this implementations, 
//clean constructor organisation achived
//custom list datatype 
//under the hood, its an array managed dynamically 
//dynamically managed list
//list self manages the capacity


public interface IcustomEnumerable
{
    //the class must get its current position 
    //if there is next 
    //actually go next 
    int current{get;}
    bool Movenext(); 
    void Reset(); 
}
public class CustomList:IcustomEnumerable
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
    private int _current=0; 
    public int Current
    {
        get
        {
            return _current;
        }
    }
    public bool Movenext()
    {
        if (_current < _count-1)
        {
            return true;
        }
        else return false; 
    }
    public void Reset()
    {
        if (this.Movenext())
        {
            _current++;
        }else throw new ArgumentOutOfRangeException();
    }
    //designing the foreach method 
    //foreach(T item in _items){  //the function block}
    
}
public class Program
{
    public static void Main(string[] args)
    {
        
    }
}
