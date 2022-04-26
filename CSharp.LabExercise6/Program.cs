using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.LabExercise6
{
    class Validator
    {
        public string ValidInput
        {
            get => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        public bool IsValidInput(string word)
        {
            if(String.IsNullOrEmpty(word))
            {
                return false;
            }
            for(int i = 0; i < word.Length; i++)
            {
                if (!ValidInput.Contains(word[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }

    class DictionaryMaker
    {
        public DictionaryMaker(){}
        public Dictionary<int, string> SetValueForDictionary()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            dictionary.Add(1, "AEIOULNRST");
            dictionary.Add(2, "DG");
            dictionary.Add(3, "BCMP");
            dictionary.Add(4, "FHVWY");
            dictionary.Add(5, "K");
            dictionary.Add(8, "JX");
            dictionary.Add(10, "QZ");

            return dictionary;
        }     
    }
    class Scrable
    {
        Dictionary<int, string> dictionary;

        public Scrable(){}
        
        public int GetLetterValue(string letter)
        {
            foreach (KeyValuePair<int, string> pair in dictionary)
            {
                if (pair.Value.Contains(letter))
                {
                    return pair.Key;
                }
            }
            return 0;
        }
        public int GetWordValue(string word)
        {
            int sum = 0;
            for(int i = 0; i < word.Length; i++)
            {
                sum += GetLetterValue(word[i].ToString().ToUpper());

            }
            return sum; 
        }
        public void SetupDictionary()
        {
            DictionaryMaker dictionaryMaker = new DictionaryMaker();
            this.dictionary = dictionaryMaker.SetValueForDictionary();
        }
        public void Play()
        {
            SetupDictionary();
            
            do
            {
                Console.Write("Please Enter a word: ");
                string input = Console.ReadLine();

                Validator validator = new Validator();
                
                if (!validator.IsValidInput(input.ToUpper()))
                {
                    Console.WriteLine("Invalid Input. Please try again");
                    continue;
                }

                int value = GetWordValue(input);
                Console.WriteLine($"Score is: {value}");

                Console.WriteLine("Do you want to Continue? press y/n");
                string choice = Console.ReadLine();

                if(choice.ToLower() != "y")
                {
                    Console.WriteLine("Thank you for playing Scrable");
                    break;
                }

            }while (true);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Scrable scrable = new Scrable();
            scrable.Play();
        }
    }
}
