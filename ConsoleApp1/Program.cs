namespace ConsoleApp1;

class Branch
{
    public bool Bird  { get; set; }
    public List<Branch>? subBranches { get; set; } = new List<Branch>();
    public bool HasSubBranches => subBranches.Count > 0;   //Here I miss to set  0 instead 1
}
class Tree
{
    public List<Branch> Branches { get; set; } = new List<Branch>();
}

class Program
{
    static void Main(string[] args)
    {
        List<Branch> nonEmptybranch = new List<Branch>(){new Branch(){ Bird = true}};
        List<Branch> emptyBranch = new List<Branch>();
        Tree tree = new Tree();

        bool birdFounded = false;
        tree.Branches = new List<Branch>()
        {
            new Branch()
            {
                Bird = false,
                subBranches = emptyBranch
            },
            new Branch()
            {
                Bird = false,
                subBranches = emptyBranch
            },
            new Branch()
            {
                Bird = false,
                subBranches = emptyBranch
            },
            new Branch()
            {
               Bird = false,
               subBranches = nonEmptybranch
            }
        };

        bool response = IterateSubBranches(tree);
        
        Console.WriteLine("Bird Founded: " + response);
    }

    static bool IterateSubBranches(Tree tree)
    {
        List<Branch> subBranches = tree.Branches;
        
        for (int i = 0; i < subBranches.Count; i++)
        {
            if (subBranches[i].Bird)
            {
                return true;
            }
            
            if (subBranches[i].HasSubBranches)
            {
                if (SearchBird(subBranches[i].subBranches!))
                {
                    return true;
                }
            }
        }

        return false;
    }

    static bool SearchBird( List<Branch> subBranches)
    {
        for (int i = 0; i < subBranches.Count(); i++)
        {
            if (subBranches[i].Bird)
            {
                return true;
            }
            
            if (subBranches[i].HasSubBranches)
            {
                if (SearchBird(subBranches[i].subBranches!))
                {
                    return true;
                }
            }
        }
        return false;
    }
}