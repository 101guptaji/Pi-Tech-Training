using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter a integer");
		int x;
		x=int.Parse(Console.ReadLine());
		Console.WriteLine(OddEven(x));
		
		
	}
	static string OddEven(int x){
		if(x%2==0){
			return "Even";
		}
		else
			return "Odd";
	}
}