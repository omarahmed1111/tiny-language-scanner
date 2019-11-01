using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace scanner
{
    public class scanner1
    {
        string text;
        string cur_text;
        int cur_state;
        int output_no;
        string output;
        StreamWriter writer;
        public scanner1(string file_text,StreamWriter write)
        {
            text  = file_text;
            cur_state = 0;
            cur_text = "";
            writer = write;
            
        }
        public int scan()
        {
            for(int i = 0; i< text.Length; i++)
            {
                char cur = text[i];
                if (cur_state == 0)
                {
                    if(cur==' '||cur=='\n'||cur=='\t'||cur=='\r') { }
                    else if(cur == '{')
                    {
                        cur_state = 1;
                    }
                    else if (cur >= '0' && cur <= '9')
                    {
                        cur_text += cur;
                        cur_state = 2;
                    }
                    else if((cur >= 'a' && cur <= 'z') || (cur >= 'A' && cur <= 'Z'))
                    {
                        cur_text += cur;
                        cur_state = 3;
                    }
                    else if (cur == '/')
                    {
                        cur_text += cur;
                        writer.WriteLine("/ , Divide");
                        cur_text = "";
                        cur_state = 0;
                    }
                    else if(cur== '*')
                    {
                        cur_text += cur;
                        writer.WriteLine("* , Times");
                        cur_text = "";
                        cur_state = 0;
                    }
                    else if (cur == '+')
                    {
                        cur_text += cur;
                        writer.WriteLine("+ , Plus");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if(cur == '-')
                    {
                        cur_text += cur;
                        writer.WriteLine("- , Minus");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if (cur == '=')
                    {
                        cur_text += cur;
                        writer.WriteLine("= , Equal");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if(cur == '<')
                    {
                        cur_text += cur;
                        writer.WriteLine("< , Less than");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if(cur == '(')
                    {
                        cur_text += cur;
                        writer.WriteLine("( , Open parenthes");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if (cur == ')')
                    {
                        cur_text += cur;
                        writer.WriteLine(") , Close parenthes");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if (cur == ';')
                    {
                        cur_text += cur;
                        writer.WriteLine("; , Semicolon");
                        cur_state = 0;
                        cur_text = "";
                    }
                    else if (cur == ':')
                    {
                        cur_text += cur;
                        cur_state = 4;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (cur_state == 1)
                {
                    if (cur == '}')
                    {
                        cur_state = 0;
                    }
                    else { }
                }
                else if (cur_state == 2)
                {
                    if (cur >= '0' && cur <= '9')
                    {
                        cur_text += cur; 
                        cur_state = 2;
                    }
                    else
                    {
                        writer.WriteLine(cur_text + " , Number");
                        cur_text = "";
                        i--;
                        cur_state = 0;
                    }
                }
                else if (cur_state == 3)
                {
                    if((cur >= 'a' && cur <= 'z') || (cur >= 'A' && cur <= 'Z')||cur=='_'||(cur >= '0' && cur <= '9'))
                    {
                        cur_text += cur;
                        cur_state = 3;
                    }
                    else
                    {
                        //done
                        if (cur_text == "if")
                        {
                            writer.WriteLine(cur_text + " , IF");
                            cur_text = "";
                        }
                        else if (cur_text == "else")
                        {
                            writer.WriteLine(cur_text + " , ELSE");
                            cur_text = "";
                        }
                        else if(cur_text == "then")
                        {
                            writer.WriteLine(cur_text + " , THEN");
                            cur_text = "";
                        }
                        else if(cur_text == "end")
                        {
                            writer.WriteLine(cur_text + " , END");
                            cur_text = "";
                        }
                        else if(cur_text == "repeat")
                        {
                            writer.WriteLine(cur_text + " , REPEAT");
                            cur_text = "";
                        }
                        else if(cur_text == "until")
                        {
                            writer.WriteLine(cur_text + " , UNTIL");
                            cur_text = "";
                        }
                        else if(cur_text == "read")
                        {
                            writer.WriteLine(cur_text + " , READ");
                            cur_text = "";
                        }
                        else if(cur_text == "write")
                        {
                            writer.WriteLine(cur_text + " , WRITE");
                            cur_text = "";
                        }
                        else
                        {
                            writer.WriteLine(cur_text + " , IDENTIFIER");
                            cur_text = "";
                        }
                        i--;
                        cur_state = 0;
                    }
                }
                else if (cur_state == 4)
                {
                    if (cur == '=')
                    {
                        cur_text += cur;
                        cur_state = 0;
                        writer.WriteLine(cur_text + " , ASSIGN");
                        cur_text = "";
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
