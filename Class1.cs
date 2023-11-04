using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForwardChaining
{
    public class Class1
    {
        public List<string> facts = new List<string>();
        public List<string> rules = new List<string>();

        public void addFact()
        {
            Console.WriteLine("\nEnter a Fact: ");

            string newFact = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFact))
            {
                facts.Add(newFact);
            }
        }

        public void addRules()
        {
                Console.WriteLine("\nAdd a Rule: ");

                string newRule = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(newRule))
                {
                    rules.Add(newRule);
                }
        }

        public bool addNewFact()
        {
            List<string> temp = new List<string>();
            List<string> tf = facts.ToList();
            List<string> tr = rules.ToList();
            string wholeStatement = "";
            string tempFact = "";
            bool newFactAdded = false;
            int ctr = 0;

            foreach (string rule in tr)
            {
                ctr = 0;
                temp.Clear();
                string[] tokens = rule.Split(' ');

                for (int i = 0; i < tokens.Length; i++)
                {
                    string token = tokens[i];
                    wholeStatement = "";

                    if (token == "if" || token == "and" || token == "then")
                    {
                        for (int j = i+1; j < tokens.Length; j++)
                        {
                            string statement = tokens[j].Trim(',', '.', '!', '?', '(', ')');
                            if (tokens[j] == "and" || tokens[j] == "then")
                            {
                                i = j;
                                break;
                            }
                            wholeStatement += statement + " ";
                        }
                        wholeStatement = wholeStatement.TrimEnd();
                        if (!string.IsNullOrWhiteSpace(wholeStatement))
                        {
                            temp.Add(wholeStatement);
                        }
                    }
                }

                foreach (string tempStatement in temp)
                {
                    if (tf.Contains(tempStatement))
                    {
                        ctr++;
                    }
                }
                if (ctr == temp.Count - 1)
                {
                    tempFact = temp[temp.Count - 1];
                }

                if (!string.IsNullOrWhiteSpace(tempFact) && !tf.Contains(tempFact))
                {
                    facts.Add(tempFact);
                    newFactAdded = true;
                    tempFact = "";
                }
            }
            return newFactAdded;         
        }

        public void print()
        {
            Console.WriteLine("\n");
            foreach(string s in facts) 
            {
                Console.WriteLine(s);
            }
        }

        public void printR()
        {
            Console.WriteLine("\n");
            foreach (string r in rules)
            {
                Console.WriteLine(r);
            }
        }
    }
}
