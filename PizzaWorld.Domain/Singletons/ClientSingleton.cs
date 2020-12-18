using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private const string _path = @"./pizzaworld.xml";
        private static ClientSingleton _instance;
        public static ClientSingleton Instance 
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();                    
                }

                return _instance;                
            }
        }

        public List<Store> Stores {get; set;}
        private ClientSingleton()
        {
            Read();
        }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            Save();
        }

        private void Save()
        {            
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>));

            xml.Serialize(file, Stores);
        }

        private void Read()
        {
            if(!File.Exists(_path)){
                Stores = new List<Store>();
            }
                var file = new StreamReader(_path);
                var xml = new XmlSerializer(typeof(List<Store>));

                Stores = xml.Deserialize(file) as List<Store>;
        }
    }
}