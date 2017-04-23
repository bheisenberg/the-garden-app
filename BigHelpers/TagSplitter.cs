using System.Collections;
using System.Collections.Generic;
using System; 

	public class TagSplitter
	{
		public List<string> tags; // List of tags 

		public TagSplitter(string hashTagString)
		{
			this.tags = new List<string>(); 
			string dynamicString = hashTagString;

			while(dynamicString.IndexOf("#") != -1)
			{
				// Obtain the values used for parsing the string
				int numberSignIndex = dynamicString.IndexOf("#");
				int spaceIndex = dynamicString.IndexOf(" "); 

				// First all the way to the last tag to parse 
				if(spaceIndex != -1)
				{
					// Obtain the tag 
					string singleTag = dynamicString.Substring(numberSignIndex + 1, spaceIndex-1); 

					// Change '#' tag 
					System.Text.StringBuilder dynamicCharacters = new System.Text.StringBuilder(dynamicString); 
					dynamicCharacters[numberSignIndex] = '*'; 
					dynamicCharacters[spaceIndex] = '_';

					this.tags.Add(singleTag); 
					dynamicString = dynamicCharacters.ToString(); 
				}
				// Last tag to parse
				else if (spaceIndex == -1) 
				{
					this.tags.Add(dynamicString.Substring(numberSignIndex + 1));  

					System.Text.StringBuilder dynamicCharacters = new System.Text.StringBuilder(dynamicString); 
					dynamicCharacters[numberSignIndex] = '*'; 
					dynamicString = dynamicCharacters.ToString(); 
				}
			}
		}

		public void Print_Tags()
		{
			for(int i = 0; i < this.tags.Count; i++)
			{
				Console.WriteLine(i + ") " + this.tags[i]); 
			}
		}
	}
