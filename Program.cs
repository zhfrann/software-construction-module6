using System.Diagnostics;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        Debug.Assert(username != null, "Nama Username tidak boleh null");
        Debug.Assert(username.Length <= 100, "Panjang maksimal username adalah 100 karakter");


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
        Debug.Assert(video != null, "Video yang ditambahkan tidak boleh null");
        Debug.Assert(video.GetPlayCount() < int.MaxValue, "Nilai playCount video melebihi maksimal int");

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

            if (i == 9)
            {
                Console.WriteLine("Maksimal video yang ditampilkan adalah 8.");
                break;
            }
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
        Debug.Assert(title != null, "Judul video tidak boleh null");
        Debug.Assert(title.Length <= 200, "Panjang maksimal judul maksimal 200 karakter");

        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int playCount)
    {
        Debug.Assert(playCount <= 25000000, "Maksimal penambahan playcCount 25.000.000");
        Debug.Assert(playCount > 0, "playCount tidak boleh negatif");

        try
        {
            checked
            {
                this.playCount += playCount;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error, playCount overflow. Message: " + ex.Message);
        }
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
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);

        Console.WriteLine("Video 2 : ");
        video2.PrintVideoDetails();

        Console.WriteLine("\n");
        user.PrintAllVideoPlaycount();
        Console.WriteLine("Total play count: " + user.GetTotalVideoPlayCount());
    }
}