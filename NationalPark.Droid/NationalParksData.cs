using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Newtonsoft.Json;
using Android.Content.Res;

namespace NationalPark.Droid
{
    public class NationalParksData
    {
        public string DataDir { get; set; }

        public string UriString { get; set; }

        public Activity Ctx { get; set; }

        private static NationalParksData _instance;

        public static NationalParksData Instance
        {
            get { return _instance ?? (_instance = new NationalParksData()); }
        }

        public void Load()
        {
            //var mydocuments = System.Environment.SpecialFolder.MyDocuments;
            //var path = System.Environment.GetFolderPath(mydocuments);
            //var filename = Path.Combine(path, "NationalParks.json");
            //string serializedParks = File.ReadAllText(filename);
            //Parks = JsonConvert.DeserializeObject<List<NationalPark>>(serializedParks);


            if (File.Exists(GetFilename()))
            {
                string serializedParks = File.ReadAllText(GetFilename());
                _parks = JsonConvert.DeserializeObject<List<NationalPark>>(serializedParks);
            }
            else
                _parks = new List<NationalPark>();



            //string jsonParks;
            //AssetManager assets = Ctx.Assets;
            //using (StreamReader sr = new StreamReader(assets.Open("NationalParks.json")))
            //{
            //    jsonParks = sr.ReadToEnd();
            //}
            //Parks = JsonConvert.DeserializeObject<List<NationalPark>>(jsonParks);
        }

        protected List<NationalPark> _parks;
        public List<NationalPark> Parks
        {
            get { return _parks; }
            protected set { _parks = value; }
        }


        private NationalParksData()
        {
           // Parks = new List<NationalPark>();
            
            //Load();
        }

        protected string GetFilename()
        {
            return Path.Combine(DataDir, "NationalParks.json");
        }

        public void Save(NationalPark park)
        {
            if (_parks != null)
            {
                if (!_parks.Contains(park))
                {
                    _parks.Add(park);
                    string serializedParks = JsonConvert.SerializeObject(Parks);
                    File.WriteAllText(GetFilename(), serializedParks);
                }
            }

            //if (Parks != null)
            //{
            //    if (!Parks.Contains(park))
            //        Parks.Add(park);
            //    string serializedParks = JsonConvert.SerializeObject(Parks);
            //    File.WriteAllText(GetFilename(), serializedParks);
            //    AssetManager assets = Ctx.Assets;
            //    using (StreamWriter sw = new StreamWriter(assets.Open("NationalParks.json")))
            //    {
            //        sw.Write(serializedParks);
            //    }
            //}
        }

        public void Delete(NationalPark park)
        {
            if (_parks != null)
            {
                _parks.Remove(park);
                string serializedParks = JsonConvert.SerializeObject(Parks);

                //AssetManager assets = Ctx.Assets;
                //using (StreamWriter sw = new StreamWriter(assets.Open("NationalParks.json")))
                //{
                //    sw.Write(serializedParks);
                //}
                File.WriteAllText(GetFilename(), serializedParks);
            }
        }
    }
}