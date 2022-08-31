
    class Constant{
        public static  IDictionary<char, string> punctuators = new Dictionary<char, string>() {
            {'(', "("}, {')',")"}, {'{', "{"}, {'}', "}"}, {'[', "["}, {']', "]"}, {';',";"}, {'.', "."}, {',', ","},
            {'@', "lexical_error"}, {'$', "lexical_error"}, {'^', "lexical_error"}, {':', "lexical_error"}, {'?',"lexical_error"},
            {'`', "lexical_error"}, {'~', "lexical_error"}, {'\'', "lexical_error"}, {'_', "lexical_error"}, {'\\', "lexical_error"},
        };

          public static  IDictionary<string, string> operators = new Dictionary<string, string>() {
            {"+", "PlusMinus"}, {"-", "PlusMinus"},
            { "*", "MultipyDivide"}, {"/", "MultipyDivide"},
            { "<", "RelationalOperator"}, {">", "RelationalOperator"}, {"<=", "RelationalOperator"}, {">=", "RelationalOperator"}, {"!=", "RelationalOperator"}, {"==", "RelationalOperator"},
            {"=", "UnaryOperator"}, {"+=", "UnaryOperator"}, {"-=", "UnaryOperator"}, {"++", "UnaryOperator"}, {"--", "UnaryOperator"},
            {"&", "Lexeme error"}, {"|", "Lexeme error"},
            {"!", "Logical-Operator"}, {"||", "Logical-Operator"}, {"&&", "Logical-Operator"},
        };

        // dictionary for keyword list
         public static IDictionary<string, string> keywords = new Dictionary<string, string>(){
            {"int","datatype"}, {"float","data-type"}, {"bool","data-type"}, {"string","data-type"}, {"char", "data-type"},
            {"public","access-modifier"},{"private","access-modifier"},{"filePrivate","access-modifier"},{"open","access-modifier"},{"internal","access-modifier"}, {"static","static"}, {"class","class"},
            {"while","while"}, {"for","for"}, {"struct","struct" },{"abstract","abstract" },{"implement","inherit" },{"extends","inherit" },{"enum","enum" },
            {"if","if"}, {"else","else"}, {"break","break"}, {"continous","continous"},{"var","mutable-contant"},{"let","immutable-constant"},{"main","Main"},{"switch","Switch"},
            {"true","bool-const"}, {"false","bool-const"},
        };

        // dictionary for regex
         public static IDictionary<string, string> regexs = new Dictionary<string, string>() {
            {"integer", @"^\d*$"}, {"float", @"^[0-9]*(?:\.[0-9]*)?$"}, {"number", @"^[0-9]$"},
            {"alphabtes" , @"^[A-Za-z]$"}, {"identifier", @"^([a-zA-Z]+_[0-9])$"},
            {"punctuators", @"^,|.|;|[|]|(|)|{|}|:$"}, {"all_punctuators", @"^[\x20-\x2F]|[\x3A-\x40]|[\x5B-\x5E]|[\x7B-\x7E]|`$"}
        };
       }

       
