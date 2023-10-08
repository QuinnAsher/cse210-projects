namespace Develop02;

// A class for randomly generating prompts
public class PromptGenerator
{
    public Random _random = new Random();
    public List<string> _promptLIst = new List<string>();
    public HashSet<int> _assignedIndex= new HashSet<int>();
    
    // class constructor
    public PromptGenerator()
    {
        _promptLIst.AddRange(new List<string>
        {
            "What motivates me to study?",
            "How can I feel the Holy Spirit's promptings?",
            "What time of the day is the best time to go out with my friends?",
            "What is the most important thing I do every day?",
            "What is my strongest emotion?",
            "How can I improve my relationship with Christ?",
            "What is the greatest thing that happened to me today?",
            "Did I do something today that pushed me out of my comfort zone?",
            "What goals am I currently working towards?",
            "What is a new skill or hobby I'd like to learn?",
            "Describe a person who inspires me and why.",
            "What is a fear or challenge I want to overcome?",
            "What brings me joy and how can I incorporate more of it into my life?",
            "What would I like to achieve in the next five years?",
            "What is a recent act of kindness I experienced or witnessed?",
            "What is my favorite way to relax and unwind?",
            "What lessons have I learned from past mistakes?",
            "What are three things I appreciate about myself?",
            "What does a perfect day look like for me?",
            "What is my definition of success and how do I plan to achieve it?"
        });

    }

    public string GetRamdomPrompt()
    {
        // make sure that a prompt is not assigned more than one in a session
        int promptListLen = _promptLIst.Count;
        int promptIndex;

        do
        {
            promptIndex = _random.Next(promptListLen);
        } while (_assignedIndex.Contains(promptIndex));  // loop runs as long as promptIndex is in assinedIndex
        
        // assign the unassigned promptIndex to the hashset
        _assignedIndex.Add(promptIndex);

        string randomPrompt = _promptLIst[promptIndex];
        return randomPrompt;
    }
}

