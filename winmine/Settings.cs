using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace winmine
{
    public class Settings
    {
        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Expert,
            Custom
        }
        const string sBeginner = "Beginner";
        const string sMedium = "Intermediate";
        const string sHard = "Expert";
        const string sCustom = "Custom";
        
        public Difficulty difficulty;
        public List<Score> Easy = new List<Score>();
        public List<Score> Medium = new List<Score>();
        public List<Score> Hard = new List<Score>();
        public List<Score> Custom = new List<Score>();

        public ushort Width;
        public ushort Height;
        public ushort Bombs;
        public ushort NumberOfWins;

        IniData id;

        public Settings()
        {

        }
        public bool IsTimeTopTen(Difficulty di, ushort time)
        {
            return 10 != GetTimePosition(di, time);
        }

        public void AddTime(Difficulty di, Score score)
        {
            List<Score> scores;
            switch (di)
            {
                case Difficulty.Beginner:       scores = Easy;
                                                break;
                case Difficulty.Intermediate:   scores = Medium;
                                                break;
                case Difficulty.Expert:         scores = Hard;
                                                break;
                default:                        scores = Custom;
                                                break;
            }
            scores.Insert(GetTimePosition(di, score.Time),score);
            scores.RemoveAt(scores.Count - 1);
        }
        public byte GetTimePosition(Difficulty di, ushort time)
        {
            List<Score> times;
            switch (di)
            {
                case Difficulty.Beginner:         times = Easy;
                                                  break;
                case Difficulty.Intermediate:     times = Medium;
                                                  break;
                case Difficulty.Expert:           times = Hard;
                                                  break;
                default:                          times = Custom;
                                                  break;
            }
            for (byte i = 0; i < times.Count; i++)
                if (time < times[i].Time)
                    return i;
            return 10;
        }
        private string getBasePath()
        {
            return new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        }

        private List<Score> LoadTime(IniData id, string Difficulty, List<Score> scores)
        {
            scores.Clear();
            for (int i = 0; i < id[Difficulty].Count(); i++)
            {
                byte tabPos;
                Score s = new Score();
                string t = id[Difficulty].GetKeyData((i + 1).ToString()).Value;
                tabPos = (byte)t.IndexOf('\t');
                s.Name = t.Substring(0, tabPos);
                s.Time = ushort.Parse(t.Substring(tabPos + 1));
                scores.Add(s);
            }
            return scores;
        }
        private string DifficultyToDifficulty(Difficulty diff)
        {
            if (Difficulty.Beginner == diff) return sBeginner;
            if (Difficulty.Intermediate == diff) return sMedium;
            if (Difficulty.Expert == diff) return sHard;
            return sCustom;
        }
        private void SaveTime(string Difficulty, List<Score> scores)
        {
            for (int i = 0; i < scores.Count;i++)
                id[Difficulty.ToString()].GetKeyData((i + 1).ToString()).Value = scores[i].Name + '\t' + scores[i].Time.ToString();
        }
        public Settings(bool LoadFromFile)
        {
            if (!LoadFromFile) return;

            id = new FileIniDataParser().ReadFile(getBasePath() + "\\winmine.ini");

            switch (id["Difficulty"].GetKeyData("Mode").Value)
            {
                case sBeginner:     difficulty = Difficulty.Beginner;
                                    break;
                case sMedium:       difficulty = Difficulty.Intermediate;
                                    break;
                case sHard:         difficulty = Difficulty.Expert;
                                    break;
                case sCustom:      difficulty = Difficulty.Custom;
                                    break;
            }

            Width = ushort.Parse(id["CustomSettings"].GetKeyData("Width").Value);
            Height = ushort.Parse(id["CustomSettings"].GetKeyData("Height").Value);
            Bombs = ushort.Parse(id["CustomSettings"].GetKeyData("Bombs").Value);
            NumberOfWins = ushort.Parse(id["CustomSettings"].GetKeyData("NumberOfWins").Value);

            Easy = LoadTime(id, sBeginner, Easy);
            Medium = LoadTime(id, sMedium, Medium);
            Hard = LoadTime(id, sHard, Hard);
            Custom = LoadTime(id, sCustom, Custom);
        }

        public void Save()
        {
            string val = "";
            switch(difficulty)
            {
                case Difficulty.Beginner:       val = sBeginner;
                                                break;
                case Difficulty.Intermediate:   val = sMedium;
                                                break;
                case Difficulty.Expert:         val = sHard;
                                                break;
                case Difficulty.Custom:         val = sCustom;
                                                break;
            }

            id["Difficulty"].GetKeyData("Mode").Value = val;

            id["CustomSettings"].GetKeyData("Width").Value = Width.ToString();
            id["CustomSettings"].GetKeyData("Height").Value = Height.ToString();
            id["CustomSettings"].GetKeyData("Bombs").Value = Bombs.ToString();
            id["CustomSettings"].GetKeyData("NumberOfWins").Value = NumberOfWins.ToString();
            SaveTime(sBeginner, Easy);
            SaveTime(sMedium, Medium);
            SaveTime(sHard, Hard);
            SaveTime(sCustom, Custom);

            new FileIniDataParser().WriteFile(GetDataFilePath(), id, new UTF8Encoding(false));
        }

        private string GetDataFilePath()
        {
            return getBasePath() + "\\winmine.ini";
        }
    }

    public class Score : IComparable
    {
        public string Name;
        public ushort Time;

        public Score(string name, ushort time)
        {
            Name = name;
            Time = time;
        }

        public Score() { }

        public int CompareTo(object obj)
        {
            if (((Score)obj).Time < this.Time)
                return 1;

            if (((Score)obj).Time > this.Time)
                return -1;
            return 0;
        }
    }
}
