using System;
using System.IO;

public class SavingReadingFiles {
	public void Save(string s, string t)
	{
		using (StreamWriter sw = new StreamWriter(s)) 
		{
			sw.Write(t);
		}
	}
	
	public string Save(string s)
	{
		using (StreamReader sw = new StreamReader(s)) 
		{
			return sw.ReadLine();
		}
	}
}
