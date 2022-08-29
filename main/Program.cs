using System;
using System.IO;
using System.Text.RegularExpressions;  

namespace Program
{
    class Program
    {



//         bool isPunctuator(char ch)					//check if the given character is a punctuator or not
// {
//    foreach (var i in Constant.punctuator)
//    {
//     if (ch == i)
//     {
//         return true;
//     }else{
//         return false;
//     }
    
//    }
//    return false;
// }

// bool validIdentifier(String str)						//check if the given identifier is valid or not
// {
//     // Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");  
//     if (str[0] == '0' || str[0] == '1' || str[0] == '2' ||
//         str[0] == '3' || str[0] == '4' || str[0] == '5' ||
//         str[0] == '6' || str[0] == '7' || str[0] == '8' ||
//         str[0] == '9' || isPunctuator(str[0]) == true)
//         {
//             return false;
//         }									//if first character of string is a digit or a special character, identifier is not valid
//     int i,len = str.Length;
//     if (len == 1)
//     {
//         return true;
//     }										//if length is one, validation is already completed, hence return true
//     else
//     {
//     for (i = 1 ; i < len ; i++)						//identifier cannot contain special characters
//     {
//         if (isPunctuator(str[i]) == true)
//         {
//             return false;
//         }
//     }
//     }
//     return true;
// }

// bool isOperator(char ch)							//check if the given character is an operator or not
// {
//     if (ch == '+' || ch == '-' || ch == '*' ||
//         ch == '/' || ch == '>' || ch == '<' ||
//         ch == '=' || ch == '|' || ch == '&')
//     {
//        return true;
//     }
//     return false;
// }

// bool isKeyword(String str)						//check if the given substring is a keyword or not
// {
//      foreach (var i in Constant.keywords)
//    {
//     if (str == i)
//     {
//         return true;
//     }else{
//         return false;
//     }
    
//    }
//       foreach (var i in Constant.oopKeywords)
//    {
//     if (str == i)
//     {
//         return true;
//     }else{
//         return false;
//     }
//     }
//        foreach (var i in Constant.accessModifier)
//    {
//     if (str == i)
//     {
//         return true;
//     }else{
//         return false;
//     }
//     }
//        foreach (var i in Constant.dataTypes)
//    {
//     if (str == i)
//     {
//         return true;
//     }else{
//         return false;
//     }
//     }
//    return false;
// }

// bool isNumber(String str)							//check if the given substring is a number or not
// {
//     int i, len = str.Length,numOfDecimal = 0;
//     if (len == 0)
//     {
//         return false;
//     }
//     for (i = 0 ; i < len ; i++)
//     {
//         if (numOfDecimal > 1 && str[i] == '.')
//         {
//             return false;
//         } else if (numOfDecimal <= 1)
//         {
//             numOfDecimal++;
//         }
//         if (str[i] != '0' && str[i] != '1' && str[i] != '2'
//             && str[i] != '3' && str[i] != '4' && str[i] != '5'
//             && str[i] != '6' && str[i] != '7' && str[i] != '8'
//             && str[i] != '9' || (str[i] == '-' && i > 0))
//             {
//                 return false;
//             }
//     }
//     return true;
// }

// String subString(String realStr, int l, int r)				//extract the required substring from the main string
// {
//     // int i;

//     // String str = (String) malloc(sizeof(char) * (r - l + 2));

//     // for (i = l; i <= r; i++)
//     // {
//     //     str[i - l] = realStr[i];
//     //     str[r - l + 1] = '\0';
//     // }
//     // return str;
//     return "";
// }


// void parse(String str)						//parse the expression
// {
//     int left = 0, right = 0;
//     int len = str.Length;
//     while (right <= len && left <= right) {
//         if (isPunctuator(str[right]) == false)			//if character is a digit or an alphabet
//             {
//                 right++;
//             }

//         if (isPunctuator(str[right]) == true && left == right)		//if character is a punctuator
//             {
//             if (isOperator(str[right]) == true)
//             {
//                 Console.WriteLine(" IS AN OPERATOR\n");
//             }
//             right++;
//             left = right;
//             } else if (isPunctuator(str[right]) == true && left != right
//                    || (right == len && left != right)) 			//check if parsed substring is a keyword or identifier or number
//             {
//             String sub = subString(str, left, right - 1);   //extract substring

//             if (isKeyword(sub) == true)
//                         {
//                            Console.WriteLine( " IS A KEYWORD\n");
//                         }
//             else if (isNumber(sub) == true)
//                         {
//                             Console.WriteLine( sub +" IS A NUMBER\n");
//                         }
//             else if (validIdentifier(sub) == true
//                      && isPunctuator(str[right - 1]) == false)
//                      {
//                         Console.WriteLine(sub +" IS A VALID IDENTIFIER\n");
//                      }
//             else if (validIdentifier(sub) == false
//                      && isPunctuator(str[right - 1]) == false)
//                      {
//                          Console.WriteLine( sub +" IS NOT A VALID IDENTIFIER\n");
//                      }

//             left = right;
//             }
//     }
//     return;
// }

        static readonly string textFile = "assets/sample.txt"; 
        static void Main(String[] args){
             string text = File.ReadAllText(textFile);  
            //  Console.WriteLine(text);  
            //  Program program = new Program();
            //  program.parse(text);
            var tem = "";
            List<string> list = new List<string>();
            foreach (var i in text)
            {
                if (i == ' ')
                {

                    foreach (var j in Constant.keywords)
                    {
                        if (tem == j)
                        {
                            Console.WriteLine(tem + ":  KeyWord");
                        }
                    }
                    
                    list.Add(tem);
                    tem = "";
                }else{
                    tem += i;
                    
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item +"\n");
            }
        }
    
 
    }

}
