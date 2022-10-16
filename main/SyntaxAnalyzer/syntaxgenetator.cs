class SyntaxGenerator{
    
    String[] whileSelectionSet = {"while"};

    public void starting(ref Dictionary<int, Tuple<int, string, string>>  text){
        recognizeCFG(ref text, whileSelectionSet.ToList());

    }

    void loop(){

    }

    void recognizeCFG(ref Dictionary<int, Tuple<int, string, string>>  text ,List<string> listofSelectionsSet){
        for (int i = 1; i < text.Count ; i++){
            if (text[i].Item3 == listofSelectionsSet[0])
            {
               Console.WriteLine("Yes");
            }
        }
    }
}