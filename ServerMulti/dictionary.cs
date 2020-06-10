using System;
using System.Collections.Generic;

public class  dict{
    public string answer(string w){
        bool paul = true;
        Dictionary<string, string> replies = new Dictionary<string, string>() 
        {
            {"hej", "Hej med dig"},
            {"swift", "Er du dum!!!"},
            {"hvordan går det", "Hvad fuck vil du?!!"},
            {"måge", "Du er en ged sudo"},
            {"ged", "Geden knepper mågen"},
            {"bæltedyr", "Alexander hold kæft"}
        };

        string returnValue = "Hvad snakker du om?";
        string p = w.ToLower();
        string[] message = p.Split(" ");

        foreach(var word in message){
            if(replies.ContainsKey(word) && paul == true)
            {
                replies.TryGetValue(word, out returnValue);
                paul = false;
            }
        }      
        return returnValue;
    }
}
