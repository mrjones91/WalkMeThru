using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace WalkMeThruApp
{
	public class Family
	{
	
		bool canSing { get; set; }
		string Name { get; set; }

		public Family() { }

		public Family(string name, bool canSang)
		{
			Name = name;
			canSing = canSang;
		}

		public static string Sing()
		{
			return "This Family Sings";
		}

		public string iSing()
		{
			string singing = canSing == true ? 
				"sangs" : "doesn't sing";
			return Name + " " + singing;
		}

		public void Journal()
		{
			string journalPath = $"../../../{Name}-Journal.txt";
			try
			{
				if (!File.Exists(journalPath))
				{
					File.Create(journalPath);
				}
				using (StreamWriter sw = new StreamWriter(journalPath))
				{
					try
					{
						sw.WriteLine(DateTime.Now.ToString());
						sw.WriteLine(iSing());
					}
					catch(Exception e)
					{
						Console.WriteLine("StreamWriter Error");
						Console.WriteLine(e.ToString());
					}
					finally
					{
						sw.Close();
					}
					
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Journal Error");
				Console.WriteLine(e.ToString());
			}
			finally
			{
				
			}
			//DateTime.Now
		}
	}
}
