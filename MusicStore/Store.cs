using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore
{
  public interface IStoreItem
  {
    double Price { get; set; }

    void DiscountPrice(int percent);
  }

  public class Disk : IStoreItem
  {
    private string
      _name,
      _genre;
    private int
      _burnCount;

    public string Name { get => _name; set => _name = value; }
    public string Genre { get => _genre; set => _genre = value; }
    public int BurnCount { get => _burnCount; set => _burnCount = value; }

    public virtual int DiskSize { get; set; }
    public double Price { get; set; }

    public Disk(string name, string genre)
    {
      Name = name;
      Genre = genre;
      BurnCount = 0;
    }
    public virtual void Burn(params string[] values) { }

    public void DiscountPrice(int percent)
    {
      Price *= ((100 - percent) / 100);
    }
  }

  public class Audio : Disk
  {
    private string
      _artist,
      _recordingStudio;
    private int
      _songsNumber;

    public string Artist { get => _artist; set => _artist = value; }
    public string RecordingStudio { get => _recordingStudio; set => _recordingStudio = value; }
    public int SongsNumber { get => _songsNumber; set => _songsNumber = value; }

    public Audio(string artist, string recordingStudio, int songsNumber, string name, string genre)
      : base(name, genre)
    {
      Artist = artist;
      RecordingStudio = recordingStudio;
      SongsNumber = songsNumber;
    }

    public override int DiskSize { get => SongsNumber * 8; set => DiskSize = DiskSize; }

    public override void Burn(params string[] values)
    { // "Присваивает полям новые значения"
      // Не совсем понял, что это значит, поэтому буду считать,
      // что параметры указываются в таком порядке:
      // название, жанр, испольнитель, студия звукозаписи
      
      int valuesSize = values.Length;
           
      RecordingStudio = (valuesSize >= 4) ? values[3] : RecordingStudio;
      Artist = (valuesSize >= 3) ? values[2] : Artist;
      Genre = (valuesSize >= 2) ? values[1] : Genre;  
      Name = (valuesSize >= 1) ? values[0] : Name;
      BurnCount++;
    }

    public override string ToString()
    {
      return $"Name: {Name}\nGenre: {Genre}\nArtist: {Artist}" +
        $"\nRecording studio: {RecordingStudio}\n" +
        $"Songs number: {SongsNumber}\nBurn count: {BurnCount}";
    }

  }

  class DVD : Disk
  {
    private string
      _producer,
      _filmCompany;
    private int
      _minutesCount;

    public DVD(string producer, string filmCompany, 
      int minutesCount, string name, string genre)
      : base(name, genre)
    {
      Producer = producer;
      FilmCompany = filmCompany;
      MinutesCount = minutesCount;
    }

    public override int DiskSize { get => MinutesCount / 32; set => DiskSize = DiskSize; }
    public override void Burn(params string[] values)
    {// "Присваивает полям новые значения"
     // Не совсем понял, что это значит, поэтому буду считать,
     // что параметры указываются в таком порядке:
     // название, жанр, режисер, кинокомпания

      int valuesSize = values.Length;

      FilmCompany = (valuesSize >= 4) ? values[3] : FilmCompany;
      Producer = (valuesSize >= 3) ? values[2] : Producer;
      Genre = (valuesSize >= 2) ? values[1] : Genre;
      Name = (valuesSize >= 1) ? values[0] : Name;
      BurnCount++;
    }

    public override string ToString()
    {
      return $"Name: {Name}\nGenre: {Genre}\nProducer: {Producer}" +
        $"\nFilm company: {FilmCompany}\nMinutes count: {MinutesCount}" +
        $"\nBurn count: {BurnCount}";

    }
    public string Producer { get => _producer; set => _producer = value; }
    public string FilmCompany { get => _filmCompany; set => _filmCompany = value; }
    public int MinutesCount { get => _minutesCount; set => _minutesCount = value; }
  }
  class Store
  {
    private string
      _storeName,
      _address;
    private List<Audio> 
      _audios;
    private List<DVD>
      _dvds;

    public Store(string storeName, string address)
    {
      StoreName = storeName;
      Address = address;
      Audios = new List<Audio>();
      Dvds = new List<DVD>();
    }

    public string StoreName { get => _storeName; set => _storeName = value; }
    public string Address { get => _address; set => _address = value; }
    public List<Audio> Audios { get => _audios; set => _audios = value; }
    internal List<DVD> Dvds { get => _dvds; set => _dvds = value; }

    public static Store operator +(Store store, Audio audio)
    {
      Store tmpStore = store;
      tmpStore.Audios.Add(audio);
      return tmpStore;
    }
    public static Store operator -(Store store, Audio audio)
    {
      Store tmpStore = store;
      tmpStore.Audios.Remove(audio);
      return tmpStore;
    }
    public static Store operator +(Store store, DVD dvd)
    {
      Store tmpStore = store;
      tmpStore.Dvds.Add(dvd);
      return tmpStore;
    }
    public static Store operator -(Store store, DVD dvd)
    {
      Store tmpStore = store;
      tmpStore.Dvds.Remove(dvd);
      return tmpStore;
    }

    public override string ToString()
    {
      string resultString = "Audio disks:\n\n";
      foreach (Audio audio in Audios)
        resultString += audio.ToString() + "\n\n";
      resultString += "\nDVD disks:\n\n";
      foreach (DVD dvd in Dvds)
        resultString += dvd.ToString() + "\n\n";
      return resultString;
    }
  }
}
