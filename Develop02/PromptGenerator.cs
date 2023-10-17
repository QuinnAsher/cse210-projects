namespace Develop02;

public class  PromptGenerator
{   
    // class attributes
    public List<string> _promptList = new List<string>();

    public Random _randomNum = new Random();
    public int _randomIndex;
    public HashSet<int> _assingnedIndex = new HashSet<int>();
    
    // class constructor
    public PromptGenerator()
    {
        _promptList.AddRange(new List<string>
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
        
        // Initialize the assigned indices set with -1 (no index assigned yet)
        for (int i = 0; i < _promptList.Count; i++)
        {
            _assingnedIndex.Add(-1);
        }
        // int promptListNum = _promptList.Count;
        // _randomIndex = _randomNum.Next(promptListNum);
    }
    
    
    // create a method to check if the number has been assigned and get a random prompt
    public string GetRandomPrompt()
    {
        int promptListNum = _promptList.Count;
        int promptIndex;

        do
        {
            promptIndex = _randomNum.Next(promptListNum);

        } while (_assingnedIndex.Contains(promptIndex));
        
        // mark the index as assigned
        _assingnedIndex.Add(promptIndex);
        string randomPrompt = _promptList[promptIndex];
        return randomPrompt;
    }
}

