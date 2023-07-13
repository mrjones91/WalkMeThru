using System.Xml.Linq;

namespace WalkMeThruApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Program newFamilyMember = new Program();
			Family Kelsee = new Family("Kelsee", true);
			Family.Sing();
			Kelsee.iSing();
			Family DJ = new Family("DJ", false);
			DJ.iSing();
			DJ.Journal();
			string journalPath = $"../../../{"DJ"}-Journal.txt";
			string journalContents = File.ReadAllText(journalPath);
			string[] journalLines = File.ReadAllLines(journalPath);
			Console.WriteLine(HelloWorld());
		}
		// a function that returns something...
		
		public static string HelloWorld()
		{
			return "Hello, World!";
		}
	}
}