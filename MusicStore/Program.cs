using System;
using System.Collections.Generic;

namespace MusicStore
{
  class Program
  {
    static void Main(string[] args)
    {
      

      Store store = new Store("disk shop", "groove st.");

      Audio track1 = new Audio("Michael Jackson", "hz", 4, "billie jean", "pop");
      Audio track2 = new Audio("Kanye West", "ne znayu", 4, "cheto pro *itlera", "mb not pop");

      DVD vid1 = new DVD("tar", "vid", 228, "Pulp fiction", "comedy");
      DVD vid2 = new DVD("muzhik", "kino", 322, "Clockwork orange", "drama");
      DVD vid3 = new DVD("dama", "peak", 1337, "50 shades of gray", "fantasy");

      store = store + track1;
      store = store + track2;
      store = store + vid1;
      store = store + vid2;
      store = store + vid3;
      store = store - vid3;
      Console.WriteLine(store.ToString() + "\n");

      vid3.Burn("param1", "param2", "param3", "param4", "param5", "param6", "param7");
      Console.WriteLine(vid3.ToString() + "\n");

      List<Audio> list1 = new List<Audio>() { track1, track2 };
      List<DVD> list2 = new List<DVD>() { vid1, vid2, vid3 };

      foreach (Audio audio in list1)
        Console.WriteLine($"{audio.Name} -> {audio.DiskSize}");
      Console.WriteLine();
      foreach (DVD dvd in list2)
        Console.WriteLine($"{dvd.Name} -> {dvd.DiskSize}");
    }
  }
}
