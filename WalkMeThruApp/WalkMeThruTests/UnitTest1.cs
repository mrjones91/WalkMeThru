using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program = WalkMeThruApp.Program;
using WalkMeThruApp;
using System.Xml.Linq;

namespace WalkMeThruTests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			//How do I test?
			Assert.Equal(1, 1); 
			// Assert that parameter 1
			// is equal to
			// parameter 2
		}

		[Fact]
		public void TestHelloWorld()
		{ 
			Assert.Equal("Hello, World!", Program.HelloWorld());
		}

		[Fact]
		public void TestFamilySing()
		{
			Assert.Equal("This Family Sings", Family.Sing());
		}

		//comparitive testing logic
		//testing output
		[Theory]
		[InlineData("Jared", true, "Jared sangs")]
		[InlineData("Josh", true, "Josh sangs")]
		[InlineData("Jay", false, "Jay doesn't sing")]
		public void TestFamilyMemberiSing(string name, bool sings, string phrase)
		{
			Family testObject = new Family(name, sings);
			Assert.Equal(phrase, testObject.iSing());
		}

		//circular testing logic
		//- same logic from code is used to run the test
		[Theory]
		[InlineData("Jared", true)]
		[InlineData("Josh", true)]
		[InlineData("Jay", false)]
		public void cTestFamilyMemberiSing(string name, bool sings)
		{
			string singing = sings == true ?
				"sangs" : "doesn't sing";
			Family testObject = new Family(name, sings);
			Assert.Equal(name + " " + singing, testObject.iSing());
		}

		[Theory]
		[InlineData("Kris", true)]
		[InlineData("Eric", true)]
		[InlineData("Daron", true)]
		public void TestJournal(string name, bool sings)
		{
			//Create family members
			Family testObject = new Family(name, sings);
			//id the file location
			string journalPath = $"../../../{name}-Journal.txt";
			//create the file
			testObject.Journal();
			//read the file
			//string journalContents = File.ReadAllText(journalPath);
			string[] journalLines = File.ReadAllLines(journalPath);
			//run the test
			string testString = $"{DateTime.Now}\r\n{name} sangs";
			//Assert.Equal(testString, journalContents);
			Assert.Equal(testString.Split("\r\n"), journalLines);

		}
	}
}