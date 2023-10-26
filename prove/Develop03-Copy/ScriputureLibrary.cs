﻿namespace Develop03;


public class ScriptureGenerator
{
    private List<Dictionary<Reference, string>> scriptureLibrary = new List<Dictionary<Reference, string>>();

    public ScriptureGenerator()
    {
        // Create and initialize 20 default scriptures
        for (int i = 0; i < 20; i++)
        {
            Dictionary<Reference, string> library = new Dictionary<Reference, string>
            {
                { new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life." },
                { new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want." },
                { new Reference("Proverbs", 3, 5), "Trust in the Lord with all your heart, and lean not on your own understanding." },
                { new Reference("Isaiah", 40, 31), "But they that wait upon the Lord shall renew their strength; they shall mount up with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint." },
                { new Reference("Matthew", 28, 19), "Go ye therefore, and teach all nations, baptizing them in the name of the Father, and of the Son, and of the Holy Ghost." },
                { new Reference("1 Corinthians", 13, 4), "Love is patient, love is kind. It does not envy, it does not boast, it is not proud." },
                { new Reference("Genesis", 1, 1), "In the beginning, God created the heavens and the earth." },
                { new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose." },
                { new Reference("Ephesians", 2, 8), "For by grace are ye saved through faith; and that not of yourselves: it is the gift of God." },
                { new Reference("Psalm", 19, 14), "Let the words of my mouth, and the meditation of my heart, be acceptable in thy sight, O Lord, my strength, and my redeemer." },
                { new Reference("Proverbs", 4, 23), "Keep thy heart with all diligence; for out of it are the issues of life." },
                { new Reference("Jeremiah", 29, 11), "For I know the thoughts that I think toward you, saith the Lord, thoughts of peace, and not of evil, to give you an expected end." },
                { new Reference("John", 14, 6), "I am the way, the truth, and the life: no man cometh unto the Father, but by me." },
                { new Reference("Romans", 12, 2), "And be not conformed to this world: but be ye transformed by the renewing of your mind, that ye may prove what is that good, and acceptable, and perfect, will of God." },
                { new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me." },
                { new Reference("Psalm", 51, 10), "Create in me a clean heart, O God; and renew a right spirit within me." },
                { new Reference("Colossians", 3, 23), "And whatsoever ye do, do it heartily, as to the Lord, and not unto men." },
                { new Reference("1 Peter", 5, 7), "Casting all your care upon him; for he careth for you." },
                { new Reference("2 Timothy", 1, 7), "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind." },
                { new Reference("Revelation", 21, 4), "And God shall wipe away all tears from their eyes; and there shall be no more death, neither sorrow, nor crying, neither shall there be any more pain: for the former things are passed away." },

            };

            scriptureLibrary.Add(library);
        }
    }

    public Tuple<Reference, string> GetRandomScripture()
    {
        Random random = new Random();
        int libraryIndex = random.Next(scriptureLibrary.Count);
        Dictionary<Reference, string> scriptureDict = scriptureLibrary[libraryIndex];

        // Choose a random scripture from the selected library
        int scriptureIndex = random.Next(scriptureDict.Count);
        KeyValuePair<Reference, string> selectedScripture = scriptureDict.ElementAt(scriptureIndex);

        // The selectedScripture is a KeyValuePair with a Reference as the key and the scripture text as the value
        return new Tuple<Reference, string>(selectedScripture.Key, selectedScripture.Value);
    }
}
