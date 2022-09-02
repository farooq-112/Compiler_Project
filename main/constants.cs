
    class Constant{
    //    public static string[] dataTypes = {"int", "long", "float", "double", "char", "String"};
    //     public static string[] keywords = {" : ", " , ","for", "func", "return", "final", "void", "switch","continue","default","try","catch","static","self","if","else","case","main","let","var","init","throw","is","while","typealiase"};
    //     public static string[] accessModifier = {"public" , "open", "private", "filePrivate", "internal"};
    //     public static string[] oopKeywords = {"class" , "struct", "enum", "protocol", "abstract"};
    //     public static char[] arithematic = {'+', '-', '*', '/', '%'};
    //     public static string[] comparison = {"==", "<=", ">=", "!=", ">", "<"};
    //     public static string[] logical = {"&&", "||"};
    //     public static string[] uniary = {"!", "--", "++", "+="};
    //     public static char[] punctuator = {'(', ')', '{', '}', ',', ':', '.', '[', ']', '"', ';', '-'}; 

    public IDictionary<char, string> punctuators = new Dictionary<char, string>() {
            {'(', "("}, {')',")"}, {'{', "{"}, {'}', "}"}, {'[', "["}, {']', "]"}, {';',";"}, {'.', "."}, {',', ","},
            {'@', "lexical_error"}, {'$', "lexical_error"}, {'^', "lexical_error"}, {':', "lexical_error"}, {'?',"lexical_error"},
            {'`', "lexical_error"}, {'~', "lexical_error"}, {'\'', "lexical_error"}, {'_', "lexical_error"}, {'\\', "lexical_error"},
        };

        // Operators
        // dictionary for operators and its classpart
        public IDictionary<string, string> operators = new Dictionary<string, string>() {
            {"+", "PM"}, {"-", "PM"},
            { "*", "MD"}, {"/", "MD"},
            { "<", "RO"}, {">", "RO"}, {"<=", "RO"}, {">=", "RO"}, {"!=", "RO"}, {"==", "RO"},
            {"=", "AO"}, {"+=", "AO"}, {"-=", "AO"},
            {"&", "Lexeme error"}, {"|", "Lexeme error"},
            {"!", "LO"}, {"||", "LO"}, {"&&", "LO"},
        };

        // dictionary for keyword list
        public IDictionary<string, string> keywords = new Dictionary<string, string>(){
            {"int","dt"}, {"float","dt"}, {"bool","dt"}, {"string","dt"},
            {"public","access-modifier"}, {"static","static"}, {"class","class"},
            {"while","while"}, {"for","for"}, {"struct","struct" },
            {"if","if"}, {"else","else"}, {"break","break"}, {"continous","continous"},
            {"true","bool-const"}, {"false","bool-const"},
        };

        // dictionary for regex
        public IDictionary<string, string> regexs = new Dictionary<string, string>() {
            {"integer", @"^\d*$"}, {"float", @"^(\d*.\d+|\d*[^.])$"}, {"number", @"^[0-9]$"},
            {"alphabtes" , @"^[A-Za-z]$"}, {"identifier", @"^([a-zA-Z]+_[0-9])$"},
            {"punctuators", @"^,|.|;|[|]|(|)|{|}|:$"}, {"all_punctuators", @"^[\x20-\x2F]|[\x3A-\x40]|[\x5B-\x5E]|[\x7B-\x7E]|`$"}
        };
       }
