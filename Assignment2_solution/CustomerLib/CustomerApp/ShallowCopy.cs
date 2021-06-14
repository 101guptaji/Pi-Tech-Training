using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{ 
	
	class ShallowCopy
	{

		// Main Method
		static void Main(string[] args)
		{

			Company c1 = new Company(548, "Pi tech",
										"Himasnhu Jain");

			// Performing Shallow copy					
			Company c2 = (Company)c1.Shallowcopy();

			Console.WriteLine("Before Changing: ");

			// Before changing the value of
			// c2 GBRank and CompanyName
			Console.WriteLine(c1.GBRank);
			Console.WriteLine(c2.GBRank);
			Console.WriteLine(c2.desc.CompanyName);
			Console.WriteLine(c1.desc.CompanyName);

			// changing the value of c2 GBRank
			// and CompanyName
			c2.GBRank = 59;
			c2.desc.CompanyName = "Intellect";

			Console.WriteLine("\nAfter Changing: ");

			// After changing the value of
			// c2 GBRank and CompanyName
			Console.WriteLine(c1.GBRank);
			Console.WriteLine(c2.GBRank);
			Console.WriteLine(c1.desc.CompanyName);
			Console.WriteLine(c2.desc.CompanyName);


			Console.WriteLine("\nAfter Changing by Deep Copy: ");

			// Performing Deep copy                             
			Company c3 = (Company)c1.DeepCopy();



			// After changing the value of
			// c3 GBRank and CompanyName
			Console.WriteLine(c1.GBRank);
			Console.WriteLine(c3.GBRank);
			Console.WriteLine(c1.desc.CompanyName);
			Console.WriteLine(c3.desc.CompanyName);
			Console.ReadLine();
		}
	}


	class Company
	{

		public int GBRank;
		public CompanyDescription desc;

		public Company(int gbRank, string c,
								string o)
		{
			this.GBRank = gbRank;
			desc = new CompanyDescription(c, o);
		}

		// method for cloning object
		public object Shallowcopy()
		{
			return this.MemberwiseClone();
		}

		// method for cloning object
		public Company DeepCopy()
		{
			Company deepcopyCompany = new Company(this.GBRank,
								desc.CompanyName, desc.Owner);
			return deepcopyCompany;
		}
	}


	class CompanyDescription
	{

		public string CompanyName;
		public string Owner;
		public CompanyDescription(string c, string o)
		{
			this.CompanyName = c;
			this.Owner = o;
		}
	}

}
