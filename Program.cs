class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        //return uploadedVideos.Count;
        int playCountAllVideos = 0;
        foreach (var video in uploadedVideos)
        {
            playCountAllVideos += video.GetPlayCount();
        }
        return playCountAllVideos;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.Username);

        int i = 1;
        foreach (var video in uploadedVideos)
        {
            Console.WriteLine($"Video {i} judul: {video.GetTitle()}");
            i++;
        }
    }
}


class SayaTubeVideo
{
    private int id;
    private int playCount;
    private string title;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int playCount)
    {
        this.playCount = playCount;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Id: " + id);
        Console.WriteLine("Play Count: " + playCount);
    }

    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }
}

class Program
{
    public static void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Zhafran");

        SayaTubeVideo video1 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video2 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video3 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video4 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video5 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video6 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video7 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video8 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video9 = new SayaTubeVideo("Review film -- oleh Zhafran");
        SayaTubeVideo video10 = new SayaTubeVideo("Review film -- oleh Zhafran");


        video1.IncreasePlayCount(100);
        video2.IncreasePlayCount(200);

        user.AddVideo(video1);
        user.AddVideo(video2);

        user.PrintAllVideoPlaycount();
        Console.WriteLine("Total play count: " + user.GetTotalVideoPlayCount());
    }
}