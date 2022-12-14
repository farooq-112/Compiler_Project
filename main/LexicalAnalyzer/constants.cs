 class Constant{
        public static  IDictionary<string, string> punctuators = new Dictionary<string, string>() {
            {"(", "("}, {")",")"}, {"{", "{"}, {"}", "}"}, {"[", "["}, {"]", "]"}, {";","semi-colon"}, {".", "dot"}, {",", "comma"},
            {"@", "lexical_error"},{"^", "lexical_error"}, {":", "colon"}, {"?","lexical_error"},
            {"`", "lexical_error"}, {"~", "lexical_error"}, {"\'", "lexical_error"}, {"_", "lexical_error"}, {"\\", "lexical_error"},{"$", "end-mark"}
        };

          public static  IDictionary<string, string> operators = new Dictionary<string, string>() {
            {"+", "PlusMinus"}, {"-", "PlusMinus"},
            { "*", "MultipyDivide"}, {"/", "MultipyDivide"},
            { "<", "RelationalOperator"}, {">", "RelationalOperator"}, {"<=", "RelationalOperator"}, {">=", "RelationalOperator"}, {"!=", "RelationalOperator"}, {"==", "RelationalOperator"},
            {"=", "UnaryOperator"}, {"+=", "UnaryOperator"}, {"-=", "UnaryOperator"}, {"++", "inc-dec"}, {"--", "inc-dec"},
            {"&", "Lexeme error"}, {"|", "Lexeme error"},
            {"!", "Logical-Operator"}, {"||", "Logical-Operator"}, {"&&", "Logical-Operator"},
        };

        // dictionary for keyword list
        public static IDictionary<string, string> dataTypes = new Dictionary<string, string>(){
            {"int","data-type"}, {"float","data-type"}, {"bool","data-type"}, {"string","data-type"}, {"char", "data-type"}};
            public static Dictionary<string,string> accessModifier = new Dictionary<string, string>(){
            {"public","access-modifier"},{"private","access-modifier"},{"filePrivate","access-modifier"},{"open","access-modifier"},{"internal","access-modifier"}
            };
         public static IDictionary<string, string> keywords = new Dictionary<string, string>(){
             {"final","final"}, {"static","static"}, {"class","class"},{"init","init"},{"deinit","deinit"},
            {"while","while"}, {"for","for"}, {"struct","struct" },{"abstract","abstract" },{"implements","keyword" },{"extends","keyword" },{"enum","enum" },
            {"if","if"}, {"else","else"}, {"break","break"}, {"continous","continous"},{"var","mutable-constant"},{"let","immutable-constant"},{"Main","Main"},{"switch","Switch"},
            {"true","bool-const"}, {"false","bool-const"}, {"protocol","interface"}, {"case","keyword"}, {"default","keyword"},{"continue","continue"}, {"func","func"}, {"->","ret-type"}
        };

        // dictionary for regex
         public static IDictionary<string, string> regexs = new Dictionary<string, string>() {
            {"int", @"^[0-9]+$"}, {"float",  @"^[0-9]+(?:\.[0-9]*)?$"}, {"char", @"[a-z].*\d|\d.*[a-z]"}, {"string",@"[abc]+"},
            {"alphabtes" , @"^[A-Za-z]$"}, {"identifier", @"^([A-Za-z][A-Za-z_0-9]*)$"},
            {"punctuators", @"^,|.|;|[|]|(|)|{|}|:$"}, {"all_punctuators", @"^[\x20-\x2F]|[\x3A-\x40]|[\x5B-\x5E]|[\x7B-\x7E]|`$"}
        };
       }
