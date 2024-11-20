//David Barlow 11/19/24 lab-10-mad-libs-2
using System.Diagnostics;

class Program {
    static void Main(string[] filenames) 
    {
        Random rand = new Random();
        List<string> noun = new List<string> () {"fortune","wolf","happiness","flock","rose","gold","cookie","sheep","money","wish"};
        List<string> ProperNoun = new List<string>() {"Dionyssus","Microsoft","Phrygia","Monday","Harry Potter","President Jefferson","Christmas","Paris","Ocean","United States"};
        List<string> adjective = new List<string>(){"excited","beautiful","greatest","energetic","hungry","sure","rich","sorry","scared","greedy"};
        List<string> adverb = new List<string>(){"very","then","always","cheerfully","fast","accordingly","almost","carefully","certainly","consequently"};
        List<string> periodOfTime = new List<string>(){"day","year","week","second","minute","hour","millennium","fortnight","decade","century"};
        List<string> verbEndingInING = new List<string>() {"counting","liking","shopping","stroking","cleaning","drawing","flying","cooking","gambling","growing"};
        List<string> verb = new List<string>() {"come","be","have","do","say","go","buy","think","take","make"};
        List<string> pluralNoun = new List<string>() {"animals","coins","things","rivers","knives","leaves","boats","classes","sandwiches","benches"};
        List<string> bodyPart = new List<string>() {"hands","eyes","ears","kidneys","lungs","nostrils","arms","legs","feet","arms"};
        List<string> pastTenseVerb = new List<string>() {"tried","touched","played","worked","rested","cooked","walked","baked","studied","stopped"};

        Dictionary<string,List<string>> words = new Dictionary<string, List<string>>();

        words.Add("noun",noun);
        words.Add("Proper-Noun",ProperNoun);
        words.Add("adjective", adjective);
        words.Add("adverb",adverb);
        words.Add("period-of-time",periodOfTime);
        words.Add("verb-ending-in-ing",verbEndingInING);
        words.Add("verb",verb);
        words.Add("plural-noun",pluralNoun);
        words.Add("body-parts",bodyPart);
        words.Add("past-tense-verb",pastTenseVerb);

        Console.Clear();

        string story1 = File.ReadAllText("story1.txt");
        string newStory1 = "";
        string story2 = File.ReadAllText("story2.txt");
        string newStory2 = "";

        string[] story1Words = story1.Split(' ');
        string[] story2Words = story2.Split(' ');



        for(int i =0; i<story1Words.Count(); i++)
        {
            char punctuation = '\0';
            bool isReplaceWord = story1Words[i].Contains("::");
            if(isReplaceWord == true)
            {
                string partOfSpeech1 = story1Words[i].Split("::")[1];

                if(".?!".Contains(partOfSpeech1[partOfSpeech1.Length-1]))
                {
                    punctuation = partOfSpeech1[partOfSpeech1.Length-1];
                    //Console.Write(punctuation);
                    partOfSpeech1 = partOfSpeech1.Substring(0, partOfSpeech1.Length-1);
                    story1Words[i] = words[partOfSpeech1][rand.Next(0,10)] + punctuation;
                }else
                {
                    story1Words[i] = words[partOfSpeech1][rand.Next(0,10)];
                }

            }
            //Console.Write($"{story1Words[i]} ");
            newStory1 = newStory1 + story1Words[i] + " ";
        }
        //Console.Write(newStory1);
        //Console.WriteLine();
        //File.WriteAllText("generated-story1.txt", newStory1);


        for(int i =0; i<story2Words.Count(); i++)
        {
            char punctuation = '\0';
            bool isReplaceWord = story2Words[i].Contains("::");
            if(isReplaceWord == true)
            {
                string partOfSpeech2 = story2Words[i].Split("::")[1];
                if(".?!".Contains(partOfSpeech2[partOfSpeech2.Length-1]))
                {
                    punctuation = partOfSpeech2[partOfSpeech2.Length-1];
                    //Console.Write(punctuation);
                    partOfSpeech2 = partOfSpeech2.Substring(0, partOfSpeech2.Length-1);
                    story2Words[i] = words[partOfSpeech2][rand.Next(0,10)] + punctuation;
                }else
                {
                    story2Words[i] = words[partOfSpeech2][rand.Next(0,10)];
                }

            }
            //Console.Write($"{story2Words[i]} ");
            newStory2 = newStory2 + story2Words[i] + " ";
        }
        //Console.WriteLine();
        //Console.Write(newStory2);
        //Console.WriteLine();
        //File.WriteAllText("generated-story2.txt", newStory2);


        File.WriteAllText($"generated-{filenames[0]}.txt", newStory1);
        File.WriteAllText($"generated-{filenames[1]}.txt", newStory2);
    }
}


