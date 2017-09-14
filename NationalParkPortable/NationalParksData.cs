using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NationalParkPortable
{
    public class NationalParksData
    {
        public IFileHandler FileHandler { get; set; }
        public string DataDir { get; set; }

        private static NationalParksData _instance;

        public static NationalParksData Instance
        {
            get { return _instance ?? (_instance = new NationalParksData()); }
        }

        protected List<NationalPark> _parks;
        public List<NationalPark> Parks
        {
            get { return _parks; }
            protected set { _parks = value; }
        }
        private NationalParksData()
        {
            //DataDir = "";
        }
        protected string GetFilename()
        {
            return Path.Combine(DataDir, "NationalParks.json");
        }

        public void Load()
        {          
            if (FileHandler.FileExists(GetFilename()))
            {
                string serializedParks = FileHandler.ReadAllText(GetFilename());
                _parks = JsonConvert.DeserializeObject<List<NationalPark>>(serializedParks);
            }
            else
                _parks = new List<NationalPark>();
        }
        public void Save(NationalPark park)
        {
            if (_parks != null)
            {
                if (!_parks.Contains(park))
                {
                    _parks.Add(park);
                    string serializedParks = JsonConvert.SerializeObject(_parks);
                    FileHandler.WriteAllText(GetFilename(), serializedParks);
                }
            }
            else
            {
                //Update!
            }
        }

        public void Delete(NationalPark park)
        {
            if (_parks != null)
            {
                _parks.Remove(park);
                string serializedParks = JsonConvert.SerializeObject(_parks);
                FileHandler.WriteAllText(GetFilename(), serializedParks);
            }
        }
    }
}